using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using System;

namespace DevExpress.Xpo
{
    public static class SessionExtensions
    {

        public static object GetObjectByCode(this Session session, Type objType, object codice, string propertyName = "Codice", string criteria = null, PersistentCriteriaEvaluationBehavior persistentCriteriaEvaluationBehavior = PersistentCriteriaEvaluationBehavior.InTransaction, params string[] sortProperties)
        {
            var res = GetObjectsByCode(session, objType, codice, propertyName, criteria, persistentCriteriaEvaluationBehavior, sortProperties);
            if (res.Count == 0)
                return null;
            return res[0];
        }

        public static T GetObjectByCode<T>(this Session session, object codice, string propertyName = "Codice", string criteria = null, PersistentCriteriaEvaluationBehavior persistentCriteriaEvaluationBehavior = PersistentCriteriaEvaluationBehavior.InTransaction, params string[] sortProperties)
            where T : class
        {
            var res = GetObjectsByCode<T>(session, codice, propertyName, criteria, persistentCriteriaEvaluationBehavior, sortProperties);
            if (res.Count == 0)
                return null;
            return res[0];
        }

        public static System.Collections.IList GetObjectsByCode(this Session session, Type objType, object codice, string propertyName = "Codice", string criteria = null, PersistentCriteriaEvaluationBehavior persistentCriteriaEvaluationBehavior = PersistentCriteriaEvaluationBehavior.InTransaction, params string[] sortProperties)
        {
            CriteriaOperator crit = new BinaryOperator(propertyName, codice);
            if (criteria != null)
                crit = CriteriaOperator.And(crit, CriteriaOperator.Parse(criteria));
            var coll = new XPCollection(persistentCriteriaEvaluationBehavior, session, objType, crit);
            if (sortProperties != null)
            {
                foreach (var sortProperty in sortProperties)
                {
                    coll.Sorting.Add(new SortProperty(sortProperty, DB.SortingDirection.Descending));
                }
            }
            return coll;
        }

        public static System.Collections.Generic.IList<T> GetObjectsByCode<T>(this Session session, object codice, string propertyName = "Codice", string criteria = null, PersistentCriteriaEvaluationBehavior persistentCriteriaEvaluationBehavior = PersistentCriteriaEvaluationBehavior.InTransaction, params string[] sortProperties)
        {
            CriteriaOperator crit = new BinaryOperator(propertyName, codice);
            if (criteria != null)
                crit = CriteriaOperator.And(crit, CriteriaOperator.Parse(criteria));
            var coll = new XPCollection<T>(persistentCriteriaEvaluationBehavior, session, crit);
            if (sortProperties != null)
            {
                foreach (var sortProperty in sortProperties)
                {
                    coll.Sorting.Add(new SortProperty(sortProperty, DB.SortingDirection.Descending));
                }
            }
            return coll;
        }

        public static object GetObjectByCode(this IObjectSpace os, Type objType, object codice, string propertyName = "Codice", string criteria = null, bool inTransaction = true, params string[] sortProperties)
        {
            var res = GetObjectsByCode(os, objType, codice, propertyName, criteria, inTransaction, sortProperties);
            if (res.Count == 0)
                return null;
            return res[0];
        }

        public static System.Collections.IList GetObjectsByCode(this IObjectSpace os, Type objType, object codice, string propertyName = "Codice", string criteria = null, bool inTransaction = true, params string[] sortProperties)
        {
            CriteriaOperator crit = new BinaryOperator(propertyName, codice);
            if (criteria != null)
                crit = CriteriaOperator.And(crit, CriteriaOperator.Parse(criteria));
            System.Collections.Generic.List<SortProperty> sorting = new System.Collections.Generic.List<SortProperty>();
            if (sortProperties != null)
            {
                foreach (var sortProperty in sortProperties)
                {
                    sorting.Add(new SortProperty(sortProperty, DB.SortingDirection.Descending));
                }
            }
            return os.GetObjects(objType, crit, sorting, inTransaction);
        }

        public static System.Collections.Generic.IList<T> GetObjectsByCode<T>(this IObjectSpace os, object codice, string propertyName = "Codice", string criteria = null, bool inTransaction = true, params string[] sortProperties)
        {
            CriteriaOperator crit = new BinaryOperator(propertyName, codice);
            if (criteria != null)
                crit = CriteriaOperator.And(crit, CriteriaOperator.Parse(criteria));
            System.Collections.Generic.List<SortProperty> sorting = new System.Collections.Generic.List<SortProperty>();
            if (sortProperties != null)
            {
                foreach (var sortProperty in sortProperties)
                {
                    sorting.Add(new SortProperty(sortProperty, DB.SortingDirection.Descending));
                }
            }
            return os.GetObjects<T>(crit, sorting, inTransaction);
        }

