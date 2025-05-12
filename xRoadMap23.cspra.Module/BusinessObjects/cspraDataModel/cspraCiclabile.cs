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
    [Persistent(@"CSPRA.EVECICLABILI")]
    public class cspraCiclabile:XPCustomObject
    {
        public cspraCiclabile(Session session):base(session)
        {

        }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }

        cspraEnum tipologia;
        public cspraEnum Tipologia
        {
            get { return tipologia; }
            set { SetPropertyValue<cspraEnum>(nameof(Tipologia), ref tipologia, value); }
        }

        cspraEnum senso;
        public cspraEnum Senso
        {
            get => senso;
            set => SetPropertyValue(nameof(Senso), ref senso, value);   
        }

        double larghezza;
        [Persistent("LARGH")]
        public double Larghezza
        {
            get => larghezza;
            set => SetPropertyValue(nameof(Larghezza), ref larghezza, value);   
        }

        double lunghezza;
        [Persistent("LUNGH")]
        public double Lunghezza
        {
            get => lunghezza;
            set => SetPropertyValue(nameof(Lunghezza), ref lunghezza, value);   
        }

    }
}
