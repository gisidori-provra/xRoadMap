using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace xRoadMap.Module.BusinessObjects
{

    [Persistent(@"EV_SegnalazionePuntuale")]
    [DefaultProperty(nameof(Descrizione))]
    public partial class SegnalazionePuntuale : EventoPuntuale
    {
        public SegnalazionePuntuale(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string fDescrizione;
        [Size(SizeAttribute.Unlimited)]
        public string Descrizione
        {
            get { return fDescrizione; }
            set { SetPropertyValue<string>(nameof(Descrizione), ref fDescrizione, value); }
        }

        TipoSegnalazione tipoSegnalazione;
        public TipoSegnalazione TipoSegnalazione
        {
            get => tipoSegnalazione;
            set => SetPropertyValue(nameof(TipoSegnalazione), ref tipoSegnalazione, value);
        }

    }

}
