using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects
{

    public interface ICodedDomain
    {
        object Codice { get; set; }
        string Descrizione { get; set; }
    }

    [DeferredDeletion(false)]
    [OptimisticLocking(false)]
    [XafDefaultProperty(nameof(Descrizione))]
    public abstract class CodedValues<T> : XPCustomObject
    {
        public CodedValues(Session session) : base(session)
        {

        }

        private T codice;
        [Key, VisibleInListView(true)]
        public T Codice
        {
            get => codice;
            set => SetPropertyValue<T>(nameof(Codice), ref codice, value);
        }

        private string descrizione;
        [VisibleInListView(true)]
        public string Descrizione
        {
            get => descrizione;
            set => SetPropertyValue<string>(nameof(Descrizione), ref descrizione, value);
        }
    }

    
    [NonPersistent]
    [XafDefaultProperty(nameof(Descrizione))]
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    public abstract class CodedDomain<T> : XPCustomObject,ICodedDomain
    {
        public CodedDomain(Session session) : base(session)
        {
            if (tableName == null)
            {
                tableName = this.ClassInfo.TableName;
                object value = this.Session.ExecuteScalar($"SELECT REGISTRATION_ID FROM SDE.TABLE_REGISTRY WHERE Table_Name = '{tableName.ToUpper()}' AND OWNER = (SELECT sys_context('USERENV','CURRENT_SCHEMA') from dual) ");
                if (value == null)
                    regid = -1;
                else
                    regid = ((IConvertible)value).ToInt64(System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        private string tableName;
        private long regid;
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            if (Session.IsNewObject(this))
            {
                if (regid == -1)
                    this.OBJECTID = Convert.ToInt32(Session.EvaluateInTransaction(this.ClassInfo, CriteriaOperator.Parse("MAX(OBJECTID)"), null)) + 1;
                else
                    this.objectid = Convert.ToInt32(Session.ExecuteScalar($"SELECT R{regid}.NEXTVAL FROM DUAL"));
            }
            base.OnSaving();
        }

        private int objectid;
        //[Key(AutoGenerate = true)]
        [Browsable(false)]
        public int OBJECTID
        {
            get => objectid;
            set => SetPropertyValue(nameof(OBJECTID), ref objectid, value);
        }

        private T codice;
        [Key, VisibleInListView(true)]
        public T Codice
        {
            get => codice;
            set => SetPropertyValue<T>(nameof(Codice), ref codice, value);
        }

        private string descrizione;
        [VisibleInListView(true)]
        public string Descrizione
        {
            get => descrizione;
            set => SetPropertyValue<string>(nameof(Descrizione), ref descrizione, value);
        }
        object ICodedDomain.Codice { get => this.Codice; set => this.Codice = (T)value; }
    }

    [NonPersistent]
    [MemberDesignTimeVisibility(false)]
    public class StringCodedDomain:CodedDomain<string>
    {

        public StringCodedDomain(Session s):base(s)
        {

        }
    }

    [NonPersistent]
    [MemberDesignTimeVisibility(false)]
    public class ShortIntegerCodedDomain:CodedDomain<short>
    {
        public ShortIntegerCodedDomain(Session s):base(s)
        {

        }
    }


}
