using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.IO.Esri.Shapefiles.Readers;
using System.IO.Compression;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.Controllers
{
    public class IXPGeometryImportController : ObjectViewController<ListView, IXPGeometry>
    {
        private readonly PopupWindowShowAction importaGeometriaAction;

        public IXPGeometryImportController()
        {
            importaGeometriaAction = new PopupWindowShowAction(this, "ImportaGeometriaDaFile", PredefinedCategory.Edit)
            {
                Caption = "Importa geometria",
                ImageName = "Import",
                SelectionDependencyType = SelectionDependencyType.Independent
            };

            importaGeometriaAction.CustomizePopupWindowParams += ImportaGeometriaAction_CustomizePopupWindowParams;
            importaGeometriaAction.Execute += ImportaGeometriaAction_Execute;
        }

        private void ImportaGeometriaAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            NonPersistentObjectSpace objectSpace = (NonPersistentObjectSpace)Application.CreateObjectSpace(typeof(UploadGeometryParameters));
            objectSpace.PopulateAdditionalObjectSpaces(Application);
            e.DialogController.SaveOnAccept = false;
            e.View = Application.CreateDetailView(objectSpace, objectSpace.CreateObject<UploadGeometryParameters>());
        }

        private void ImportaGeometriaAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            UploadGeometryParameters parameters = (UploadGeometryParameters)e.PopupWindowViewCurrentObject;
            if (parameters.File is null)
            {
                throw new UserFriendlyException("Selezionare un file .geojson, .json, .shp o .zip.");
            }

            Type objectType = View.ObjectTypeInfo.Type;
            if (objectType.IsAbstract || objectType.IsInterface)
            {
                throw new UserFriendlyException("La ListView corrente non supporta la creazione diretta degli oggetti.");
            }

            IReadOnlyList<Geometry> geometries = ParseGeometries(parameters.File);
            foreach (Geometry geometry in geometries)
            {
                IXPGeometry newObject = (IXPGeometry)ObjectSpace.CreateObject(objectType);
                newObject.Shape = geometry;
            }

            ObjectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
        }

        private static IReadOnlyList<Geometry> ParseGeometries(FileData file)
        {
            if (string.IsNullOrWhiteSpace(file.FileName))
            {
                throw new UserFriendlyException("Nome file non valido.");
            }

            string extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            using MemoryStream stream = new();
            file.SaveToStream(stream);
            stream.Position = 0;

            IReadOnlyList<Geometry> geometries;
            switch (extension)
            {
                case ".geojson":
                case ".json":
                    geometries = ParseGeoJson(stream);
                    break;
                case ".shp":
                    geometries = ParseShapefile(stream, file.FileName);
                    break;
                case ".zip":
                    geometries = ParseZipShapefile(stream);
                    break;
                default:
                    throw new UserFriendlyException("Formato non supportato. Usare file .geojson, .json, .shp o .zip.");
            }

            foreach (Geometry geometry in geometries)
            {
                if (geometry.SRID == 0)
                {
                    geometry.SRID = 25832;
                }
            }

            return geometries;
        }

        private static IReadOnlyList<Geometry> ParseGeoJson(Stream stream)
        {
            stream.Position = 0;
            using StreamReader reader = new(stream, leaveOpen: true);
            string json = reader.ReadToEnd();

            GeoJsonReader geoJsonReader = new();
            List<Geometry> geometries = new();

            try
            {
                Geometry geometry = geoJsonReader.Read<Geometry>(json);
                if (geometry is not null)
                {
                    geometries.Add(geometry);
                }
            }
            catch
            {
            }

            try
            {
                Feature feature = geoJsonReader.Read<Feature>(json);
                if (feature?.Geometry is not null)
                {
                    geometries.Add(feature.Geometry);
                }
            }
            catch
            {
            }

            try
            {
                FeatureCollection featureCollection = geoJsonReader.Read<FeatureCollection>(json);
                if (featureCollection is not null)
                {
                    geometries.AddRange(featureCollection
                        .Select(f => f?.Geometry)
                        .Where(g => g is not null));
                }
            }
            catch
            {
            }

            geometries = geometries
                .Where(g => g is not null)
                .ToList();

            if (geometries.Count > 0)
                return geometries;

            throw new UserFriendlyException("Il GeoJSON non contiene geometrie valide.");
        }

        private static IReadOnlyList<Geometry> ParseShapefile(Stream stream, string fileName)
        {
            string tempDir = Path.Combine(Path.GetTempPath(), $"xRoadMap_shp_{Guid.NewGuid():N}");
            Directory.CreateDirectory(tempDir);

            try
            {
                string shpPath = Path.Combine(tempDir, Path.GetFileName(fileName));
                using (FileStream fileStream = File.Create(shpPath))
                {
                    stream.Position = 0;
                    stream.CopyTo(fileStream);
                }

                return ReadShapefileGeometries(shpPath);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException($"Errore durante la lettura dello shapefile: {ex.Message}");
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        private static IReadOnlyList<Geometry> ParseZipShapefile(Stream stream)
        {
            string tempDir = Path.Combine(Path.GetTempPath(), $"xRoadMap_zip_{Guid.NewGuid():N}");
            Directory.CreateDirectory(tempDir);

            try
            {
                stream.Position = 0;
                using ZipArchive archive = new(stream, ZipArchiveMode.Read, leaveOpen: true);
                archive.ExtractToDirectory(tempDir);

                string shpPath = Directory.GetFiles(tempDir, "*.shp", SearchOption.AllDirectories).FirstOrDefault();
                if (string.IsNullOrEmpty(shpPath))
                {
                    throw new UserFriendlyException("Lo zip non contiene alcun file .shp.");
                }

                return ReadShapefileGeometries(shpPath);
            }
            catch (UserFriendlyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException($"Errore durante la lettura dello shapefile compresso: {ex.Message}");
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        private static IReadOnlyList<Geometry> ReadShapefileGeometries(string shpPath)
        {
            GeometryFactory factory = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(srid: 25832);
            ShapefileReaderOptions options = new()
            {
                Factory = factory
            };

            IReadOnlyList<Geometry> geometries =
                TryReadAllGeometries(() => new ShapefilePointReader(shpPath, options)) ??
                TryReadAllGeometries(() => new ShapefileMultiPointReader(shpPath, options)) ??
                TryReadAllGeometries(() => new ShapefilePolyLineReader(shpPath, options)) ??
                TryReadAllGeometries(() => new ShapefilePolygonReader(shpPath, options));

            if (geometries is null || geometries.Count == 0)
            {
                throw new UserFriendlyException("Lo shapefile non contiene elementi geometrici supportati.");
            }

            return geometries;
        }

        private static IReadOnlyList<Geometry> TryReadAllGeometries(Func<ShapefileReader> readerFactory)
        {
            try
            {
                List<Geometry> geometries = new();
                using ShapefileReader reader = readerFactory();
                while (reader.Read())
                {
                    if (reader.Geometry is not null)
                    {
                        geometries.Add(reader.Geometry.Copy());
                    }
                }

                if (geometries.Count > 0)
                    return geometries;
            }
            catch
            {
            }

            return null;
        }
    }

    [DomainComponent]
    public class UploadGeometryParameters : NonPersistentObjectImpl
    {
        private FileData file;

        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        [RuleRequiredField(DefaultContexts.Save, CustomMessageTemplate = "Selezionare un file da importare")]
        public FileData File
        {
            get => file;
            set => SetPropertyValue(ref file, value);
        }
    }
}
