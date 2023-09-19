using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [DefaultProperty(nameof(Codice))]
    public class TipoSegnalazione:XPCustomObject
    {
        public TipoSegnalazione(Session session):base(session)
        {

        }
        private int oid;
        [Key(true), VisibleInListView(false)]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue(nameof(Oid), ref oid, value);
        }
        private string codice;
        public string Codice
        {
            get => codice;
            set => SetPropertyValue(nameof(Codice), ref codice, value);
        }

        private string descrizione;
        [VisibleInListView(true)]
        public string Descrizione
        {
            get => descrizione;
            set => SetPropertyValue<string>(nameof(Descrizione), ref descrizione, value);
        }
    }
}
