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
    [Persistent(@"CSPRA.EVEDISPRITENUTA")]
    public class cspraDispRitenuta:XPCustomObject
    {
        public cspraDispRitenuta(Session session):base(session)
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
            set { SetPropertyValue(nameof(Tipologia), ref tipologia, value); }
        }

        cspraEnum materiale;
        public cspraEnum Materiale
        {
            get { return materiale; }
            set { SetPropertyValue(nameof(Materiale), ref materiale, value); }
        }

        cspraEnum classificazione;
        [Persistent("CLASSIF")]
        public cspraEnum Classificazione
        {
            get { return classificazione; }
            set { SetPropertyValue(nameof(Classificazione), ref classificazione, value); }
        }

        double distanza;
        public double Distanza
        {
            get => distanza;
            set => SetPropertyValue(nameof(Distanza), ref distanza, value);
        }



    }
}
