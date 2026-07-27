using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;
using System.IO;
using DevExpress.ExpressApp.Utils;
using Microsoft.AspNetCore.StaticFiles;
namespace xRoadMap.Module.BusinessObjects
{
    [DefaultProperty(nameof(FileName))]
    [FileAttachment(nameof(File))]
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NonPersistent]
    public abstract partial class Allegato: XPCustomObject,IFileData
    {
        public Allegato(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public virtual void LoadFromStream(string fileName, Stream stream)
        {
            Guard.ArgumentNotNull(stream, "stream");
            FileName = fileName;
            byte[] bytes = new byte[stream.Length];
            stream.ReadExactly(bytes);

            Content = bytes;
            var provider = new FileExtensionContentTypeProvider();

            if (provider.TryGetContentType(fileName, out var contentType))
            {
                Content_Type = contentType;
            }
            else
            {
                Content_Type = "application/octet-stream";
            }
        }
        public virtual void SaveToStream(Stream stream)
        {
            if (Content != null)
            {
                stream.Write(Content, 0, Size);
            }
            stream.Flush();
        }
        public void Clear()
        {
            Content = null;
            FileName = String.Empty;
        }
        public override string ToString()
        {
            return FileName;
        }

        [Persistent("DATA"), Delayed(true)]
        //[ValueConverter(typeof(CompressionConverter))]
        [MemberDesignTimeVisibility(false)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] Content
        {
            get { return GetDelayedPropertyValue<byte[]>(nameof(Content)); }
            set
            {
                int oldSize = fSize;
                if (value != null)
                {
                    fSize = value.Length;
                }
                else
                {
                    fSize = 0;
                }
                SetDelayedPropertyValue(nameof(Content), value);
                OnChanged(nameof(Size), oldSize, fSize);
            }
        }

        int fOid;
        [Key(true)]
        [Persistent(@"ATTACHMENTID")]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        string fContent_Type;
        [Persistent(@"CONTENT_TYPE")]
        public string Content_Type
        {
            get { return fContent_Type; }
            set { SetPropertyValue<string>(nameof(Content_Type), ref fContent_Type, value); }
        }
        string fFileName;
        [Persistent(@"ATT_NAME")]
        public string FileName
        {
            get { return fFileName; }
            set { SetPropertyValue<string>(nameof(FileName), ref fFileName, value); }
        }
        int fSize;
        [Persistent(@"DATA_SIZE")]
        public int Size
        {
            get { return fSize; }
            set { SetPropertyValue<int>(nameof(Size), ref fSize, value); }
        }

        public IFileData File
        {
            get => this;
            set {
                ;
            }
        }

        
    }

}
