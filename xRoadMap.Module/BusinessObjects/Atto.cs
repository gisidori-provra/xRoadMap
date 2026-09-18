using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace xRoadMap.Module.BusinessObjects
{

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [DefaultProperty(nameof(Titolo))]
    [FileAttachment(nameof(FileData))]
    public partial class Atto : XPCustomObject
    {
        public Atto(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [VisibleInListView(true),VisibleInDetailView(false)]
        public string Titolo => $"{this.Tipo?.Descrizione} nr {this.Numero} del {this.Data:d}";

        int fOid;
        [Key(true)]
        [Persistent(@"OBJECTID")]
        [System.ComponentModel.Browsable(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        TipoAtto fTipo;
        public TipoAtto Tipo
        {
            get { return fTipo; }
            set { SetPropertyValue<TipoAtto>(nameof(Tipo), ref fTipo, value); }
        }
        DateTime fData;
        public DateTime Data
        {
            get { return fData; }
            set { SetPropertyValue<DateTime>(nameof(Data), ref fData, value); }
        }
        string fNumero;
        public string Numero
        {
            get { return fNumero; }
            set { SetPropertyValue<string>(nameof(Numero), ref fNumero, value); }
        }
        FileData fFileData;
        [System.ComponentModel.DisplayName("File")]
        public FileData FileData
        {
            get { return fFileData; }
            set { SetPropertyValue(nameof(FileData), ref fFileData, value); }
        }
    }
}
