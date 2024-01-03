using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects
{
    [ImageName("BO_FileAttachment")]
    public class Documento:DevExpress.Persistent.BaseImpl.FileAttachmentBase
    {

        public Documento(Session session):base(session)
        {
                
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.UtenteCreatore = Session.GetObjectByKey<PermissionPolicyUser>(DevExpress.ExpressApp.SecuritySystem.CurrentUserId);
            this.DataCreazione = DateTime.Now;
        }
        EventoLineare eventoLineare;
        [Association]
        public EventoLineare Evento
        {
            get => eventoLineare;
            set => SetPropertyValue(nameof(Evento),ref eventoLineare,value);
        }


        PermissionPolicyUser utenteCreatore;
        [ModelDefault("AllowEdit","False")]
        public PermissionPolicyUser UtenteCreatore
        {
            get => utenteCreatore;
            set => SetPropertyValue(nameof(UtenteCreatore),ref utenteCreatore,value);
        }

        DateTime dataCreazione;
        [ModelDefault("AllowEdit", "False")]
        public DateTime DataCreazione
        {
            get => dataCreazione;
            set => SetPropertyValue(nameof(DataCreazione),ref dataCreazione,value); 
        }
    }
}
