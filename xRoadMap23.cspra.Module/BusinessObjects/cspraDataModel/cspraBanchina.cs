using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects.cspra;

namespace xRoadMap.cspra.Module.Module.BusinessObjects.cspra
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [Persistent(@"CSPRA.EVE_BANCHINE")]
    public partial class cspraBanchina: XPCustomObject
    {
        public cspraBanchina(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }
        cspraEnum fTipoSuperficie;
        [Persistent("TIPO_SUPERFICIE")]
        public cspraEnum TipoSuperficie
        {
            get { return fTipoSuperficie; }
            set { SetPropertyValue(nameof(TipoSuperficie), ref fTipoSuperficie, value); }
        }

        cspraEnum fTipoPav;
        [Persistent("TIPO_PAV")]
        public cspraEnum TipoPav
        {
            get => fTipoPav;
            set => SetPropertyValue(nameof(TipoPav), ref fTipoPav, value);
        }



        int fLarghezza;
        public int Larghezza
        {
            get => fLarghezza;
            set => SetPropertyValue(nameof(Larghezza), ref fLarghezza, value);
        }

    }
}
