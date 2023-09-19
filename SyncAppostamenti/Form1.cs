using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SyncAppostamenti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            Cursor = Cursors.WaitCursor;
            bwork.RunWorkerAsync("Load");
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            Cursor = Cursors.WaitCursor;
            bwork.RunWorkerAsync("Load");
        }

        private void LoadData()
        {
            try
            {
                capE_LIMITI_ATCTableAdapter1.Fill(gisDataSet1.CAPE_LIMITI_ATC);
                capE_TMPAPPOSTAMENTITableAdapter1.Fill(gisDataSet1.CAPE_TMPAPPOSTAMENTI);
                capE_APPOSTAMENTITableAdapter1.Fill(gisDataSet1.CAPE_APPOSTAMENTI);
                capE_TMPAPPOSTAMENTITableAdapter1.FillNonCensiti(dsNonCensiti.CAPE_TMPAPPOSTAMENTI);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connessione non riuscita", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbSynch_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            Cursor = Cursors.WaitCursor;
            bwork.RunWorkerAsync("Synch");
        }

        private void bwork_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (e.Argument.ToString())
            {
                case "Synch":
                    SyncModule.Sync.ImportaAppostamenti();
                    SyncModule.Sync.UpdateAppostamenti();
                    LoadData();
                    break;
                case "Load":
                    LoadData();
                    break;
                default:
                    break;
            }
        }

        private void bwork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStripProgressBar1.Visible = false;
            this.Cursor = Cursors.Default;
        }
    }
}
