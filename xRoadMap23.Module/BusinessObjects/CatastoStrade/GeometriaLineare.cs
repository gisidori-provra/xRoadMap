using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace xRoadMap.Module.BusinessObjects
{

    public partial class GeometriaLineare:XPSTGeometry
    {
        public GeometriaLineare() : base() { }
        public GeometriaLineare(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        int fEvento;
        public int Evento
        {
            get { return fEvento; }
            set { SetPropertyValue<int>(nameof(Evento), ref fEvento, value); }
        }
        int feve_id;
        [Indexed(Name = @"UXeve_id", Unique = true)]
        [MemberDesignTimeVisibility(false)]
        public int eve_id
        {
            get { return feve_id; }
            set { SetPropertyValue<int>(nameof(eve_id), ref feve_id, value); }
        }

        [Association, Aggregated]
        public XPCollection<AllegatoGeometriaLineare> Allegati => GetCollection<AllegatoGeometriaLineare>();



    }

}