        public static T GetObjectByCode<T>(this IObjectSpace os, object codice, string propertyName = "Codice", string criteria = null, bool inTransaction = true, params string[] sortProperties)
            where T : class
        {
            var res = GetObjectsByCode<T>(os, codice, propertyName, criteria, inTransaction, sortProperties);
            if (res.Count == 0)
                return null;
            return res[0];
        }

        public static T GetOrCreateObjectByCode<T>(this Session session, object codice, string propertyName = "Codice", string criteria = null, PersistentCriteriaEvaluationBehavior criteriaEvaluationBehavior = PersistentCriteriaEvaluationBehavior.InTransaction, params string[] sortProperties)
            where T : XPBaseObject
        {
            T obj = GetObjectByCode<T>(session, codice, criteria: criteria, propertyName: propertyName, persistentCriteriaEvaluationBehavior: criteriaEvaluationBehavior, sortProperties: sortProperties);
            if (obj == null)
            {
                DevExpress.Xpo.Metadata.XPClassInfo i = session.GetClassInfo<T>();
                obj = (T)i.CreateNewObject(session);
            }
            obj.SetMemberValue(propertyName, codice);
            return obj;
        }

        public static T GetObjectByCode<T>(this Session session, string codice, string propertyName = "Codice", string criteria = null, PersistentCriteriaEvaluationBehavior persistentCriteriaEvaluationBehavior = PersistentCriteriaEvaluationBehavior.InTransaction, params string[] sortProperties)
            where T : class
        {
            CriteriaOperator crit = new BinaryOperator(propertyName, codice);
            if (criteria != null)
                crit = CriteriaOperator.And(crit, CriteriaOperator.Parse(criteria));

            var res = new XPCollection<T>(persistentCriteriaEvaluationBehavior, session, crit);
            if (sortProperties != null)
            {
                foreach (var sortProperty in sortProperties)
                {
                    res.Sorting.Add(new SortProperty(sortProperty, DB.SortingDirection.Descending));
                }
            }

            if (res.Count == 0)
                return null;
            return res[0];

        }

        public static String GetObjectHandle(this Session session, Object obj)
        {
            var ci = session.GetClassInfo(obj);
            return $"{ci.FullName}({session.GetKeyValue(obj)})";
        }

        public static Object GetObjectByHandle(this Session session, string handle)
        {
            Type type;
            string key;
            if (TryParseObjectHandle(session, handle, out type, out key))
            {
                return session.GetObjectByKey(type, GetObjectKeyFromString(session, type, key));
            }
            return null;
        }

        public static Object GetObjectKeyFromString(this Session session, Type objectType, String objectKeyString)
        {
            Object result = null;
            var ci = session.GetClassInfo(objectType);
            Type keyPropertyType = ci.KeyProperty.MemberType;
            if (keyPropertyType == typeof(Int16))
            {
                Int16 val = 0;
                Int16.TryParse(objectKeyString, out val);
                result = val;
            }
            else if (keyPropertyType == typeof(Int32))
            {
                Int32 val = 0;
                Int32.TryParse(objectKeyString, out val);
                result = val;
            }
            else if (keyPropertyType == typeof(Int64))
            {
                Int64 val = 0;
                Int64.TryParse(objectKeyString, out val);
                result = val;
            }
            else if (keyPropertyType == typeof(Decimal))
            {
                Decimal val = 0;
                Decimal.TryParse(objectKeyString, out val);
                result = val;
            }
            else if (keyPropertyType == typeof(Guid))
            {
                result = new Guid(objectKeyString);
            }
            else if (keyPropertyType == typeof(String))
            {
                result = objectKeyString;
            }
            else if (keyPropertyType == typeof(Byte))
            {
                Byte val = 0;
                Byte.TryParse(objectKeyString, out val);
                result = val;
            }
            else if (keyPropertyType == typeof(SByte))
            {
                SByte val = 0;
                SByte.TryParse(objectKeyString, out val);
                result = val;
            }
            else if (keyPropertyType == typeof(UInt16))
            {
                UInt16 val = 0;
                UInt16.TryParse(objectKeyString, out val);
                result = val;
            }
            else if (keyPropertyType == typeof(UInt32))
            {
                UInt32 val = 0;
                UInt32.TryParse(objectKeyString, out val);
                result = val;
            }
            else if (keyPropertyType == typeof(UInt64))
            {
                UInt64 val = 0;
                UInt64.TryParse(objectKeyString, out val);
                result = val;
            }
            else if (keyPropertyType == BaseObjectSpace.CompositeKeyPropertyType)
            {
                result = ObjectKeyHelper.Instance.DeserializeObjectKey(objectKeyString, typeof(System.Collections.Generic.List<Object>));
            }
            return result;
        }

