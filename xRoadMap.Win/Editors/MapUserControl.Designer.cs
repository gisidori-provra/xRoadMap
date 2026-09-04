namespace xRoadMap.Module.Win.Editors
{
    partial class MapUserControl
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapUserControl));
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase1 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement1 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement2 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            dockManager = new DevExpress.XtraBars.Docking.DockManager(components);
            dockPanelStreetView = new DevExpress.XtraBars.Docking.DockPanel();
            controlContainer2 = new DevExpress.XtraBars.Docking.ControlContainer();
            btnZoomOut = new DevExpress.XtraEditors.SimpleButton();
            btnZoomIn = new DevExpress.XtraEditors.SimpleButton();
            pitchTrackBarControl = new DevExpress.XtraEditors.TrackBarControl();
            headingTrackBarControl = new DevExpress.XtraEditors.TrackBarControl();
            webBrowser = new WebBrowser();
            dockPanelTOC = new DevExpress.XtraBars.Docking.DockPanel();
            dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            dockPanelMap = new DevExpress.XtraBars.Docking.DockPanel();
            dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            map = new DevExpress.XtraMap.MapControl();
            vectorItemsLayer1 = new DevExpress.XtraMap.VectorItemsLayer();
            pushPinItemStorage = new DevExpress.XtraMap.MapItemStorage();
            informationLayer = new DevExpress.XtraMap.InformationLayer();
            lblStatus = new DevExpress.XtraEditors.LabelControl();
            behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(components);
            ((System.ComponentModel.ISupportInitialize)dockManager).BeginInit();
            dockPanelStreetView.SuspendLayout();
            controlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pitchTrackBarControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pitchTrackBarControl.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)headingTrackBarControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)headingTrackBarControl.Properties).BeginInit();
            dockPanelTOC.SuspendLayout();
            dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkedListBoxControl1).BeginInit();
            dockPanelMap.SuspendLayout();
            dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)map).BeginInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).BeginInit();
            SuspendLayout();
            // 
            // dockManager
            // 
            dockManager.Form = this;
            dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] { dockPanelStreetView, dockPanelTOC, dockPanelMap });
            dockManager.TopZIndexControls.AddRange(new string[] { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl" });
            // 
            // dockPanelStreetView
            // 
            dockPanelStreetView.Controls.Add(controlContainer2);
            dockPanelStreetView.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            dockPanelStreetView.FloatVertical = true;
            dockPanelStreetView.ID = new Guid("007eaa27-372b-425b-b280-d417ace3553c");
            dockPanelStreetView.Location = new Point(606, 0);
            dockPanelStreetView.Margin = new Padding(4, 3, 4, 3);
            dockPanelStreetView.Name = "dockPanelStreetView";
            dockPanelStreetView.Options.ShowCloseButton = false;
            dockPanelStreetView.OriginalSize = new Size(580, 267);
            dockPanelStreetView.Size = new Size(580, 700);
            dockPanelStreetView.Text = "StreetView";
            dockPanelStreetView.MouseMove += dockPanelStreetView_MouseMove;
            // 
            // controlContainer2
            // 
            controlContainer2.Controls.Add(btnZoomOut);
            controlContainer2.Controls.Add(btnZoomIn);
            controlContainer2.Controls.Add(pitchTrackBarControl);
            controlContainer2.Controls.Add(headingTrackBarControl);
            controlContainer2.Controls.Add(webBrowser);
            controlContainer2.Location = new Point(4, 26);
            controlContainer2.Margin = new Padding(4, 3, 4, 3);
            controlContainer2.Name = "controlContainer2";
            controlContainer2.Size = new Size(573, 671);
            controlContainer2.TabIndex = 0;
            // 
            // btnZoomOut
            // 
            btnZoomOut.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnZoomOut.ImageOptions.Image = (Image)resources.GetObject("btnZoomOut.ImageOptions.Image");
            btnZoomOut.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            btnZoomOut.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnZoomOut.ImageOptions.SvgImage");
            btnZoomOut.Location = new Point(588, 672);
            btnZoomOut.Margin = new Padding(4, 3, 4, 3);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new Size(47, 46);
            btnZoomOut.TabIndex = 5;
            btnZoomOut.Text = "+";
            // 
            // btnZoomIn
            // 
            btnZoomIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnZoomIn.ImageOptions.Image = (Image)resources.GetObject("btnZoomIn.ImageOptions.Image");
            btnZoomIn.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            btnZoomIn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnZoomIn.ImageOptions.SvgImage");
            btnZoomIn.Location = new Point(534, 672);
            btnZoomIn.Margin = new Padding(4, 3, 4, 3);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new Size(47, 46);
            btnZoomIn.TabIndex = 4;
            btnZoomIn.Text = "+";
            // 
            // pitchTrackBarControl
            // 
            pitchTrackBarControl.Dock = DockStyle.Right;
            pitchTrackBarControl.Location = new Point(546, 0);
            pitchTrackBarControl.Margin = new Padding(4, 3, 4, 3);
            pitchTrackBarControl.Name = "pitchTrackBarControl";
            pitchTrackBarControl.Properties.AutoSize = false;
            pitchTrackBarControl.Properties.LabelAppearance.Options.UseTextOptions = true;
            pitchTrackBarControl.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            pitchTrackBarControl.Properties.LargeChange = 10;
            pitchTrackBarControl.Properties.Maximum = 90;
            pitchTrackBarControl.Properties.Minimum = -90;
            pitchTrackBarControl.Properties.Orientation = Orientation.Vertical;
            pitchTrackBarControl.Properties.SmallChange = 5;
            pitchTrackBarControl.Properties.TickStyle = TickStyle.None;
            pitchTrackBarControl.Size = new Size(27, 639);
            pitchTrackBarControl.TabIndex = 3;
            pitchTrackBarControl.Value = 0;
            // 
            // headingTrackBarControl
            // 
            headingTrackBarControl.Dock = DockStyle.Bottom;
            headingTrackBarControl.Location = new Point(0, 639);
            headingTrackBarControl.Margin = new Padding(4, 3, 4, 3);
            headingTrackBarControl.Name = "headingTrackBarControl";
            headingTrackBarControl.Properties.AutoSize = false;
            headingTrackBarControl.Properties.LabelAppearance.Options.UseTextOptions = true;
            headingTrackBarControl.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            headingTrackBarControl.Properties.LargeChange = 10;
            headingTrackBarControl.Properties.Maximum = 180;
            headingTrackBarControl.Properties.Minimum = -180;
            headingTrackBarControl.Properties.SmallChange = 5;
            headingTrackBarControl.Properties.TickStyle = TickStyle.None;
            headingTrackBarControl.Size = new Size(573, 32);
            headingTrackBarControl.TabIndex = 1;
            headingTrackBarControl.Value = 0;
            headingTrackBarControl.EditValueChanged += trackBarControl_EditValueChanged;
            // 
            // webBrowser
            // 
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.Location = new Point(0, 0);
            webBrowser.Margin = new Padding(4, 3, 4, 3);
            webBrowser.MinimumSize = new Size(23, 23);
            webBrowser.Name = "webBrowser";
            webBrowser.Size = new Size(573, 671);
            webBrowser.TabIndex = 0;
            webBrowser.Url = new Uri("about:blank", UriKind.Absolute);
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            // 
            // dockPanelTOC
            // 
            dockPanelTOC.Controls.Add(dockPanel3_Container);
            dockPanelTOC.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            dockPanelTOC.ID = new Guid("5ee7613f-3b0b-460a-b927-f927262b572f");
            dockPanelTOC.Location = new Point(0, 0);
            dockPanelTOC.Margin = new Padding(4, 3, 4, 3);
            dockPanelTOC.Name = "dockPanelTOC";
            dockPanelTOC.Options.ShowCloseButton = false;
            dockPanelTOC.OriginalSize = new Size(202, 200);
            dockPanelTOC.Size = new Size(202, 700);
            dockPanelTOC.Text = "TOC";
            // 
            // dockPanel3_Container
            // 
            dockPanel3_Container.Controls.Add(checkedListBoxControl1);
            dockPanel3_Container.Location = new Point(3, 26);
            dockPanel3_Container.Margin = new Padding(4, 3, 4, 3);
            dockPanel3_Container.Name = "dockPanel3_Container";
            dockPanel3_Container.Size = new Size(195, 671);
            dockPanel3_Container.TabIndex = 0;
            // 
            // checkedListBoxControl1
            // 
            checkedListBoxControl1.CheckOnClick = true;
            checkedListBoxControl1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            checkedListBoxControl1.Dock = DockStyle.Fill;
            checkedListBoxControl1.ItemHeight = 35;
            checkedListBoxControl1.Location = new Point(0, 0);
            checkedListBoxControl1.Margin = new Padding(4, 3, 4, 3);
            checkedListBoxControl1.Name = "checkedListBoxControl1";
            checkedListBoxControl1.Size = new Size(195, 671);
            checkedListBoxControl1.TabIndex = 0;
            tableColumnDefinition1.Length.Type = DevExpress.XtraEditors.TableLayout.TableDefinitionLengthType.Pixel;
            tableColumnDefinition1.Length.Value = 152D;
            tableColumnDefinition2.Length.Type = DevExpress.XtraEditors.TableLayout.TableDefinitionLengthType.Pixel;
            tableColumnDefinition2.Length.Value = 40D;
            itemTemplateBase1.Columns.Add(tableColumnDefinition1);
            itemTemplateBase1.Columns.Add(tableColumnDefinition2);
            templatedItemElement1.FieldName = "LayerName";
            templatedItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement1.Text = "LayerName";
            templatedItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement2.ColumnIndex = 1;
            templatedItemElement2.FieldName = "Image";
            templatedItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement2.Text = "Image";
            templatedItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            itemTemplateBase1.Elements.Add(templatedItemElement1);
            itemTemplateBase1.Elements.Add(templatedItemElement2);
            itemTemplateBase1.Name = "template1";
            tableRowDefinition1.Length.Value = 15D;
            itemTemplateBase1.Rows.Add(tableRowDefinition1);
            checkedListBoxControl1.Templates.Add(itemTemplateBase1);
            checkedListBoxControl1.ItemCheck += checkedListBoxControl1_ItemCheck;
            checkedListBoxControl1.ContextButtonClick += CheckedListBoxControl1_ContextButtonClick;
            checkedListBoxControl1.CustomizeContextItem += checkedListBoxControl1_CustomizeContextItem;
            // 
            // dockPanelMap
            // 
            dockPanelMap.Controls.Add(dockPanel1_Container);
            dockPanelMap.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            dockPanelMap.ID = new Guid("cbe939cf-0727-402c-9dc0-e0e6d837f83f");
            dockPanelMap.Location = new Point(202, 0);
            dockPanelMap.Margin = new Padding(4, 3, 4, 3);
            dockPanelMap.Name = "dockPanelMap";
            dockPanelMap.Options.ShowAutoHideButton = false;
            dockPanelMap.Options.ShowCloseButton = false;
            dockPanelMap.Options.ShowMaximizeButton = false;
            dockPanelMap.Options.ShowMinimizeButton = false;
            dockPanelMap.OriginalSize = new Size(235, 200);
            dockPanelMap.Size = new Size(404, 700);
            dockPanelMap.Text = "Map";
            // 
            // dockPanel1_Container
            // 
            dockPanel1_Container.Controls.Add(map);
            dockPanel1_Container.Controls.Add(lblStatus);
            dockPanel1_Container.Location = new Point(3, 26);
            dockPanel1_Container.Margin = new Padding(4, 3, 4, 3);
            dockPanel1_Container.Name = "dockPanel1_Container";
            dockPanel1_Container.Size = new Size(398, 671);
            dockPanel1_Container.TabIndex = 0;
            // 
            // map
            // 
            map.Dock = DockStyle.Fill;
            map.Layers.Add(vectorItemsLayer1);
            map.Layers.Add(informationLayer);
            map.Location = new Point(0, 0);
            map.Margin = new Padding(4, 3, 4, 3);
            map.Measurements.AreaUnits = DevExpress.XtraMap.AreaMeasurementUnit.SquareMeter;
            map.Measurements.DistanceUnits = DevExpress.XtraMap.MeasureUnit.Meter;
            map.Measurements.ShowToolbar = true;
            map.Name = "map";
            map.NavigationPanelOptions.Height = 30;
            map.NavigationPanelOptions.ShowCoordinates = false;
            map.NavigationPanelOptions.ShowMilesScale = false;
            map.NavigationPanelOptions.ShowScrollButtons = false;
            map.NavigationPanelOptions.ShowZoomTrackbar = false;
            map.Size = new Size(398, 639);
            map.TabIndex = 0;
            map.Click += map_Click;
            map.MouseClick += map_MouseClick;
            vectorItemsLayer1.Data = pushPinItemStorage;
            // 
            // lblStatus
            // 
            lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Location = new Point(0, 639);
            lblStatus.Margin = new Padding(4, 3, 4, 3);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(398, 32);
            lblStatus.TabIndex = 4;
            // 
            // MapUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dockPanelMap);
            Controls.Add(dockPanelTOC);
            Controls.Add(dockPanelStreetView);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MapUserControl";
            Size = new Size(1186, 700);
            ((System.ComponentModel.ISupportInitialize)dockManager).EndInit();
            dockPanelStreetView.ResumeLayout(false);
            controlContainer2.ResumeLayout(false);
            controlContainer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pitchTrackBarControl.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pitchTrackBarControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)headingTrackBarControl.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)headingTrackBarControl).EndInit();
            dockPanelTOC.ResumeLayout(false);
            dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)checkedListBoxControl1).EndInit();
            dockPanelMap.ResumeLayout(false);
            dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)map).EndInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelMap;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraMap.MapControl map;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelTOC;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelStreetView;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer2;
        private System.Windows.Forms.WebBrowser webBrowser;
        private DevExpress.XtraEditors.TrackBarControl headingTrackBarControl;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.TrackBarControl pitchTrackBarControl;
        private DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer1;
        private DevExpress.XtraMap.MapItemStorage pushPinItemStorage;
        private DevExpress.XtraEditors.SimpleButton btnZoomIn;
        private DevExpress.XtraEditors.SimpleButton btnZoomOut;
        private DevExpress.XtraMap.InformationLayer informationLayer;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}
