using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects
{
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni")]
    public class Comune : XPCustomObject
    {
        public Comune(Session session) : base(session)
        { }

        [Key]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CodiceIstat
        {
            get => codiceIstat;
            set => SetPropertyValue(nameof(CodiceIstat), ref codiceIstat, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nome
        {
            get => nome;
            set => SetPropertyValue(nameof(Nome), ref nome, value);
        }

        
        public Provincia Provincia
        {
            get => provincia;
            set => SetPropertyValue(nameof(Provincia), ref provincia, value);
        }

        Provincia provincia;
        string codiceIstat;
        string nome;

    }

    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni")]
    public class Provincia : XPCustomObject
    {
        public Provincia(Session session) : base(session)
        { }

        [Key]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CodiceIstat
        {
            get => codiceIstat;
            set => SetPropertyValue(nameof(CodiceIstat), ref codiceIstat, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nome
        {
            get => nome;
            set => SetPropertyValue(nameof(Nome), ref nome, value);
        }

        
        public Regione Regione
        {
            get => regione;
            set => SetPropertyValue(nameof(Regione), ref regione, value);
        }
        Regione regione;
        string codiceIstat;
        string nome;
    }

    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni")]
    public class Regione : XPCustomObject
    {
        public Regione(Session session) : base(session)
        { }


        string nome;
        string codiceIstat;

        [Key]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CodiceIstat
        {
            get => codiceIstat;
            set => SetPropertyValue(nameof(CodiceIstat), ref codiceIstat, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nome
        {
            get => nome;
            set => SetPropertyValue(nameof(Nome), ref nome, value);
        }

    }
}
