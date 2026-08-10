using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;

namespace SyncModule
{
    public static class Sync
    {

        public static void ImportaAppostamenti()
        {

            using (GisDataSetTableAdapters.vwCustomSITTableAdapter ta = new SyncModule.GisDataSetTableAdapters.vwCustomSITTableAdapter())
            {
                using (GisDataSetTableAdapters.CAPE_TMPAPPOSTAMENTITableAdapter taTmp = new SyncModule.GisDataSetTableAdapters.CAPE_TMPAPPOSTAMENTITableAdapter())
                {
                    taTmp.Adapter.RowUpdated += new OracleRowUpdatedEventHandler(Adapter_RowUpdated);
                    OracleExecuteNonQuery("DELETE FROM SIT.CAPE_TMPAPPOSTAMENTI", CommandType.Text);
                    GisDataSet ds = new GisDataSet();
                   
                    ta.FillByMaxID(ds.vwSIT,300);
                    foreach (GisDataSet.vwSITRow row in ds.vwSIT)
                    {
                        GisDataSet.CAPE_TMPAPPOSTAMENTIRow nRow = ds.CAPE_TMPAPPOSTAMENTI.NewCAPE_TMPAPPOSTAMENTIRow();
                        //nRow.OBJECTID = 0;
                        foreach (DataColumn col in ds.CAPE_TMPAPPOSTAMENTI.Columns)
                        {
                            if (ds.vwSIT.Columns.Contains(col.ColumnName))
                            {
                                if (row.IsNull(col.ColumnName) || row[col.ColumnName].Equals(""))
                                    nRow[col.ColumnName] = global::System.Convert.DBNull;
                                else
                                    nRow[col] = row[col.ColumnName];
                            }
                        }
                        ds.CAPE_TMPAPPOSTAMENTI.AddCAPE_TMPAPPOSTAMENTIRow(nRow);
                    }
                    taTmp.Update(ds.CAPE_TMPAPPOSTAMENTI);
                }
            }

        }

        static void Adapter_RowUpdated(object sender, OracleRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.ErrorsOccurred)
            {
                System.Console.WriteLine(e.Errors.ToString());
                OracleCommand cmd = (OracleCommand)e.Command;
                
            }
        }

        public static void UpdateAppostamenti()
        {
            //OracleExecuteNonQuery("UpdateAppostamenti",CommandType.StoredProcedure);

            GisDataSet ds = new GisDataSet();
           

            GisDataSetTableAdapters.CAPE_TMPAPPOSTAMENTITableAdapter taTmp = new SyncModule.GisDataSetTableAdapters.CAPE_TMPAPPOSTAMENTITableAdapter();
            GisDataSetTableAdapters.CAPE_APPOSTAMENTITableAdapter ta = new SyncModule.GisDataSetTableAdapters.CAPE_APPOSTAMENTITableAdapter();
            GisDataSetTableAdapters.CAPE_LIMITI_ATCTableAdapter taAtc = new SyncModule.GisDataSetTableAdapters.CAPE_LIMITI_ATCTableAdapter();

            taAtc.Fill(ds.CAPE_LIMITI_ATC);
            taTmp.Fill(ds.CAPE_TMPAPPOSTAMENTI);
            ta.Fill(ds.CAPE_APPOSTAMENTI);

            foreach (GisDataSet.CAPE_APPOSTAMENTIRow nRow in ds.CAPE_APPOSTAMENTI)
            {
                if (Convert.IsDBNull(nRow["ATC"]) == false && Convert.IsDBNull(nRow["ORD"]) == false)
                {
                    GisDataSet.CAPE_TMPAPPOSTAMENTIRow row = ds.CAPE_TMPAPPOSTAMENTI.FirstOrDefault(r=>r.ATC == nRow.ATC && r.ORD == nRow.ORD);
                    if (row != null)
                    {
                        foreach (DataColumn col in ds.CAPE_TMPAPPOSTAMENTI.Columns)
                        {
                            if (ds.CAPE_APPOSTAMENTI.Columns.Contains(col.ColumnName))
                            {
                                if (row.IsNull(col) || row[col].Equals(""))
                                    nRow[col.ColumnName] = global::System.Convert.DBNull;
                                else
                                {
                                    if (col.DataType == typeof(string) && col.MaxLength != -1)
                                    {
                                        string s = (string)row[col];
                                        DataColumn destCol = ds.CAPE_APPOSTAMENTI.Columns[col.ColumnName];
                                        int len = s.Length < destCol.MaxLength ? s.Length : destCol.MaxLength;
                                        nRow[col.ColumnName] = ((string)row[col]).Substring(0, len);
                                    }
                                    else
                                    {
                                        nRow[col.ColumnName] = row[col];
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ta.Update(ds.CAPE_APPOSTAMENTI);
        }

        private static void OracleExecuteNonQuery(string spName,CommandType commandType)
        {
            using (OracleCommand cmd = new OracleCommand(spName))
            {
                using (OracleConnection conn = new OracleConnection(Properties.Settings.Default.GisConnectionString))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandType = commandType;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}