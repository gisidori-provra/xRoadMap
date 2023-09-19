using SyncModule;
namespace SyncAppostamenti
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGetApp = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdApp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gisDataSet1 = new SyncModule.GisDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTATO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colATC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAARCHIVIAZIONE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANNATAVENATORIA_ATTI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPREPARCOBAIONAPIOMBONI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTIPOAPPOST = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMUNE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFRAZIONE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFONDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNSUSS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROPRIETA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONDUTTORE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOPZIONE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUPERFICIEATTUALE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANNOAUT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNUMEROAUT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAINIZIOVALIDITÀ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAFINEVALIDITÀ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANNOREVOCA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNUMEROREVOCA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAREVOCA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOTEAUT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOGNOME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOPRALLUOGO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOP_DATA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOP_DATARICONSEGNA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOSTITUTI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOBJECTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOME1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colATC1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATO1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAARCHIVIAZIONE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANNATAVENATORIA_ATTI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPREPARCOBAIONAPIOMBONI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTIPOAPPOST1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMUNE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFRAZIONE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVIA1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFONDO1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNSUSS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROPRIETA1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONDUTTORE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOPZIONE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUPERFICIEATTUALE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANNOAUT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNUMEROAUT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAINIZIOVALIDITÀ1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAFINEVALIDITÀ1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANNOREVOCA1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNUMREVOCA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAREVOCA1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOGNOME1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOPRALLUOGO1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOP_DATA1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOP_DATARICONSEGNA1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTIPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOTEAUT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOSTITUTI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAUT_COM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.dsNonCensiti = new SyncModule.GisDataSet();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTATO2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colATC2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORD2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAARCHIVIAZIONE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANNATAVENATORIA_ATTI2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPREPARCOBAIONAPIOMBONI2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTIPOAPPOST2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMUNE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFRAZIONE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVIA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFONDO2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNSUSS2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROPRIETA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONDUTTORE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOPZIONE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUPERFICIEATTUALE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANNOAUT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNUMEROAUT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAINIZIOVALIDITÀ2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAFINEVALIDITÀ2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANNOREVOCA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNUMEROREVOCA1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAREVOCA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOTEAUT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOGNOME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOPRALLUOGO2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOP_DATA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOP_DATARICONSEGNA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOSTITUTI2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colATC_CODICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.capE_APPOSTAMENTITableAdapter1 = new SyncModule.GisDataSetTableAdapters.CAPE_APPOSTAMENTITableAdapter();
            this.capE_TMPAPPOSTAMENTITableAdapter1 = new SyncModule.GisDataSetTableAdapters.CAPE_TMPAPPOSTAMENTITableAdapter();
            this.capE_LIMITI_ATCTableAdapter1 = new SyncModule.GisDataSetTableAdapters.CAPE_LIMITI_ATCTableAdapter();
            this.bwork = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gisDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsNonCensiti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Refresh";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGetApp,
            this.tsbUpdApp,
            this.toolStripSeparator1,
            this.toolStripProgressBar1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(619, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGetApp
            // 
            this.tsbGetApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGetApp.Image = ((System.Drawing.Image)(resources.GetObject("tsbGetApp.Image")));
            this.tsbGetApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGetApp.Name = "tsbGetApp";
            this.tsbGetApp.Size = new System.Drawing.Size(23, 22);
            this.tsbGetApp.Text = "Refresh";
            this.tsbGetApp.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbUpdApp
            // 
            this.tsbUpdApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpdApp.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdApp.Image")));
            this.tsbUpdApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdApp.Name = "tsbUpdApp";
            this.tsbUpdApp.Size = new System.Drawing.Size(23, 22);
            this.tsbUpdApp.Text = "Sincronizza";
            this.tsbUpdApp.Click += new System.EventHandler(this.tsbSynch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(619, 428);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(611, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Registrati";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "CAPE_TMPAPPOSTAMENTI";
            this.gridControl1.DataSource = this.gisDataSet1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(605, 396);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gisDataSet1
            // 
            this.gisDataSet1.DataSetName = "GisDataSet";
            this.gisDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTATO,
            this.colID1,
            this.colATC,
            this.colORD,
            this.colDATAARCHIVIAZIONE,
            this.colANNATAVENATORIA_ATTI,
            this.colPREPARCOBAIONAPIOMBONI,
            this.colTIPOAPPOST,
            this.colCOMUNE,
            this.colFRAZIONE,
            this.colVIA,
            this.colFONDO,
            this.colNSUSS,
            this.colPROPRIETA,
            this.colCONDUTTORE,
            this.colOPZIONE,
            this.colSUPERFICIEATTUALE,
            this.colANNOAUT,
            this.colNUMEROAUT,
            this.colDATAINIZIOVALIDITÀ,
            this.colDATAFINEVALIDITÀ,
            this.colANNOREVOCA,
            this.colNUMEROREVOCA,
            this.colDATAREVOCA,
            this.colNOTEAUT,
            this.colCOGNOME,
            this.colNOME,
            this.colSOPRALLUOGO,
            this.colSOP_DATA,
            this.colSOP_DATARICONSEGNA,
            this.colSOSTITUTI});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSTATO
            // 
            this.colSTATO.Caption = "STATO";
            this.colSTATO.FieldName = "STATO";
            this.colSTATO.Name = "colSTATO";
            this.colSTATO.Visible = true;
            this.colSTATO.VisibleIndex = 0;
            // 
            // colID1
            // 
            this.colID1.Caption = "ID";
            this.colID1.FieldName = "ID";
            this.colID1.Name = "colID1";
            this.colID1.Visible = true;
            this.colID1.VisibleIndex = 1;
            // 
            // colATC
            // 
            this.colATC.Caption = "ATC";
            this.colATC.FieldName = "ATC";
            this.colATC.Name = "colATC";
            this.colATC.Visible = true;
            this.colATC.VisibleIndex = 2;
            // 
            // colORD
            // 
            this.colORD.Caption = "ORD";
            this.colORD.FieldName = "ORD";
            this.colORD.Name = "colORD";
            this.colORD.Visible = true;
            this.colORD.VisibleIndex = 3;
            // 
            // colDATAARCHIVIAZIONE
            // 
            this.colDATAARCHIVIAZIONE.Caption = "DATAARCHIVIAZIONE";
            this.colDATAARCHIVIAZIONE.FieldName = "DATAARCHIVIAZIONE";
            this.colDATAARCHIVIAZIONE.Name = "colDATAARCHIVIAZIONE";
            this.colDATAARCHIVIAZIONE.Visible = true;
            this.colDATAARCHIVIAZIONE.VisibleIndex = 4;
            // 
            // colANNATAVENATORIA_ATTI
            // 
            this.colANNATAVENATORIA_ATTI.Caption = "ANNATAVENATORIA_ATTI";
            this.colANNATAVENATORIA_ATTI.FieldName = "ANNATAVENATORIA_ATTI";
            this.colANNATAVENATORIA_ATTI.Name = "colANNATAVENATORIA_ATTI";
            this.colANNATAVENATORIA_ATTI.Visible = true;
            this.colANNATAVENATORIA_ATTI.VisibleIndex = 5;
            // 
            // colPREPARCOBAIONAPIOMBONI
            // 
            this.colPREPARCOBAIONAPIOMBONI.Caption = "PREPARCOBAIONAPIOMBONI";
            this.colPREPARCOBAIONAPIOMBONI.FieldName = "PREPARCOBAIONAPIOMBONI";
            this.colPREPARCOBAIONAPIOMBONI.Name = "colPREPARCOBAIONAPIOMBONI";
            this.colPREPARCOBAIONAPIOMBONI.Visible = true;
            this.colPREPARCOBAIONAPIOMBONI.VisibleIndex = 6;
            // 
            // colTIPOAPPOST
            // 
            this.colTIPOAPPOST.Caption = "TIPOAPPOST";
            this.colTIPOAPPOST.FieldName = "TIPOAPPOST";
            this.colTIPOAPPOST.Name = "colTIPOAPPOST";
            this.colTIPOAPPOST.Visible = true;
            this.colTIPOAPPOST.VisibleIndex = 7;
            // 
            // colCOMUNE
            // 
            this.colCOMUNE.Caption = "COMUNE";
            this.colCOMUNE.FieldName = "COMUNE";
            this.colCOMUNE.Name = "colCOMUNE";
            this.colCOMUNE.Visible = true;
            this.colCOMUNE.VisibleIndex = 8;
            // 
            // colFRAZIONE
            // 
            this.colFRAZIONE.Caption = "FRAZIONE";
            this.colFRAZIONE.FieldName = "FRAZIONE";
            this.colFRAZIONE.Name = "colFRAZIONE";
            this.colFRAZIONE.Visible = true;
            this.colFRAZIONE.VisibleIndex = 9;
            // 
            // colVIA
            // 
            this.colVIA.Caption = "VIA";
            this.colVIA.FieldName = "VIA";
            this.colVIA.Name = "colVIA";
            this.colVIA.Visible = true;
            this.colVIA.VisibleIndex = 10;
            // 
            // colFONDO
            // 
            this.colFONDO.Caption = "FONDO";
            this.colFONDO.FieldName = "FONDO";
            this.colFONDO.Name = "colFONDO";
            this.colFONDO.Visible = true;
            this.colFONDO.VisibleIndex = 11;
            // 
            // colNSUSS
            // 
            this.colNSUSS.Caption = "NSUSS";
            this.colNSUSS.FieldName = "NSUSS";
            this.colNSUSS.Name = "colNSUSS";
            this.colNSUSS.Visible = true;
            this.colNSUSS.VisibleIndex = 12;
            // 
            // colPROPRIETA
            // 
            this.colPROPRIETA.Caption = "PROPRIETA";
            this.colPROPRIETA.FieldName = "PROPRIETA";
            this.colPROPRIETA.Name = "colPROPRIETA";
            this.colPROPRIETA.Visible = true;
            this.colPROPRIETA.VisibleIndex = 13;
            // 
            // colCONDUTTORE
            // 
            this.colCONDUTTORE.Caption = "CONDUTTORE";
            this.colCONDUTTORE.FieldName = "CONDUTTORE";
            this.colCONDUTTORE.Name = "colCONDUTTORE";
            this.colCONDUTTORE.Visible = true;
            this.colCONDUTTORE.VisibleIndex = 14;
            // 
            // colOPZIONE
            // 
            this.colOPZIONE.Caption = "OPZIONE";
            this.colOPZIONE.FieldName = "OPZIONE";
            this.colOPZIONE.Name = "colOPZIONE";
            this.colOPZIONE.Visible = true;
            this.colOPZIONE.VisibleIndex = 15;
            // 
            // colSUPERFICIEATTUALE
            // 
            this.colSUPERFICIEATTUALE.Caption = "SUPERFICIEATTUALE";
            this.colSUPERFICIEATTUALE.FieldName = "SUPERFICIEATTUALE";
            this.colSUPERFICIEATTUALE.Name = "colSUPERFICIEATTUALE";
            this.colSUPERFICIEATTUALE.Visible = true;
            this.colSUPERFICIEATTUALE.VisibleIndex = 16;
            // 
            // colANNOAUT
            // 
            this.colANNOAUT.Caption = "ANNOAUT";
            this.colANNOAUT.FieldName = "ANNOAUT";
            this.colANNOAUT.Name = "colANNOAUT";
            this.colANNOAUT.Visible = true;
            this.colANNOAUT.VisibleIndex = 17;
            // 
            // colNUMEROAUT
            // 
            this.colNUMEROAUT.Caption = "NUMEROAUT";
            this.colNUMEROAUT.FieldName = "NUMEROAUT";
            this.colNUMEROAUT.Name = "colNUMEROAUT";
            this.colNUMEROAUT.Visible = true;
            this.colNUMEROAUT.VisibleIndex = 18;
            // 
            // colDATAINIZIOVALIDITÀ
            // 
            this.colDATAINIZIOVALIDITÀ.Caption = "DATAINIZIOVALIDITÀ";
            this.colDATAINIZIOVALIDITÀ.FieldName = "DATAINIZIOVALIDITÀ";
            this.colDATAINIZIOVALIDITÀ.Name = "colDATAINIZIOVALIDITÀ";
            this.colDATAINIZIOVALIDITÀ.Visible = true;
            this.colDATAINIZIOVALIDITÀ.VisibleIndex = 19;
            // 
            // colDATAFINEVALIDITÀ
            // 
            this.colDATAFINEVALIDITÀ.Caption = "DATAFINEVALIDITÀ";
            this.colDATAFINEVALIDITÀ.FieldName = "DATAFINEVALIDITÀ";
            this.colDATAFINEVALIDITÀ.Name = "colDATAFINEVALIDITÀ";
            this.colDATAFINEVALIDITÀ.Visible = true;
            this.colDATAFINEVALIDITÀ.VisibleIndex = 20;
            // 
            // colANNOREVOCA
            // 
            this.colANNOREVOCA.Caption = "ANNOREVOCA";
            this.colANNOREVOCA.FieldName = "ANNOREVOCA";
            this.colANNOREVOCA.Name = "colANNOREVOCA";
            this.colANNOREVOCA.Visible = true;
            this.colANNOREVOCA.VisibleIndex = 21;
            // 
            // colNUMEROREVOCA
            // 
            this.colNUMEROREVOCA.Caption = "NUMEROREVOCA";
            this.colNUMEROREVOCA.FieldName = "NUMEROREVOCA";
            this.colNUMEROREVOCA.Name = "colNUMEROREVOCA";
            this.colNUMEROREVOCA.Visible = true;
            this.colNUMEROREVOCA.VisibleIndex = 22;
            // 
            // colDATAREVOCA
            // 
            this.colDATAREVOCA.Caption = "DATAREVOCA";
            this.colDATAREVOCA.FieldName = "DATAREVOCA";
            this.colDATAREVOCA.Name = "colDATAREVOCA";
            this.colDATAREVOCA.Visible = true;
            this.colDATAREVOCA.VisibleIndex = 23;
            // 
            // colNOTEAUT
            // 
            this.colNOTEAUT.Caption = "NOTEAUT";
            this.colNOTEAUT.FieldName = "NOTEAUT";
            this.colNOTEAUT.Name = "colNOTEAUT";
            this.colNOTEAUT.Visible = true;
            this.colNOTEAUT.VisibleIndex = 24;
            // 
            // colCOGNOME
            // 
            this.colCOGNOME.Caption = "COGNOME";
            this.colCOGNOME.FieldName = "COGNOME";
            this.colCOGNOME.Name = "colCOGNOME";
            this.colCOGNOME.Visible = true;
            this.colCOGNOME.VisibleIndex = 25;
            // 
            // colNOME
            // 
            this.colNOME.Caption = "NOME";
            this.colNOME.FieldName = "NOME";
            this.colNOME.Name = "colNOME";
            this.colNOME.Visible = true;
            this.colNOME.VisibleIndex = 26;
            // 
            // colSOPRALLUOGO
            // 
            this.colSOPRALLUOGO.Caption = "SOPRALLUOGO";
            this.colSOPRALLUOGO.FieldName = "SOPRALLUOGO";
            this.colSOPRALLUOGO.Name = "colSOPRALLUOGO";
            this.colSOPRALLUOGO.Visible = true;
            this.colSOPRALLUOGO.VisibleIndex = 27;
            // 
            // colSOP_DATA
            // 
            this.colSOP_DATA.Caption = "SOP_DATA";
            this.colSOP_DATA.FieldName = "SOP_DATA";
            this.colSOP_DATA.Name = "colSOP_DATA";
            this.colSOP_DATA.Visible = true;
            this.colSOP_DATA.VisibleIndex = 28;
            // 
            // colSOP_DATARICONSEGNA
            // 
            this.colSOP_DATARICONSEGNA.Caption = "SOP_DATARICONSEGNA";
            this.colSOP_DATARICONSEGNA.FieldName = "SOP_DATARICONSEGNA";
            this.colSOP_DATARICONSEGNA.Name = "colSOP_DATARICONSEGNA";
            this.colSOP_DATARICONSEGNA.Visible = true;
            this.colSOP_DATARICONSEGNA.VisibleIndex = 29;
            // 
            // colSOSTITUTI
            // 
            this.colSOSTITUTI.Caption = "SOSTITUTI";
            this.colSOSTITUTI.FieldName = "SOSTITUTI";
            this.colSOSTITUTI.Name = "colSOSTITUTI";
            this.colSOSTITUTI.Visible = true;
            this.colSOSTITUTI.VisibleIndex = 30;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridControl3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(611, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Censiti";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridControl3
            // 
            this.gridControl3.DataMember = "CAPE_APPOSTAMENTI";
            this.gridControl3.DataSource = this.gisDataSet1;
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.EmbeddedNavigator.Name = "";
            this.gridControl3.Location = new System.Drawing.Point(3, 3);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(605, 396);
            this.gridControl3.TabIndex = 0;
            this.gridControl3.UseEmbeddedNavigator = true;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOBJECTID,
            this.colNOME1,
            this.colID,
            this.colATC1,
            this.colORD1,
            this.colSTATO1,
            this.colDATAARCHIVIAZIONE1,
            this.colANNATAVENATORIA_ATTI1,
            this.colPREPARCOBAIONAPIOMBONI1,
            this.colTIPOAPPOST1,
            this.colCOMUNE1,
            this.colFRAZIONE1,
            this.colVIA1,
            this.colFONDO1,
            this.colNSUSS1,
            this.colPROPRIETA1,
            this.colCONDUTTORE1,
            this.colOPZIONE1,
            this.colSUPERFICIEATTUALE1,
            this.colANNOAUT1,
            this.colNUMEROAUT1,
            this.colDATAINIZIOVALIDITÀ1,
            this.colDATAFINEVALIDITÀ1,
            this.colANNOREVOCA1,
            this.colNUMREVOCA,
            this.colDATAREVOCA1,
            this.colCOGNOME1,
            this.colSOPRALLUOGO1,
            this.colSOP_DATA1,
            this.colSOP_DATARICONSEGNA1,
            this.colNOTE,
            this.colTIPO,
            this.colNOTEAUT1,
            this.colSOSTITUTI1,
            this.colAUT_COM});
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // colOBJECTID
            // 
            this.colOBJECTID.Caption = "OBJECTID";
            this.colOBJECTID.FieldName = "OBJECTID";
            this.colOBJECTID.Name = "colOBJECTID";
            this.colOBJECTID.Visible = true;
            this.colOBJECTID.VisibleIndex = 0;
            // 
            // colNOME1
            // 
            this.colNOME1.Caption = "NOME";
            this.colNOME1.FieldName = "NOME";
            this.colNOME1.Name = "colNOME1";
            this.colNOME1.Visible = true;
            this.colNOME1.VisibleIndex = 1;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 2;
            // 
            // colATC1
            // 
            this.colATC1.Caption = "ATC";
            this.colATC1.FieldName = "ATC";
            this.colATC1.Name = "colATC1";
            this.colATC1.Visible = true;
            this.colATC1.VisibleIndex = 3;
            // 
            // colORD1
            // 
            this.colORD1.Caption = "ORD";
            this.colORD1.FieldName = "ORD";
            this.colORD1.Name = "colORD1";
            this.colORD1.Visible = true;
            this.colORD1.VisibleIndex = 4;
            // 
            // colSTATO1
            // 
            this.colSTATO1.Caption = "STATO";
            this.colSTATO1.FieldName = "STATO";
            this.colSTATO1.Name = "colSTATO1";
            this.colSTATO1.Visible = true;
            this.colSTATO1.VisibleIndex = 5;
            // 
            // colDATAARCHIVIAZIONE1
            // 
            this.colDATAARCHIVIAZIONE1.Caption = "DATAARCHIVIAZIONE";
            this.colDATAARCHIVIAZIONE1.FieldName = "DATAARCHIVIAZIONE";
            this.colDATAARCHIVIAZIONE1.Name = "colDATAARCHIVIAZIONE1";
            this.colDATAARCHIVIAZIONE1.Visible = true;
            this.colDATAARCHIVIAZIONE1.VisibleIndex = 6;
            // 
            // colANNATAVENATORIA_ATTI1
            // 
            this.colANNATAVENATORIA_ATTI1.Caption = "ANNATAVENATORIA_ATTI";
            this.colANNATAVENATORIA_ATTI1.FieldName = "ANNATAVENATORIA_ATTI";
            this.colANNATAVENATORIA_ATTI1.Name = "colANNATAVENATORIA_ATTI1";
            this.colANNATAVENATORIA_ATTI1.Visible = true;
            this.colANNATAVENATORIA_ATTI1.VisibleIndex = 7;
            // 
            // colPREPARCOBAIONAPIOMBONI1
            // 
            this.colPREPARCOBAIONAPIOMBONI1.Caption = "PREPARCOBAIONAPIOMBONI";
            this.colPREPARCOBAIONAPIOMBONI1.FieldName = "PREPARCOBAIONAPIOMBONI";
            this.colPREPARCOBAIONAPIOMBONI1.Name = "colPREPARCOBAIONAPIOMBONI1";
            this.colPREPARCOBAIONAPIOMBONI1.Visible = true;
            this.colPREPARCOBAIONAPIOMBONI1.VisibleIndex = 8;
            // 
            // colTIPOAPPOST1
            // 
            this.colTIPOAPPOST1.Caption = "TIPOAPPOST";
            this.colTIPOAPPOST1.FieldName = "TIPOAPPOST";
            this.colTIPOAPPOST1.Name = "colTIPOAPPOST1";
            this.colTIPOAPPOST1.Visible = true;
            this.colTIPOAPPOST1.VisibleIndex = 9;
            // 
            // colCOMUNE1
            // 
            this.colCOMUNE1.Caption = "COMUNE";
            this.colCOMUNE1.FieldName = "COMUNE";
            this.colCOMUNE1.Name = "colCOMUNE1";
            this.colCOMUNE1.Visible = true;
            this.colCOMUNE1.VisibleIndex = 10;
            // 
            // colFRAZIONE1
            // 
            this.colFRAZIONE1.Caption = "FRAZIONE";
            this.colFRAZIONE1.FieldName = "FRAZIONE";
            this.colFRAZIONE1.Name = "colFRAZIONE1";
            this.colFRAZIONE1.Visible = true;
            this.colFRAZIONE1.VisibleIndex = 11;
            // 
            // colVIA1
            // 
            this.colVIA1.Caption = "VIA";
            this.colVIA1.FieldName = "VIA";
            this.colVIA1.Name = "colVIA1";
            this.colVIA1.Visible = true;
            this.colVIA1.VisibleIndex = 12;
            // 
            // colFONDO1
            // 
            this.colFONDO1.Caption = "FONDO";
            this.colFONDO1.FieldName = "FONDO";
            this.colFONDO1.Name = "colFONDO1";
            this.colFONDO1.Visible = true;
            this.colFONDO1.VisibleIndex = 13;
            // 
            // colNSUSS1
            // 
            this.colNSUSS1.Caption = "NSUSS";
            this.colNSUSS1.FieldName = "NSUSS";
            this.colNSUSS1.Name = "colNSUSS1";
            this.colNSUSS1.Visible = true;
            this.colNSUSS1.VisibleIndex = 14;
            // 
            // colPROPRIETA1
            // 
            this.colPROPRIETA1.Caption = "PROPRIETA";
            this.colPROPRIETA1.FieldName = "PROPRIETA";
            this.colPROPRIETA1.Name = "colPROPRIETA1";
            this.colPROPRIETA1.Visible = true;
            this.colPROPRIETA1.VisibleIndex = 15;
            // 
            // colCONDUTTORE1
            // 
            this.colCONDUTTORE1.Caption = "CONDUTTORE";
            this.colCONDUTTORE1.FieldName = "CONDUTTORE";
            this.colCONDUTTORE1.Name = "colCONDUTTORE1";
            this.colCONDUTTORE1.Visible = true;
            this.colCONDUTTORE1.VisibleIndex = 16;
            // 
            // colOPZIONE1
            // 
            this.colOPZIONE1.Caption = "OPZIONE";
            this.colOPZIONE1.FieldName = "OPZIONE";
            this.colOPZIONE1.Name = "colOPZIONE1";
            this.colOPZIONE1.Visible = true;
            this.colOPZIONE1.VisibleIndex = 17;
            // 
            // colSUPERFICIEATTUALE1
            // 
            this.colSUPERFICIEATTUALE1.Caption = "SUPERFICIEATTUALE";
            this.colSUPERFICIEATTUALE1.FieldName = "SUPERFICIEATTUALE";
            this.colSUPERFICIEATTUALE1.Name = "colSUPERFICIEATTUALE1";
            this.colSUPERFICIEATTUALE1.Visible = true;
            this.colSUPERFICIEATTUALE1.VisibleIndex = 18;
            // 
            // colANNOAUT1
            // 
            this.colANNOAUT1.Caption = "ANNOAUT";
            this.colANNOAUT1.FieldName = "ANNOAUT";
            this.colANNOAUT1.Name = "colANNOAUT1";
            this.colANNOAUT1.Visible = true;
            this.colANNOAUT1.VisibleIndex = 19;
            // 
            // colNUMEROAUT1
            // 
            this.colNUMEROAUT1.Caption = "NUMEROAUT";
            this.colNUMEROAUT1.FieldName = "NUMEROAUT";
            this.colNUMEROAUT1.Name = "colNUMEROAUT1";
            this.colNUMEROAUT1.Visible = true;
            this.colNUMEROAUT1.VisibleIndex = 20;
            // 
            // colDATAINIZIOVALIDITÀ1
            // 
            this.colDATAINIZIOVALIDITÀ1.Caption = "DATAINIZIOVALIDITÀ";
            this.colDATAINIZIOVALIDITÀ1.FieldName = "DATAINIZIOVALIDITÀ";
            this.colDATAINIZIOVALIDITÀ1.Name = "colDATAINIZIOVALIDITÀ1";
            this.colDATAINIZIOVALIDITÀ1.Visible = true;
            this.colDATAINIZIOVALIDITÀ1.VisibleIndex = 21;
            // 
            // colDATAFINEVALIDITÀ1
            // 
            this.colDATAFINEVALIDITÀ1.Caption = "DATAFINEVALIDITÀ";
            this.colDATAFINEVALIDITÀ1.FieldName = "DATAFINEVALIDITÀ";
            this.colDATAFINEVALIDITÀ1.Name = "colDATAFINEVALIDITÀ1";
            this.colDATAFINEVALIDITÀ1.Visible = true;
            this.colDATAFINEVALIDITÀ1.VisibleIndex = 22;
            // 
            // colANNOREVOCA1
            // 
            this.colANNOREVOCA1.Caption = "ANNOREVOCA";
            this.colANNOREVOCA1.FieldName = "ANNOREVOCA";
            this.colANNOREVOCA1.Name = "colANNOREVOCA1";
            this.colANNOREVOCA1.Visible = true;
            this.colANNOREVOCA1.VisibleIndex = 23;
            // 
            // colNUMREVOCA
            // 
            this.colNUMREVOCA.Caption = "NUMREVOCA";
            this.colNUMREVOCA.FieldName = "NUMREVOCA";
            this.colNUMREVOCA.Name = "colNUMREVOCA";
            this.colNUMREVOCA.Visible = true;
            this.colNUMREVOCA.VisibleIndex = 24;
            // 
            // colDATAREVOCA1
            // 
            this.colDATAREVOCA1.Caption = "DATAREVOCA";
            this.colDATAREVOCA1.FieldName = "DATAREVOCA";
            this.colDATAREVOCA1.Name = "colDATAREVOCA1";
            this.colDATAREVOCA1.Visible = true;
            this.colDATAREVOCA1.VisibleIndex = 25;
            // 
            // colCOGNOME1
            // 
            this.colCOGNOME1.Caption = "COGNOME";
            this.colCOGNOME1.FieldName = "COGNOME";
            this.colCOGNOME1.Name = "colCOGNOME1";
            this.colCOGNOME1.Visible = true;
            this.colCOGNOME1.VisibleIndex = 26;
            // 
            // colSOPRALLUOGO1
            // 
            this.colSOPRALLUOGO1.Caption = "SOPRALLUOGO";
            this.colSOPRALLUOGO1.FieldName = "SOPRALLUOGO";
            this.colSOPRALLUOGO1.Name = "colSOPRALLUOGO1";
            this.colSOPRALLUOGO1.Visible = true;
            this.colSOPRALLUOGO1.VisibleIndex = 27;
            // 
            // colSOP_DATA1
            // 
            this.colSOP_DATA1.Caption = "SOP_DATA";
            this.colSOP_DATA1.FieldName = "SOP_DATA";
            this.colSOP_DATA1.Name = "colSOP_DATA1";
            this.colSOP_DATA1.Visible = true;
            this.colSOP_DATA1.VisibleIndex = 28;
            // 
            // colSOP_DATARICONSEGNA1
            // 
            this.colSOP_DATARICONSEGNA1.Caption = "SOP_DATARICONSEGNA";
            this.colSOP_DATARICONSEGNA1.FieldName = "SOP_DATARICONSEGNA";
            this.colSOP_DATARICONSEGNA1.Name = "colSOP_DATARICONSEGNA1";
            this.colSOP_DATARICONSEGNA1.Visible = true;
            this.colSOP_DATARICONSEGNA1.VisibleIndex = 29;
            // 
            // colNOTE
            // 
            this.colNOTE.Caption = "NOTE";
            this.colNOTE.FieldName = "NOTE";
            this.colNOTE.Name = "colNOTE";
            this.colNOTE.Visible = true;
            this.colNOTE.VisibleIndex = 30;
            // 
            // colTIPO
            // 
            this.colTIPO.Caption = "TIPO";
            this.colTIPO.FieldName = "TIPO";
            this.colTIPO.Name = "colTIPO";
            this.colTIPO.Visible = true;
            this.colTIPO.VisibleIndex = 31;
            // 
            // colNOTEAUT1
            // 
            this.colNOTEAUT1.Caption = "NOTEAUT";
            this.colNOTEAUT1.FieldName = "NOTEAUT";
            this.colNOTEAUT1.Name = "colNOTEAUT1";
            this.colNOTEAUT1.Visible = true;
            this.colNOTEAUT1.VisibleIndex = 32;
            // 
            // colSOSTITUTI1
            // 
            this.colSOSTITUTI1.Caption = "SOSTITUTI";
            this.colSOSTITUTI1.FieldName = "SOSTITUTI";
            this.colSOSTITUTI1.Name = "colSOSTITUTI1";
            this.colSOSTITUTI1.Visible = true;
            this.colSOSTITUTI1.VisibleIndex = 33;
            // 
            // colAUT_COM
            // 
            this.colAUT_COM.Caption = "AUT_COM";
            this.colAUT_COM.FieldName = "AUT_COM";
            this.colAUT_COM.Name = "colAUT_COM";
            this.colAUT_COM.Visible = true;
            this.colAUT_COM.VisibleIndex = 34;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gridControl2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(611, 402);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Non censiti";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gridControl2
            // 
            this.gridControl2.DataMember = "CAPE_TMPAPPOSTAMENTI";
            this.gridControl2.DataSource = this.dsNonCensiti;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Name = "";
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(611, 402);
            this.gridControl2.TabIndex = 2;
            this.gridControl2.UseEmbeddedNavigator = true;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // dsNonCensiti
            // 
            this.dsNonCensiti.DataSetName = "GisDataSet";
            this.dsNonCensiti.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTATO2,
            this.colID2,
            this.colATC2,
            this.colORD2,
            this.colDATAARCHIVIAZIONE2,
            this.colANNATAVENATORIA_ATTI2,
            this.colPREPARCOBAIONAPIOMBONI2,
            this.colTIPOAPPOST2,
            this.colCOMUNE2,
            this.colFRAZIONE2,
            this.colVIA2,
            this.colFONDO2,
            this.colNSUSS2,
            this.colPROPRIETA2,
            this.colCONDUTTORE2,
            this.colOPZIONE2,
            this.colSUPERFICIEATTUALE2,
            this.colANNOAUT2,
            this.colNUMEROAUT2,
            this.colDATAINIZIOVALIDITÀ2,
            this.colDATAFINEVALIDITÀ2,
            this.colANNOREVOCA2,
            this.colNUMEROREVOCA1,
            this.colDATAREVOCA2,
            this.colNOTEAUT2,
            this.colCOGNOME2,
            this.colNOME2,
            this.colSOPRALLUOGO2,
            this.colSOP_DATA2,
            this.colSOP_DATARICONSEGNA2,
            this.colSOSTITUTI2,
            this.colATC_CODICE});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colSTATO2
            // 
            this.colSTATO2.Caption = "STATO";
            this.colSTATO2.FieldName = "STATO";
            this.colSTATO2.Name = "colSTATO2";
            this.colSTATO2.Visible = true;
            this.colSTATO2.VisibleIndex = 0;
            // 
            // colID2
            // 
            this.colID2.Caption = "ID";
            this.colID2.FieldName = "ID";
            this.colID2.Name = "colID2";
            this.colID2.Visible = true;
            this.colID2.VisibleIndex = 1;
            // 
            // colATC2
            // 
            this.colATC2.Caption = "ATC";
            this.colATC2.FieldName = "ATC";
            this.colATC2.Name = "colATC2";
            this.colATC2.Visible = true;
            this.colATC2.VisibleIndex = 2;
            // 
            // colORD2
            // 
            this.colORD2.Caption = "ORD";
            this.colORD2.FieldName = "ORD";
            this.colORD2.Name = "colORD2";
            this.colORD2.Visible = true;
            this.colORD2.VisibleIndex = 3;
            // 
            // colDATAARCHIVIAZIONE2
            // 
            this.colDATAARCHIVIAZIONE2.Caption = "DATAARCHIVIAZIONE";
            this.colDATAARCHIVIAZIONE2.FieldName = "DATAARCHIVIAZIONE";
            this.colDATAARCHIVIAZIONE2.Name = "colDATAARCHIVIAZIONE2";
            this.colDATAARCHIVIAZIONE2.Visible = true;
            this.colDATAARCHIVIAZIONE2.VisibleIndex = 4;
            // 
            // colANNATAVENATORIA_ATTI2
            // 
            this.colANNATAVENATORIA_ATTI2.Caption = "ANNATAVENATORIA_ATTI";
            this.colANNATAVENATORIA_ATTI2.FieldName = "ANNATAVENATORIA_ATTI";
            this.colANNATAVENATORIA_ATTI2.Name = "colANNATAVENATORIA_ATTI2";
            this.colANNATAVENATORIA_ATTI2.Visible = true;
            this.colANNATAVENATORIA_ATTI2.VisibleIndex = 5;
            // 
            // colPREPARCOBAIONAPIOMBONI2
            // 
            this.colPREPARCOBAIONAPIOMBONI2.Caption = "PREPARCOBAIONAPIOMBONI";
            this.colPREPARCOBAIONAPIOMBONI2.FieldName = "PREPARCOBAIONAPIOMBONI";
            this.colPREPARCOBAIONAPIOMBONI2.Name = "colPREPARCOBAIONAPIOMBONI2";
            this.colPREPARCOBAIONAPIOMBONI2.Visible = true;
            this.colPREPARCOBAIONAPIOMBONI2.VisibleIndex = 6;
            // 
            // colTIPOAPPOST2
            // 
            this.colTIPOAPPOST2.Caption = "TIPOAPPOST";
            this.colTIPOAPPOST2.FieldName = "TIPOAPPOST";
            this.colTIPOAPPOST2.Name = "colTIPOAPPOST2";
            this.colTIPOAPPOST2.Visible = true;
            this.colTIPOAPPOST2.VisibleIndex = 7;
            // 
            // colCOMUNE2
            // 
            this.colCOMUNE2.Caption = "COMUNE";
            this.colCOMUNE2.FieldName = "COMUNE";
            this.colCOMUNE2.Name = "colCOMUNE2";
            this.colCOMUNE2.Visible = true;
            this.colCOMUNE2.VisibleIndex = 8;
            // 
            // colFRAZIONE2
            // 
            this.colFRAZIONE2.Caption = "FRAZIONE";
            this.colFRAZIONE2.FieldName = "FRAZIONE";
            this.colFRAZIONE2.Name = "colFRAZIONE2";
            this.colFRAZIONE2.Visible = true;
            this.colFRAZIONE2.VisibleIndex = 9;
            // 
            // colVIA2
            // 
            this.colVIA2.Caption = "VIA";
            this.colVIA2.FieldName = "VIA";
            this.colVIA2.Name = "colVIA2";
            this.colVIA2.Visible = true;
            this.colVIA2.VisibleIndex = 10;
            // 
            // colFONDO2
            // 
            this.colFONDO2.Caption = "FONDO";
            this.colFONDO2.FieldName = "FONDO";
            this.colFONDO2.Name = "colFONDO2";
            this.colFONDO2.Visible = true;
            this.colFONDO2.VisibleIndex = 11;
            // 
            // colNSUSS2
            // 
            this.colNSUSS2.Caption = "NSUSS";
            this.colNSUSS2.FieldName = "NSUSS";
            this.colNSUSS2.Name = "colNSUSS2";
            this.colNSUSS2.Visible = true;
            this.colNSUSS2.VisibleIndex = 12;
            // 
            // colPROPRIETA2
            // 
            this.colPROPRIETA2.Caption = "PROPRIETA";
            this.colPROPRIETA2.FieldName = "PROPRIETA";
            this.colPROPRIETA2.Name = "colPROPRIETA2";
            this.colPROPRIETA2.Visible = true;
            this.colPROPRIETA2.VisibleIndex = 13;
            // 
            // colCONDUTTORE2
            // 
            this.colCONDUTTORE2.Caption = "CONDUTTORE";
            this.colCONDUTTORE2.FieldName = "CONDUTTORE";
            this.colCONDUTTORE2.Name = "colCONDUTTORE2";
            this.colCONDUTTORE2.Visible = true;
            this.colCONDUTTORE2.VisibleIndex = 14;
            // 
            // colOPZIONE2
            // 
            this.colOPZIONE2.Caption = "OPZIONE";
            this.colOPZIONE2.FieldName = "OPZIONE";
            this.colOPZIONE2.Name = "colOPZIONE2";
            this.colOPZIONE2.Visible = true;
            this.colOPZIONE2.VisibleIndex = 15;
            // 
            // colSUPERFICIEATTUALE2
            // 
            this.colSUPERFICIEATTUALE2.Caption = "SUPERFICIEATTUALE";
            this.colSUPERFICIEATTUALE2.FieldName = "SUPERFICIEATTUALE";
            this.colSUPERFICIEATTUALE2.Name = "colSUPERFICIEATTUALE2";
            this.colSUPERFICIEATTUALE2.Visible = true;
            this.colSUPERFICIEATTUALE2.VisibleIndex = 16;
            // 
            // colANNOAUT2
            // 
            this.colANNOAUT2.Caption = "ANNOAUT";
            this.colANNOAUT2.FieldName = "ANNOAUT";
            this.colANNOAUT2.Name = "colANNOAUT2";
            this.colANNOAUT2.Visible = true;
            this.colANNOAUT2.VisibleIndex = 17;
            // 
            // colNUMEROAUT2
            // 
            this.colNUMEROAUT2.Caption = "NUMEROAUT";
            this.colNUMEROAUT2.FieldName = "NUMEROAUT";
            this.colNUMEROAUT2.Name = "colNUMEROAUT2";
            this.colNUMEROAUT2.Visible = true;
            this.colNUMEROAUT2.VisibleIndex = 18;
            // 
            // colDATAINIZIOVALIDITÀ2
            // 
            this.colDATAINIZIOVALIDITÀ2.Caption = "DATAINIZIOVALIDITÀ";
            this.colDATAINIZIOVALIDITÀ2.FieldName = "DATAINIZIOVALIDITÀ";
            this.colDATAINIZIOVALIDITÀ2.Name = "colDATAINIZIOVALIDITÀ2";
            this.colDATAINIZIOVALIDITÀ2.Visible = true;
            this.colDATAINIZIOVALIDITÀ2.VisibleIndex = 19;
            // 
            // colDATAFINEVALIDITÀ2
            // 
            this.colDATAFINEVALIDITÀ2.Caption = "DATAFINEVALIDITÀ";
            this.colDATAFINEVALIDITÀ2.FieldName = "DATAFINEVALIDITÀ";
            this.colDATAFINEVALIDITÀ2.Name = "colDATAFINEVALIDITÀ2";
            this.colDATAFINEVALIDITÀ2.Visible = true;
            this.colDATAFINEVALIDITÀ2.VisibleIndex = 20;
            // 
            // colANNOREVOCA2
            // 
            this.colANNOREVOCA2.Caption = "ANNOREVOCA";
            this.colANNOREVOCA2.FieldName = "ANNOREVOCA";
            this.colANNOREVOCA2.Name = "colANNOREVOCA2";
            this.colANNOREVOCA2.Visible = true;
            this.colANNOREVOCA2.VisibleIndex = 21;
            // 
            // colNUMEROREVOCA1
            // 
            this.colNUMEROREVOCA1.Caption = "NUMEROREVOCA";
            this.colNUMEROREVOCA1.FieldName = "NUMEROREVOCA";
            this.colNUMEROREVOCA1.Name = "colNUMEROREVOCA1";
            this.colNUMEROREVOCA1.Visible = true;
            this.colNUMEROREVOCA1.VisibleIndex = 22;
            // 
            // colDATAREVOCA2
            // 
            this.colDATAREVOCA2.Caption = "DATAREVOCA";
            this.colDATAREVOCA2.FieldName = "DATAREVOCA";
            this.colDATAREVOCA2.Name = "colDATAREVOCA2";
            this.colDATAREVOCA2.Visible = true;
            this.colDATAREVOCA2.VisibleIndex = 23;
            // 
            // colNOTEAUT2
            // 
            this.colNOTEAUT2.Caption = "NOTEAUT";
            this.colNOTEAUT2.FieldName = "NOTEAUT";
            this.colNOTEAUT2.Name = "colNOTEAUT2";
            this.colNOTEAUT2.Visible = true;
            this.colNOTEAUT2.VisibleIndex = 24;
            // 
            // colCOGNOME2
            // 
            this.colCOGNOME2.Caption = "COGNOME";
            this.colCOGNOME2.FieldName = "COGNOME";
            this.colCOGNOME2.Name = "colCOGNOME2";
            this.colCOGNOME2.Visible = true;
            this.colCOGNOME2.VisibleIndex = 25;
            // 
            // colNOME2
            // 
            this.colNOME2.Caption = "NOME";
            this.colNOME2.FieldName = "NOME";
            this.colNOME2.Name = "colNOME2";
            this.colNOME2.Visible = true;
            this.colNOME2.VisibleIndex = 26;
            // 
            // colSOPRALLUOGO2
            // 
            this.colSOPRALLUOGO2.Caption = "SOPRALLUOGO";
            this.colSOPRALLUOGO2.FieldName = "SOPRALLUOGO";
            this.colSOPRALLUOGO2.Name = "colSOPRALLUOGO2";
            this.colSOPRALLUOGO2.Visible = true;
            this.colSOPRALLUOGO2.VisibleIndex = 27;
            // 
            // colSOP_DATA2
            // 
            this.colSOP_DATA2.Caption = "SOP_DATA";
            this.colSOP_DATA2.FieldName = "SOP_DATA";
            this.colSOP_DATA2.Name = "colSOP_DATA2";
            this.colSOP_DATA2.Visible = true;
            this.colSOP_DATA2.VisibleIndex = 28;
            // 
            // colSOP_DATARICONSEGNA2
            // 
            this.colSOP_DATARICONSEGNA2.Caption = "SOP_DATARICONSEGNA";
            this.colSOP_DATARICONSEGNA2.FieldName = "SOP_DATARICONSEGNA";
            this.colSOP_DATARICONSEGNA2.Name = "colSOP_DATARICONSEGNA2";
            this.colSOP_DATARICONSEGNA2.Visible = true;
            this.colSOP_DATARICONSEGNA2.VisibleIndex = 29;
            // 
            // colSOSTITUTI2
            // 
            this.colSOSTITUTI2.Caption = "SOSTITUTI";
            this.colSOSTITUTI2.FieldName = "SOSTITUTI";
            this.colSOSTITUTI2.Name = "colSOSTITUTI2";
            this.colSOSTITUTI2.Visible = true;
            this.colSOSTITUTI2.VisibleIndex = 30;
            // 
            // colATC_CODICE
            // 
            this.colATC_CODICE.Caption = "ATC_CODICE";
            this.colATC_CODICE.FieldName = "ATC_CODICE";
            this.colATC_CODICE.Name = "colATC_CODICE";
            this.colATC_CODICE.OptionsColumn.ReadOnly = true;
            this.colATC_CODICE.Visible = true;
            this.colATC_CODICE.VisibleIndex = 31;
            // 
            // capE_APPOSTAMENTITableAdapter1
            // 
            this.capE_APPOSTAMENTITableAdapter1.ClearBeforeFill = true;
            // 
            // capE_TMPAPPOSTAMENTITableAdapter1
            // 
            this.capE_TMPAPPOSTAMENTITableAdapter1.ClearBeforeFill = true;
            // 
            // capE_LIMITI_ATCTableAdapter1
            // 
            this.capE_LIMITI_ATCTableAdapter1.ClearBeforeFill = true;
            // 
            // bwork
            // 
            this.bwork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwork_DoWork);
            this.bwork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwork_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 453);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Synch appostamenti";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gisDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsNonCensiti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGetApp;
        private System.Windows.Forms.ToolStripButton tsbUpdApp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colOBJECTID;
        private DevExpress.XtraGrid.Columns.GridColumn colNOME1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colATC1;
        private DevExpress.XtraGrid.Columns.GridColumn colORD1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATO1;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAARCHIVIAZIONE1;
        private DevExpress.XtraGrid.Columns.GridColumn colANNATAVENATORIA_ATTI1;
        private DevExpress.XtraGrid.Columns.GridColumn colPREPARCOBAIONAPIOMBONI1;
        private DevExpress.XtraGrid.Columns.GridColumn colTIPOAPPOST1;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMUNE1;
        private DevExpress.XtraGrid.Columns.GridColumn colFRAZIONE1;
        private DevExpress.XtraGrid.Columns.GridColumn colVIA1;
        private DevExpress.XtraGrid.Columns.GridColumn colFONDO1;
        private DevExpress.XtraGrid.Columns.GridColumn colNSUSS1;
        private DevExpress.XtraGrid.Columns.GridColumn colPROPRIETA1;
        private DevExpress.XtraGrid.Columns.GridColumn colCONDUTTORE1;
        private DevExpress.XtraGrid.Columns.GridColumn colOPZIONE1;
        private DevExpress.XtraGrid.Columns.GridColumn colSUPERFICIEATTUALE1;
        private DevExpress.XtraGrid.Columns.GridColumn colANNOAUT1;
        private DevExpress.XtraGrid.Columns.GridColumn colNUMEROAUT1;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAINIZIOVALIDITÀ1;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAFINEVALIDITÀ1;
        private DevExpress.XtraGrid.Columns.GridColumn colANNOREVOCA1;
        private DevExpress.XtraGrid.Columns.GridColumn colNUMREVOCA;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAREVOCA1;
        private DevExpress.XtraGrid.Columns.GridColumn colCOGNOME1;
        private DevExpress.XtraGrid.Columns.GridColumn colSOPRALLUOGO1;
        private DevExpress.XtraGrid.Columns.GridColumn colSOP_DATA1;
        private DevExpress.XtraGrid.Columns.GridColumn colSOP_DATARICONSEGNA1;
        private DevExpress.XtraGrid.Columns.GridColumn colNOTE;
        private DevExpress.XtraGrid.Columns.GridColumn colTIPO;
        private DevExpress.XtraGrid.Columns.GridColumn colNOTEAUT1;
        private DevExpress.XtraGrid.Columns.GridColumn colSOSTITUTI1;
        private DevExpress.XtraGrid.Columns.GridColumn colAUT_COM;
        private GisDataSet gisDataSet1;
        private SyncModule.GisDataSetTableAdapters.CAPE_APPOSTAMENTITableAdapter capE_APPOSTAMENTITableAdapter1;
        private SyncModule.GisDataSetTableAdapters.CAPE_TMPAPPOSTAMENTITableAdapter capE_TMPAPPOSTAMENTITableAdapter1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATO;
        private DevExpress.XtraGrid.Columns.GridColumn colID1;
        private DevExpress.XtraGrid.Columns.GridColumn colATC;
        private DevExpress.XtraGrid.Columns.GridColumn colORD;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAARCHIVIAZIONE;
        private DevExpress.XtraGrid.Columns.GridColumn colANNATAVENATORIA_ATTI;
        private DevExpress.XtraGrid.Columns.GridColumn colPREPARCOBAIONAPIOMBONI;
        private DevExpress.XtraGrid.Columns.GridColumn colTIPOAPPOST;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMUNE;
        private DevExpress.XtraGrid.Columns.GridColumn colFRAZIONE;
        private DevExpress.XtraGrid.Columns.GridColumn colVIA;
        private DevExpress.XtraGrid.Columns.GridColumn colFONDO;
        private DevExpress.XtraGrid.Columns.GridColumn colNSUSS;
        private DevExpress.XtraGrid.Columns.GridColumn colPROPRIETA;
        private DevExpress.XtraGrid.Columns.GridColumn colCONDUTTORE;
        private DevExpress.XtraGrid.Columns.GridColumn colOPZIONE;
        private DevExpress.XtraGrid.Columns.GridColumn colSUPERFICIEATTUALE;
        private DevExpress.XtraGrid.Columns.GridColumn colANNOAUT;
        private DevExpress.XtraGrid.Columns.GridColumn colNUMEROAUT;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAINIZIOVALIDITÀ;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAFINEVALIDITÀ;
        private DevExpress.XtraGrid.Columns.GridColumn colANNOREVOCA;
        private DevExpress.XtraGrid.Columns.GridColumn colNUMEROREVOCA;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAREVOCA;
        private DevExpress.XtraGrid.Columns.GridColumn colNOTEAUT;
        private DevExpress.XtraGrid.Columns.GridColumn colCOGNOME;
        private DevExpress.XtraGrid.Columns.GridColumn colNOME;
        private DevExpress.XtraGrid.Columns.GridColumn colSOPRALLUOGO;
        private DevExpress.XtraGrid.Columns.GridColumn colSOP_DATA;
        private DevExpress.XtraGrid.Columns.GridColumn colSOP_DATARICONSEGNA;
        private DevExpress.XtraGrid.Columns.GridColumn colSOSTITUTI;
        private SyncModule.GisDataSetTableAdapters.CAPE_LIMITI_ATCTableAdapter capE_LIMITI_ATCTableAdapter1;
        private GisDataSet dsNonCensiti;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATO2;
        private DevExpress.XtraGrid.Columns.GridColumn colID2;
        private DevExpress.XtraGrid.Columns.GridColumn colATC2;
        private DevExpress.XtraGrid.Columns.GridColumn colORD2;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAARCHIVIAZIONE2;
        private DevExpress.XtraGrid.Columns.GridColumn colANNATAVENATORIA_ATTI2;
        private DevExpress.XtraGrid.Columns.GridColumn colPREPARCOBAIONAPIOMBONI2;
        private DevExpress.XtraGrid.Columns.GridColumn colTIPOAPPOST2;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMUNE2;
        private DevExpress.XtraGrid.Columns.GridColumn colFRAZIONE2;
        private DevExpress.XtraGrid.Columns.GridColumn colVIA2;
        private DevExpress.XtraGrid.Columns.GridColumn colFONDO2;
        private DevExpress.XtraGrid.Columns.GridColumn colNSUSS2;
        private DevExpress.XtraGrid.Columns.GridColumn colPROPRIETA2;
        private DevExpress.XtraGrid.Columns.GridColumn colCONDUTTORE2;
        private DevExpress.XtraGrid.Columns.GridColumn colOPZIONE2;
        private DevExpress.XtraGrid.Columns.GridColumn colSUPERFICIEATTUALE2;
        private DevExpress.XtraGrid.Columns.GridColumn colANNOAUT2;
        private DevExpress.XtraGrid.Columns.GridColumn colNUMEROAUT2;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAINIZIOVALIDITÀ2;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAFINEVALIDITÀ2;
        private DevExpress.XtraGrid.Columns.GridColumn colANNOREVOCA2;
        private DevExpress.XtraGrid.Columns.GridColumn colNUMEROREVOCA1;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAREVOCA2;
        private DevExpress.XtraGrid.Columns.GridColumn colNOTEAUT2;
        private DevExpress.XtraGrid.Columns.GridColumn colCOGNOME2;
        private DevExpress.XtraGrid.Columns.GridColumn colNOME2;
        private DevExpress.XtraGrid.Columns.GridColumn colSOPRALLUOGO2;
        private DevExpress.XtraGrid.Columns.GridColumn colSOP_DATA2;
        private DevExpress.XtraGrid.Columns.GridColumn colSOP_DATARICONSEGNA2;
        private DevExpress.XtraGrid.Columns.GridColumn colSOSTITUTI2;
        private DevExpress.XtraGrid.Columns.GridColumn colATC_CODICE;
        private System.ComponentModel.BackgroundWorker bwork;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}

