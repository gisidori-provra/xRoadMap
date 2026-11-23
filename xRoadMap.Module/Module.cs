using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo.DB;
using DevExpress.Xpo;
using System.ComponentModel;
using NetTopologySuite.Geometries;
using xRoadMap.Module.BusinessObjects;
using xRoadMap.Xpo;
using xRoadMap.Module.Xpo;
using System.Configuration;
using DevExpress.Data.Utils;

namespace xRoadMap.Module
{
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    public sealed class xRoadMapModule : ModuleBase
    {
        public xRoadMapModule()
        {
            //
            // xRoadMapModule
            //
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifference));
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifferenceAspect));
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.BaseObject));
            //AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent));
            //AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference));
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileData));
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileAttachmentBase));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Security.SecurityModule));
            //RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.AuditTrail.AuditTrailModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.CloneObject.CloneObjectModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.ReportsModuleV2));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule));
            STContainsFunction.Register();
            STMaxMFunction.Register();
            STMinMFunction.Register();

            NetTopologySuite.NtsGeometryServices.Instance = new NetTopologySuite.NtsGeometryServices(
                // default CoordinateSequenceFactory
                NetTopologySuite.Geometries.Implementation.CoordinateArraySequenceFactory.Instance,
                // default precision model
                new NetTopologySuite.Geometries.PrecisionModel(1000d),
                // default SRID
                25832,
                /********************************************************************
                 * Note: the following arguments are only valid for NTS >= v2.2
                 ********************************************************************/
                // Geometry overlay operation function set to use (Legacy or NG)
                NetTopologySuite.Geometries.GeometryOverlay.NG,
                // Coordinate equality comparer to use (CoordinateEqualityComparer or PerOrdinateEqualityComparer)
                new NetTopologySuite.Geometries.CoordinateEqualityComparer());

            var some_factory_that_I_may_or_may_not_use =
                NetTopologySuite.Geometries.GeometryFactory.Default;

        }

        private static string spatialDbType = "geometry";

        public static void ConfigureSpatialDbType(string connectionString)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

            bool isMssql =
                connectionString.Contains(
                    $"{DataStoreBase.XpoProviderTypeParameterName}={MSSqlSpatialProvider.XpoProviderTypeString}",
                    StringComparison.OrdinalIgnoreCase)
                || connectionString.Contains(
                    $"{DataStoreBase.XpoProviderTypeParameterName}={MSSqlConnectionProvider.XpoProviderTypeString}",
                    StringComparison.OrdinalIgnoreCase);

            bool isOracle =
                connectionString.Contains(
                    $"{DataStoreBase.XpoProviderTypeParameterName}={OracleSDEConnectionProvider.XpoProviderTypeString}",
                    StringComparison.OrdinalIgnoreCase);

            spatialDbType = isMssql
                ? "geometry"
                : isOracle
                    ? "SDE.ST_GEOMETRY"
                    : throw new NotSupportedException(
                        "Provider XPO spaziale non supportato.");
        }


        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }

        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            ConfigureSpatialMembers(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }

        private static void ConfigureSpatialMembers(ITypesInfo typesInfo)
        {
            var typesToRefresh = new HashSet<Type>();

            foreach (var typeInfo in typesInfo.PersistentTypes)
            {
                foreach (var memberInfo in typeInfo.Members)
                {
                    if (memberInfo.IsPersistent
                        && typeof(Geometry).IsAssignableFrom(memberInfo.MemberType))
                    {
                        memberInfo.AddAttribute(new DbTypeAttribute(spatialDbType), true);
                        typesToRefresh.Add(typeInfo.Type);
                    }
                }
            }

            foreach (var type in typesToRefresh)
                typesInfo.RefreshInfo(type);
        }

        public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
        {
            extenders.Add<IModelPropertyEditor, IModelMapPropertyEditor>();
            extenders.Add<IModelListView, IModelMapListView>();
            extenders.Add<IModelOptions, IModelMapOptions>();
            base.ExtendModelInterfaces(extenders);
        }
    }
}