        private static bool TryParseObjectHandle(this Session session, String handle, out Type objectType, out String objectKeyAsString)
        {
            objectType = null;
            objectKeyAsString = null;
            if (String.IsNullOrEmpty(handle))
            {
                return false;
            }
            Int32 separatorIndex = handle.IndexOf('(');
            if ((separatorIndex <= 0) || (separatorIndex > handle.Length - 2))
            {
                return false;
            }
            String objectTypeFullName = handle.Substring(0, separatorIndex);
            objectType = GetObjectType(session, objectTypeFullName);
            objectKeyAsString = handle.Substring(objectTypeFullName.Length + 1, handle.Length - objectTypeFullName.Length - 2);
            return objectType != null;
        }

        public static Type GetObjectType(this Session session, string objectTypeFullName)
        {
            foreach (DevExpress.Xpo.Metadata.XPClassInfo cl in session.Dictionary.Classes)
            {
                if (cl.FullName == objectTypeFullName)
                {
                    return cl.ClassType;
                }
            }
            return null;
        }

        public static T Clona<T>(this T sourceObject)
        {
            DevExpress.Persistent.Base.Cloner cloner = new DevExpress.Persistent.Base.Cloner();
            var copia = cloner.CloneTo(sourceObject, typeof(T));
            return (T)copia;

        }

        public static object Clona(this XPBaseObject sourceObject, Type targetType)
        {
            //DevExpress.Persistent.Base.Cloner cloner = new DevExpress.Persistent.Base.Cloner();
            //var copia = cloner.CloneTo(sourceObject, targetType);
            //return copia;
            var session = sourceObject.Session;
            return Clona(sourceObject, session.GetClassInfo(targetType));
        }

        public static object Clona(this XPBaseObject sourceObject, Metadata.XPClassInfo targetInfo)
        {
            var session = sourceObject.Session;
            if (sourceObject.IsDeleted == false)
            {
                var copia = targetInfo.CreateObject(session) as XPBaseObject;
                CopyFrom(copia, sourceObject);
                return copia;
            }
            return null;
        }

        public static void CopyFrom<T>(this T target, object source, bool overwrite = true)
            where T : XPBaseObject
        {
            Session session = target.Session;
            Metadata.XPClassInfo sourceType = session.GetClassInfo(source);
            Metadata.XPClassInfo targetType = session.GetClassInfo(target);


            foreach (Metadata.XPMemberInfo mi in sourceType.PersistentProperties)
            {
                if (mi.Name.ToLower() == "GCRecord".ToLower())
                    continue;

                if (mi.Name.ToLower() == "OptimisticLockField".ToLower())
                    continue;

                Metadata.XPMemberInfo targetMember = targetType.FindMember(mi.Name);
                if (mi.IsPersistent && targetMember != null && mi.HasAttribute(typeof(DevExpress.Persistent.Base.NonCloneableAttribute)) == false && mi.HasAttribute(typeof(DevExpress.Xpo.KeyAttribute)) == false)
                {
                    var sourceProp = sourceType.ClassType.GetProperty(mi.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly);
                    if (sourceProp == null)
                        sourceProp = sourceType.ClassType.GetProperty(mi.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    if (sourceProp == null)
                        continue;

                    var targetProp = targetType.ClassType.GetProperty(mi.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly);
                    if (targetProp == null)
                        targetProp = targetType.ClassType.GetProperty(mi.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    if (targetProp == null)
                        continue;

                    var sourceValue = sourceProp.GetValue(source);  // mi.GetValue(source);
                    var targetValue = targetProp.GetValue(target);

                    if (sourceValue is XPBaseObject bo && mi.IsAggregated)
                    {
                        if (overwrite || targetValue == null)
                            targetMember.SetValue(target, bo.Clona(mi.ReferenceType));
                        else
                            ((XPBaseObject)targetValue).CopyFrom(bo, false);
                    }
                    else
                    {
                        if (overwrite || targetValue == GetDefaultForType(mi.MemberType))
                            targetMember.SetValue(target, sourceValue);
                    }
                }
            }

            object GetDefaultForType(Type t)
            {
                if (t.IsValueType && Nullable.GetUnderlyingType(t) == null)
                    return Activator.CreateInstance(t);
                return null;
            }
        }

    }
}

