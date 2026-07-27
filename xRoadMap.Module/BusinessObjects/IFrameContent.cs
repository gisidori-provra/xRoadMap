using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects
{

    [DomainComponent]
    public class IFrameContent : DevExpress.ExpressApp.NonPersistentBaseObject
    {
        string iframe;

        [FieldSize(FieldSizeAttribute.Unlimited)]
        public string IFrame
        {
            get => iframe;
            set => SetPropertyValue(ref iframe, value);
        }
    }
}
