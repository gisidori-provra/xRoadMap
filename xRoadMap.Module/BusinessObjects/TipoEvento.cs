using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects.RoadDataModel
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [DefaultProperty(nameof(Codice))]
    public class TipoEvento:XPLiteObject
    {
        public TipoEvento(Session session):base(session)
        {

        }
        private int oid;
        [Key(AutoGenerate = true), Browsable(false), DbType("int"), Persistent("OBJECTID")]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue<int>(nameof(Oid), ref oid, value);
        }

        string codice;
        [RuleUniqueValue]
        public string Codice
        {
            get => codice;
            set => SetPropertyValue(nameof(Codice), ref codice, value);
        }

        string descrizione;
        public string Descrizione
        {
            get => descrizione;
            set => SetPropertyValue(nameof(Descrizione), ref descrizione, value);
        }


    }
}
