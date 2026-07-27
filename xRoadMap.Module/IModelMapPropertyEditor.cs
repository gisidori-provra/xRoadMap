using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.XtraMap;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module
{

    public interface IModelMapOptions:IModelOptions
    {
        string BingKey { get; set; }
    }


    public interface IModelMap:IModelMapLayer
    {
        [Description("Visualizza toolbar nel controllo mappa")]
        [Category("Map")]
        [ModelBrowsable(typeof(IsMapCalculator))]
        bool ShowToolbar { get; set; }

        [Description("Elenco layers")]
        [Category("Map")]
        [ModelBrowsable(typeof(IsMapCalculator))]
        IModelMapLayers MapLayers { get; }
    }

    public interface IModelMapListView :IModelListView, IModelMap
    {
    }

    public interface IModelMapPropertyEditor:IModelMap
    {
    }

    public enum LayerType
    {
        VectorLayer,
        WMSLayer,
        [Obsolete("BingMapLayer is deprecated. Use other map layers instead.")]
        BingMapLayer,
        InformationLayer,
        OpenStreetMap,
        ArcGisImagery
    }

    [Description("Descrive le proprietà del layer.")]
    public interface IModelMapLayer:IModelNode
    {
        string Titolo { get; set; }
        [Category("Map")]
        LayerType LayerType { get; set; }
        [Category("Map")]
        string LayerName { get; set; }
        [Category("Map")]
        string Uri { get; set; }
        [Category("Map")]
        [DefaultValue(true)]
        bool Visible { get; set; }
        [Category("Map")]
        string DataSourceProperty { get; set; }
        [Category("Map")]
        FontStyle? FontStyle { get; set; }
        [Category("Map")]
        Color? FillColor { get; set; }
        [Category("Map")]
        Color? StrokeColor { get; set; }
        [Category("Map")]
        Color? TextColor { get; set; }
        [Category("Map")]
        Color? TextGlowColor { get; set; }
        [Category("Map")]
        int? StrokeWidth { get; set; }
        [Category("Map")]
        int? Transparency { get; set; }

        [Category("Map")]
        BusinessObjects.VisibilityMode TitleVisible { get; set; }

        [Description("Attributo usato per la etichetta")]
        [Category("Map")]
        string Pattern { get; set; }

        [Category("Map")]
        ColorizerType ColorizerType { get; set; }
    
        [Category("Map")]
        [Description("Attributo utilizzato per la simbologia (colorized)")]
        string AttributeName { get; set; }

        [Category("Map")]
        [DefaultValue(BusinessObjects.VisibilityMode.Auto)]
        BusinessObjects.VisibilityMode TOCVisibility { get; set; }

    }

    public enum ColorizerType
    {
        None,
        Cloropleth,
        Graph,
        KeyColor
    }

    public interface IModelMapLayers : IModelNode, IModelList<IModelMapLayer>
    {
        
    }

    public class IsMapCalculator : VisibilityCalculatorBase, IModelIsVisible
    {
        public bool IsVisible(IModelNode node, String propertyName)
        {
            if (node is IModelMemberViewItem mm)
                return mm.ModelMember.MemberInfo.MemberType == typeof(Geometry) || mm.ModelMember.MemberInfo.MemberTypeInfo.ImplementedInterfaces.Any(i=>i.Type == typeof(IXPGeometry));       // .ImplementedInterfaces.Any(i=>i.Type == typeof(IXPGeometry));
            if (node is IModelObjectView ml)
                return ml.ModelClass.TypeInfo.ImplementedInterfaces.Any(i => i.Type == typeof(IXPGeometry));
            return false;
        }
    }
}
