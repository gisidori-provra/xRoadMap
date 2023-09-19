using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using xRoadMap.Module.BusinessObjects.cspra;
using xRoadMap.Module.BusinessObjects;
using System.Runtime.InteropServices;


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
                    var cAccesso = os.GetObjectByKey<cspraAccessi>(item.EVE_ID);
                    acc.Destinazione = GetOrCreateDomain<TipoDestinazioneAccesso>(os, cAccesso.Destinazione);
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


                    if (line.Shape.ToBinary().Length < 4096)
                    {
                        t.Shape = line.Shape;
                    }
                    else
                    {
                        throw new UserFriendlyException($"Shape Lenght {line.Shape.ToBinary().Length} exceed maximum lenght. Event_id = {eve_id}.");
                    }
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
