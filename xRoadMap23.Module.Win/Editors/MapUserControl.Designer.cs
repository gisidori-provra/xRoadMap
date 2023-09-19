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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapUserControl));
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelStreetView = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer2 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnZoomOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomIn = new DevExpress.XtraEditors.SimpleButton();
            this.pitchTrackBarControl = new DevExpress.XtraEditors.TrackBarControl();
            this.headingTrackBarControl = new DevExpress.XtraEditors.TrackBarControl();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.dockPanelTOC = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.dockPanelMap = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.map = new DevExpress.XtraMap.MapControl();
            this.vectorItemsLayer1 = new DevExpress.XtraMap.VectorItemsLayer();
            this.pushPinItemStorage = new DevExpress.XtraMap.MapItemStorage();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.dockPanelStreetView.SuspendLayout();
            this.controlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pitchTrackBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchTrackBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headingTrackBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headingTrackBarControl.Properties)).BeginInit();
            this.dockPanelTOC.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            this.dockPanelMap.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager
            // 
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelStreetView,
            this.dockPanelTOC,
            this.dockPanelMap});
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanelStreetView
            // 
            this.dockPanelStreetView.Controls.Add(this.controlContainer2);
            this.dockPanelStreetView.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelStreetView.FloatVertical = true;
            this.dockPanelStreetView.ID = new System.Guid("007eaa27-372b-425b-b280-d417ace3553c");
            this.dockPanelStreetView.Location = new System.Drawing.Point(377, 0);
            this.dockPanelStreetView.Name = "dockPanelStreetView";
            this.dockPanelStreetView.Options.ShowCloseButton = false;
            this.dockPanelStreetView.OriginalSize = new System.Drawing.Size(640, 267);
            this.dockPanelStreetView.Size = new System.Drawing.Size(640, 607);
            this.dockPanelStreetView.Text = "StreetView";
            this.dockPanelStreetView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dockPanelStreetView_MouseMove);
            // 
            // controlContainer2
            // 
            this.controlContainer2.Controls.Add(this.btnZoomOut);
            this.controlContainer2.Controls.Add(this.btnZoomIn);
            this.controlContainer2.Controls.Add(this.pitchTrackBarControl);
            this.controlContainer2.Controls.Add(this.headingTrackBarControl);
            this.controlContainer2.Controls.Add(this.webBrowser);
            this.controlContainer2.Location = new System.Drawing.Point(4, 26);
            this.controlContainer2.Name = "controlContainer2";
            this.controlContainer2.Size = new System.Drawing.Size(633, 578);
            this.controlContainer2.TabIndex = 0;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.ImageOptions.Image")));
            this.btnZoomOut.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnZoomOut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnZoomOut.ImageOptions.SvgImage")));
            this.btnZoomOut.Location = new System.Drawing.Point(564, 502);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(40, 40);
            this.btnZoomOut.TabIndex = 5;
            this.btnZoomOut.Text = "+";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.ImageOptions.Image")));
            this.btnZoomIn.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnZoomIn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnZoomIn.ImageOptions.SvgImage")));
            this.btnZoomIn.Location = new System.Drawing.Point(518, 502);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(40, 40);
            this.btnZoomIn.TabIndex = 4;
            this.btnZoomIn.Text = "+";
            // 
            // pitchTrackBarControl
            // 
            this.pitchTrackBarControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pitchTrackBarControl.Location = new System.Drawing.Point(610, 0);
            this.pitchTrackBarControl.Name = "pitchTrackBarControl";
            this.pitchTrackBarControl.Properties.AutoSize = false;
            this.pitchTrackBarControl.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.pitchTrackBarControl.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pitchTrackBarControl.Properties.LargeChange = 10;
            this.pitchTrackBarControl.Properties.Maximum = 90;
            this.pitchTrackBarControl.Properties.Minimum = -90;
            this.pitchTrackBarControl.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.pitchTrackBarControl.Properties.SmallChange = 5;
            this.pitchTrackBarControl.Properties.TickStyle = System.Windows.Forms.TickStyle.None;
            this.pitchTrackBarControl.Size = new System.Drawing.Size(23, 550);
            this.pitchTrackBarControl.TabIndex = 3;
            this.pitchTrackBarControl.Value = 0;
            // 
            // headingTrackBarControl
            // 
            this.headingTrackBarControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.headingTrackBarControl.Location = new System.Drawing.Point(0, 550);
            this.headingTrackBarControl.Name = "headingTrackBarControl";
            this.headingTrackBarControl.Properties.AutoSize = false;
            this.headingTrackBarControl.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.headingTrackBarControl.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.headingTrackBarControl.Properties.LargeChange = 10;
            this.headingTrackBarControl.Properties.Maximum = 180;
            this.headingTrackBarControl.Properties.Minimum = -180;
            this.headingTrackBarControl.Properties.SmallChange = 5;
            this.headingTrackBarControl.Properties.TickStyle = System.Windows.Forms.TickStyle.None;
            this.headingTrackBarControl.Size = new System.Drawing.Size(633, 28);
            this.headingTrackBarControl.TabIndex = 1;
            this.headingTrackBarControl.Value = 0;
            this.headingTrackBarControl.EditValueChanged += new System.EventHandler(this.trackBarControl_EditValueChanged);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(633, 578);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // dockPanelTOC
            // 
            this.dockPanelTOC.Controls.Add(this.dockPanel3_Container);
            this.dockPanelTOC.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelTOC.ID = new System.Guid("5ee7613f-3b0b-460a-b927-f927262b572f");
            this.dockPanelTOC.Location = new System.Drawing.Point(0, 0);
            this.dockPanelTOC.Name = "dockPanelTOC";
            this.dockPanelTOC.Options.ShowCloseButton = false;
            this.dockPanelTOC.OriginalSize = new System.Drawing.Size(130, 200);
            this.dockPanelTOC.Size = new System.Drawing.Size(130, 607);
            this.dockPanelTOC.Text = "TOC";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.checkedListBoxControl1);
            this.dockPanel3_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(123, 578);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.checkedListBoxControl1.Size = new System.Drawing.Size(123, 578);
            this.checkedListBoxControl1.TabIndex = 0;
            this.checkedListBoxControl1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBoxControl1_ItemCheck);
            // 
            // dockPanelMap
            // 
            this.dockPanelMap.Controls.Add(this.dockPanel1_Container);
            this.dockPanelMap.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanelMap.ID = new System.Guid("cbe939cf-0727-402c-9dc0-e0e6d837f83f");
            this.dockPanelMap.Location = new System.Drawing.Point(130, 0);
            this.dockPanelMap.Name = "dockPanelMap";
            this.dockPanelMap.Options.ShowAutoHideButton = false;
            this.dockPanelMap.Options.ShowCloseButton = false;
            this.dockPanelMap.Options.ShowMaximizeButton = false;
            this.dockPanelMap.Options.ShowMinimizeButton = false;
            this.dockPanelMap.OriginalSize = new System.Drawing.Size(247, 200);
            this.dockPanelMap.Size = new System.Drawing.Size(247, 607);
            this.dockPanelMap.Text = "Map";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.lblStatus);
            this.dockPanel1_Container.Controls.Add(this.map);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(241, 578);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 550);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(241, 28);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "labelControl1";
            // 
            // map
            // 
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map.Layers.Add(this.vectorItemsLayer1);
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.Name = "map";
            this.map.NavigationPanelOptions.Visible = false;
            this.map.Size = new System.Drawing.Size(241, 578);
            this.map.TabIndex = 0;
            this.map.Click += new System.EventHandler(this.map_Click);
            this.map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.map_MouseClick);
            this.vectorItemsLayer1.Data = this.pushPinItemStorage;
            // 
            // MapUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockPanelMap);
            this.Controls.Add(this.dockPanelTOC);
            this.Controls.Add(this.dockPanelStreetView);
            this.Name = "MapUserControl";
            this.Size = new System.Drawing.Size(1017, 607);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.dockPanelStreetView.ResumeLayout(false);
            this.controlContainer2.ResumeLayout(false);
            this.controlContainer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pitchTrackBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchTrackBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headingTrackBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headingTrackBarControl)).EndInit();
            this.dockPanelTOC.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            this.dockPanelMap.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.ResumeLayout(false);

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
    }
}
