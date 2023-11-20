using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects.cspra
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [Persistent(@"CSPRA.EVE_OPERA_SOST")]
    public class cspraOperaSostegno:XPCustomObject
    {
        public cspraOperaSostegno(Session session):base(session)
        {

        }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }

        cspraEnum tipo;
        public cspraEnum Tipo
        {
            get { return tipo; }
            set { SetPropertyValue<cspraEnum>(nameof(Tipo), ref tipo, value); }
        }


        cspraEnum tipoCostr;
        [Persistent("TIPO_COSTR")]
        public cspraEnum TipoCostr
        {
            get { return tipoCostr; }
            set { SetPropertyValue<cspraEnum>(nameof(TipoCostr), ref tipoCostr, value); }
        }

        cspraEnum stato;
        public cspraEnum Stato
        {
            get { return stato; }
            set { SetPropertyValue<cspraEnum>(nameof(Stato), ref stato, value); }
        }




    }
}
