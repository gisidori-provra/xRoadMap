using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;


namespace xRoadMap.Module {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    public sealed partial class xRoadMap23Module : ModuleBase {
        public xRoadMap23Module() {
            InitializeComponent();
            
            xRoadMap.Xpo.OracleSDEConnectionProvider.Register();

            //https://github.com/NetTopologySuite/NetTopologySuite/issues/573

            NetTopologySuite.NtsGeometryServices.Instance = new NetTopologySuite.NtsGeometryServices(
                // default CoordinateSequenceFactory
                NetTopologySuite.Geometries.Implementation.CoordinateArraySequenceFactory.Instance,
                // default precision model
                new NetTopologySuite.Geometries.PrecisionModel(1000d),
                // default SRID
                25832,
                /********************************************************************
                 * Note: the following arguments are only valid for NTS >= v2.2
                 ********************************************************************/
                // Geometry overlay operation function set to use (Legacy or NG)
                NetTopologySuite.Geometries.GeometryOverlay.NG,
                // Coordinate equality comparer to use (CoordinateEqualityComparer or PerOrdinateEqualityComparer)
                new NetTopologySuite.Geometries.CoordinateEqualityComparer());

            var some_factory_that_I_may_or_may_not_use =
                NetTopologySuite.Geometries.GeometryFactory.Default;

        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }

        public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
        {
            extenders.Add<IModelPropertyEditor, IModelMapPropertyEditor>();
            extenders.Add<IModelListView, IModelMapListView>();
            extenders.Add<IModelOptions, IModelMapOptions>();
            base.ExtendModelInterfaces(extenders);
        }
    }
}
