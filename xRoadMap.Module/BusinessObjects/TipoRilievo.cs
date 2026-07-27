using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace xRoadMap.Module.BusinessObjects
{
    public class TipoRilievo: CodedValues<int>
    {

        public TipoRilievo(Session session):base(session)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

    }
}
