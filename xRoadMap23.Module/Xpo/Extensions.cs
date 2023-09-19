using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.Xpo
{
    public static class Extensions
    {
        public static XPMemberInfo GetNestedMemberInfo(this XPBaseObject o, string PropertyName)
        {
            if (PropertyName.Contains("."))
            {
                int i = PropertyName.IndexOf('.');
                string baseProp = PropertyName.Substring(0, i);
                object oBO = o.GetMemberValue(baseProp);
                if (oBO == null || !(oBO is XPBaseObject)) return null;
                string subProp = PropertyName.Substring(i + 1, PropertyName.Length - i - 1);
                return (o.GetMemberValue(baseProp) as XPBaseObject).GetNestedMemberInfo(subProp);
            }
            else 
                return o.ClassInfo.GetMember(PropertyName);
        }

        public static object GetNestedMemberValue(this XPBaseObject o, string PropertyName)
        {
            if (PropertyName.Contains("."))
            {
                int i = PropertyName.IndexOf('.');
                string baseProp = PropertyName.Substring(0, i);
                object oBO = o.GetMemberValue(baseProp);
                if (oBO == null || !(oBO is XPBaseObject)) return null;
                string subProp = PropertyName.Substring(i + 1, PropertyName.Length - i - 1);
                return (o.GetMemberValue(baseProp) as XPBaseObject).GetNestedMemberValue(subProp);
            }
            else return o.GetMemberValue(PropertyName);
        }
    }
}
