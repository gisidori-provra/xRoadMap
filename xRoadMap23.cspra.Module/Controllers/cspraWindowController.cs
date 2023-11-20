using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using xRoadMap.cspra.Module.Module.BusinessObjects.cspra;
using xRoadMap.cspra.Module.Module.BusinessObjects.cspraDataModel;
using xRoadMap.Module.BusinessObjects;
using xRoadMap.Module.BusinessObjects.cspra;

namespace xRoadMap.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class cspraWindowController : WindowController
    {
        public cspraWindowController()
        {
            InitializeComponent();
            // Target required Windows (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target Window.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void actionImport_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var os = this.Application.CreateObjectSpace();
            switch (e.SelectedChoiceActionItem.Id)
            {
                //case "Strade":
                //    AggiornaStrade(os);
                //    break;
                case "DispositiviRitenuta":
                    ImportaDispositiviRitenuta(os);
                    break;
                case "Cunette":
                    ImportaCunette(os);
                    break;
                case "Ciclabili":
                    ImportaCiclabili(os);
                    break;
                case "Arginelli":
                    ImportaArginelli(os);
                    break;
                case "Vegetazione":
                    ImportaVegetazione(os);
                    break;
                case "SottoPassaggi":
                    ImportaSottoPassaggi(os);
                    break;
                case "PassaggiLivello":
                    ImportaPassaggiLivello(os);
                    break;
                case "OpereSostegno":
                    ImportaOpereSostegno(os);
                    break;
                case "Marciapiedi":
                    ImportaMarciapiedi(os);
                    break;
                case "Gallerie":
                    ImportaGallerie(os);
                    break;
                case "CorpiStradali":
                    ImportaCorpiStradali(os);
                    break;
                case "CentriAbitati":
                    ImportaCentriAbitati(os);
                    break;
                case "Carreggiate":
                    ImportaCarreggiate(os);
                    break;
                case "Banchine":
                    ImportaBanchine(os);
                    break;
                case "AreeTraffico":
                    ImportaAreeTraffico(os);
                    break;
                case "Accessi":
                    ImportaAccessi(os);
                    break;
                case "Tombini":
                    ImportaTombini(os);
                    break;
                case "Ponti":
                    ImportaPonti(os);
                    break;
                case "TrattiUrbani":
                    ImportaTrattiUrbani(os);
                    break;
                default:
                    break;
            }
            os.CommitChanges();
        }

        void AggiornaStrade(IObjectSpace os)
        {
            var ss = os.GetObjects<Strada>();
            foreach (var s in ss)
            {
                s.Percorso = os.FindObject<Percorso>(new BinaryOperator(nameof(Percorso.Strada), s.Oid));
            }

        }

        private static void ImportaTrattiUrbani(IObjectSpace os)
        {


        }
        private static void ImportaTombini(IObjectSpace os)
        {
            var tombini = os.GetObjects<cspraTombino>();
            foreach (var item in tombini)
            {
                try
                {
                    Tombino t = Import<Tombino>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    t.TipoTombino = GetOrCreateDomain<TipoTombino>(os, item.TIPOO);
                    os.CommitChanges();
                }
                catch { os.Rollback(); }
            }
        }

        private static void ImportaAccessi(IObjectSpace os)
        {
            var items = os.GetObjects<cspraAccessi>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<Accesso>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    //var cAccesso = os.GetObjectByKey<cspraAccessi>(item.EVE_ID);
                    acc.Destinazione = GetOrCreateDomain<TipoDestinazioneAccesso>(os, item.Destinazione);
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaAreeTraffico(IObjectSpace os)
        {
            var items = os.GetObjects<cspraAreaTraffico>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<AreaTraffico>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.TipoAreaTraffico = GetOrCreateDomain<TipoAreaTraffico>(os, item.TipoServizio);
                    acc.Denominazione = item.Denominazione;
                    acc.CorsieAccDec = (item.Corsie.ENUM_VAL.Trim() == "1");
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaBanchine(IObjectSpace os)
        {
            var items = os.GetObjects<cspraBanchina>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<Banchina>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.TipoPavimentazione = GetOrCreateDomain<TipoPavimentazione>(os, item.TipoPav);
                    acc.TipoSuperficie = GetOrCreateDomain<TipoSuperficie>(os, item.TipoSuperficie);
                    acc.Larghezza = item.Larghezza;
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaCarreggiate(IObjectSpace os)
        {
            var items = os.GetObjects<cspraCarreggiata>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<Carreggiata>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    //var cAccesso = os.GetObjectByKey<cspraAccessi>(item.EVE_ID);
                    acc.TipoCarreggiata = GetOrCreateDomain<TipoCarreggiata>(os, item.Tipo);
                    acc.Larghezza = item.Larghezza;
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaCentriAbitati(IObjectSpace os)
        {
            var items = os.GetObjects<cspraCentroAbitato>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<CentroAbitato>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    //var cAccesso = os.GetObjectByKey<cspraAccessi>(item.EVE_ID);
                    acc.Nome = item.Nome; 
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaCorpiStradali(IObjectSpace os)
        {
            var items = os.GetObjects<cspraCorpoStradale>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<CorpoStradale>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.TipoCorpoStradale = GetOrCreateDomain<TipologiaCorpoStradale>(os, item.TipoCorpoStradale);
                    acc.Delimitazione = GetOrCreateDomain<TipoDelimitazione>(os, item.Delimitazione);
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaGallerie(IObjectSpace os)
        {
            var items = os.GetObjects<cspraGallerie>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<Galleria>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.TipoOpera = GetOrCreateDomain<TipoOperaGalleria>(os, item.Tipo);
                    acc.Illuminazione= GetOrCreateDomain<TipoIlluminazione>(os, item.Illuminazione);
                    acc.IlluminazioneImbocco = GetOrCreateDomain<TipoIlluminazione>(os, item.IlluminazioneImbocco);
                    acc.Ventilazione = GetOrCreateDomain<TipoImpiantoVentilazione>(os, item.Ventilazione);
                    acc.Piazzole = item.Piazzole.ENUM_VAL == "1";
                    acc.Stato = GetOrCreateDomain<TipoStatoConservazione>(os, item.Stato);
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaMarciapiedi(IObjectSpace os)
        {
            var items = os.GetObjects<cspraMarciapiede>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<Marciapiede>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.Larghezza = item.Larghezza;
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaOpereSostegno(IObjectSpace os)
        {
            var items = os.GetObjects<cspraOperaSostegno>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<OperaSostegno>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.TipoOpera = GetOrCreateDomain<TipoOperaSostegno>(os,item.Tipo);
                    acc.TipoCostruzione = GetOrCreate<TipologiaCostruttivaOperaSostegno>(os, item.TipoCostr);
                    acc.Stato = GetOrCreateDomain<TipoStatoConservazione>(os, item.Stato);
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }
        private static void ImportaPassaggiLivello(IObjectSpace os)
        {
            var items = os.GetObjects<cspraPassaggioLivello>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<PassaggioLivello>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.TipoPassaggioLivello = GetOrCreateDomain<TipoPassaggioLivello>(os, item.Tipo);
                    acc.NumeroBinari = item.NumeroBinari;
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaSottoPassaggi(IObjectSpace os)
        {
            var items = os.GetObjects<cspraSovrappassi>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<Sottopasso>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.TipoSottopasso = GetOrCreateDomain<TipoSottopasso>(os, item.Tipo);
                    acc.Stato = GetOrCreateDomain<TipoStatoConservazione>(os, item.StatoConservazione);
                    acc.Illuminazione = GetOrCreateDomain<TipoIlluminazione>(os, item.Illuminazione);
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }


        private static void ImportaVegetazione(IObjectSpace os)
        {
            var items = os.GetObjects<cspraVegetazione>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<Vegetazione>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.TipoVegetazione = GetOrCreateDomain<TipoVegetazione>(os, item.TipoVegetazione);
                    acc.Funzione = GetOrCreateDomain<FunzioneVegetazione>(os, item.Funzione);
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaArginelli(IObjectSpace os)
        {
            var items = os.GetObjects<cspraArginelli>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<Arginello>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.LarghezzaDX = item.LarghezzaDX;
                    acc.LarghezzaSX = item.LarghezzaSX;
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaCiclabili(IObjectSpace os)
        {
            var items = os.GetObjects<cspraCiclabile>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<Ciclabile>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.TipoCiclabile = GetOrCreateDomain<TipoCiclabile>(os, item.Tipologia);
                    acc.Senso = GetOrCreateDomain<SensoCiclabile> (os, item.Senso);
                    acc.Larghezza = item.Larghezza;
                    acc.Lunghezza = item.Lunghezza;
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaCunette(IObjectSpace os)
        {
            var items = os.GetObjects<cspraCunetta>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<Cunetta>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaDispositiviRitenuta(IObjectSpace os)
        {
            var items = os.GetObjects<cspraDispRitenuta>();
            foreach (var item in items)
            {
                try
                {
                    var acc = Import<DispositivoRitenuta>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    acc.Tipologia = GetOrCreateDomain<TipoDispositivoRitenuta>(os, item.Tipologia);
                    acc.Materiale = GetOrCreateDomain<TipoMaterialeDispositivoRitenuta>(os, item.Materiale);
                    acc.Classificazione = GetOrCreateDomain<ClassificazioneDispositivoRitenuta> (os, item.Classificazione);
                    acc.Distanza = item.Distanza;
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }

        private static void ImportaPonti(IObjectSpace os)
        {
            var ponti = os.GetObjects<cspraPonte>();

            
            //var ponti = os.GetObjects<cspraPonte>(new BinaryOperator(nameof(cspraPonte.EVE_ID), 20404));

            foreach (var item in ponti)
            {
                try
                {
                    var ponte = Import<Ponte>(os, item.EVE_ID, TipoPosizione.Coordinate);
                    var cPonte = os.GetObjectByKey<cspraPonte>(item.EVE_ID);
                    ponte.Illuminazione = (cPonte.ILLUMINAZIONE.ENUM_VAL == "1");
                    ponte.StatoConservazione = GetOrCreateDomain<TipoStatoConservazione>(os, cPonte.STATO_MANUT);
                    ponte.TipoElementoAttraversato = GetOrCreateDomain<TipoElementoAttraversato>(os, cPonte.EL_ATTRAVERSATO);
                    ponte.TipoMateriale = GetOrCreateDomain<TipoMateriale>(os, cPonte.TIPO_MAT_IMP);
                    ponte.TipoOpera = GetOrCreateDomain<TipoOpera>(os, cPonte.TIPO);
                    ponte.TipoPila = GetOrCreateDomain<TipoMateriale>(os, cPonte.TIPO_MAT_PILA);
                    ponte.TipoSpalla = GetOrCreateDomain<TipoMateriale>(os, cPonte.TIPO_MAT_SPALLA);
                    ponte.TipoSchemaStatico = GetOrCreateDomain<TipoSchemaStatico>(os, cPonte.SCHEMA_STATICO);
                    os.CommitChanges();
                }
                catch
                {
                    os.Rollback();
                }
            }
        }


        private static T Import<T>(IObjectSpace os, int eve_id, TipoPosizione tipoLocalizzazione)
            where T : IEventoOnRoad
        {
            //var ev = os.FindObject<cspraEvento>(new BinaryOperator(nameof(cspraEvento.EVE_ID), eve_id));
            //var eor = os.FindObject<cspraEventoOnRoad>(new BinaryOperator(nameof(cspraEventoOnRoad.EVE_ID), ev.EVE_ID));
            var ev = os.GetObjectByKey<cspraEvento>(eve_id);
            var eor = os.GetObjectByKey<cspraEventoOnRoad>(eve_id);
            var sigla = eor.ROAD_ID.SIGLA;
            var rd = os.FindObject<Strada>(new BinaryOperator(nameof(Strada.Sigla), sigla));
            var t = os.FindObject<T>(new BinaryOperator(nameof(IEvento.Event_id), eve_id));
            if (t == null)
                t = os.CreateObject<T>();
            t.Event_id = eve_id;
            t.Strada = rd;
            t.M = eor.F_MEVENTS;
            t.X = ev.F_XEVENTS;
            t.Y = ev.F_YEVENTS;
            t.Z = ev.F_ZEVENTS;
            t.Offset = eor.E_OFFSET;
            t.Tipo = tipoLocalizzazione;

            if (t.GetType().IsSubclassOf(typeof(EventoLineare)))
            {
                var line = os.FindObject<CSPRA_RDSEVENTSPOLYLINES>(new BinaryOperator(nameof(CSPRA_RDSEVENTSPOLYLINES.ID_EVE), ev.EVE_ID));
                if (line != null)
                {
                    //Dimensione massima dell'oggetto geometry pari a 10MB
                    //https://www.vertica.com/docs/9.2.x/HTML/Content/Authoring/SQLReferenceManual/Functions/Geospatial/ST_GeomFromWKB.htm
                    //https://forums.oracle.com/ords/apexds/post/error-code-ora-01461-while-inserting-geometry-column-4251


                    t.Shape = line.Shape;
                    //if (line.Shape.ToBinary().Length < 4096)
                    //{
                    //    t.Shape = line.Shape;
                    //}
                    //else
                    //{
                    //    throw new UserFriendlyException($"Shape Lenght {line.Shape.ToBinary().Length} exceed maximum lenght. Event_id = {eve_id}.");
                    //}
                }
                var tLin = t as EventoLineare;
                tLin.MFine = eor.T_MEVENTS;
                tLin.XFine = ev.T_XEVENTS;
                tLin.YFine = ev.T_YEVENTS;
                tLin.ZFine = ev.T_ZEVENTS;
                tLin.Km = RoutingHelper.GetChilometricaFromMeasure(rd, tLin.M);
                tLin.KmFine = RoutingHelper.GetChilometricaFromMeasure(rd,tLin.MFine);
                RoutingHelper.UpdateLineCoordinate(tLin);
            }
            else
            {
                var point = os.FindObject<CSPRA_RDSEVENTSPOINTS>(new BinaryOperator(nameof(CSPRA_RDSEVENTSPOINTS.ID_EVE), ev.EVE_ID));
                if (point != null)
                {
                    if (point.Shape.ToBinary().Length < 4096)
                        t.Shape = point.Shape;
                    else
                        throw new UserFriendlyException($"Shape Lenght {point.Shape.ToBinary().Length} exceed maximum lenght. Event_id = {eve_id}.");
                }

                var tPoint = t as EventoPuntuale;
                tPoint.Km = RoutingHelper.GetChilometricaFromMeasure(rd,tPoint.M);
                RoutingHelper.UpdatePointCoordinate(tPoint);
            }
            return t;
        }


        private static T GetOrCreateDomain<T>(IObjectSpace os,cspraEnum en)
            where T:ICodedDomain
        {
            var info = os.TypesInfo.FindTypeInfo(typeof(T));
            var key = System.Convert.ChangeType(en.ENUM_VAL.Trim(), info.KeyMember.MemberType);
            T t = os.FindObject<T>(new BinaryOperator(info.KeyMember.Name, key), true);
            //T t = os.GetObjectByKey<T>(key);
            if (t == null)
            {
                t = os.CreateObject<T>();
                t.Codice = key;
                t.Descrizione = en.ENUM_DESC?.Trim();
                foreach (var item in os.GetObjects<cspraEnum>(new BinaryOperator(nameof(cspraEnum.ENUM_DOM),en.ENUM_DOM?.Trim())))
                {
                    if (item != en)
                        GetOrCreate<T>(os, item);
                }
            }
            return t;
        }

        private static T GetOrCreate<T>(IObjectSpace os, cspraEnum en)
            where T : ICodedDomain
        {
            var info = os.TypesInfo.FindTypeInfo(typeof(T));
            var key = System.Convert.ChangeType(en.ENUM_VAL?.Trim(), info.KeyMember.MemberType);
            T t = os.FindObject<T>(new BinaryOperator(info.KeyMember.Name, key), true);
            //T t = os.GetObjectByKey<T>(key);
            if (t == null)
            {
                t = os.CreateObject<T>();
                t.Codice = key;
                t.Descrizione = en.ENUM_DESC?.Trim();
            }
            return t;
        }

    }
}
