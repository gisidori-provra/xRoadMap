using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using System.Data;
using System.Globalization;

namespace ImportTransiti
{
    class Program
    {
        static void Main(string[] args)
        {
            bool mts = false;
            bool pasvc = false;
            string pasvcPath = @"C:\PASVC";

            System.Console.WriteLine("Utilizzo: Import [-mts] [-pasvc] [cartellaLogPasvc]");

            for (int i=0;i<args.Length;i++)
            {
                var arg = args[i];
                switch (arg.ToLower())
                {
                    case "-mts":
                        mts = true;
                        break;
                    case "-pasvc":
                        pasvc = true;
                        if (i+1 < args.Length)
                            pasvcPath = args[++i];
                        break;
                    default:
                        break;
                }
            }

            if (pasvc)
                ImportaPASVC(pasvcPath);
            if (mts)
                ImportaMTS();

        }
        static void ImportaPASVC(string rootFolder)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            var dt = new TrafficoMTS.LogDataTable();
            var date = System.DateTime.Now;
            var folder = rootFolder;

            var ds = new TrafficoMTS();
            TrafficoMTSTableAdapters.TransitiTableAdapter ta = new TrafficoMTSTableAdapters.TransitiTableAdapter();
            TrafficoMTSTableAdapters.RETI_TRAFFICO_POSTAZIONITableAdapter taPost = new TrafficoMTSTableAdapters.RETI_TRAFFICO_POSTAZIONITableAdapter();
            taPost.Fill(ds.RETI_TRAFFICO_POSTAZIONI);

            foreach (var gate in Directory.EnumerateDirectories(folder))
            {
                int numeroGate = int.Parse(gate.Substring(gate.Length-3, 3));
                var post = ds.RETI_TRAFFICO_POSTAZIONI.FirstOrDefault(p => p.FONTE == "PASVC" && p.POSTAZIONE == numeroGate);
                decimal postazione = 0;

                if (post != null)
                    postazione = post.OBJECTID;

                foreach (var file in System.IO.Directory.EnumerateFileSystemEntries(gate, "*.csv", SearchOption.AllDirectories))
                {
                    using (CsvReader csv = new CsvReader(new StreamReader(file), true, ';'))
                    {
                        ImportTable(csv, dt);
                    }
                }


                var dtTransiti = ds.Transiti;
                var group = from l in dt
                            where l.IsSITE_ADDRESSNull() && l.IsDATENull() == false && l.IsTIMENull() == false
                            group l by new { DataInizio = DateTime.ParseExact(l.DATE,"yyyy-MM-dd",provider), Notturno= IsNightly(l.TIME)} into g
                            select new { g.Key, Count = g.Count() };

                foreach (var g in group)
                {
                    decimal count = (decimal)ta.Exists(postazione, g.Key.DataInizio.ToString("dd/MM/yyyy"));
                    if (count == 0)
                    {
                        AddRow(ds, g.Key.DataInizio,g.Key.DataInizio.AddDays(1), postazione, "0", "Orario", g.Key.Notturno ? "Notturno" : "Diurno", g.Count.ToString());
                    }
                }



            }

            ta.Update(ds);


        }

        private static bool IsNightly(string time)
        {
            int ora;
            if (int.TryParse(time.Substring(0, 2), out ora))
                return ora < 06 || ora > 22;
            return false;
        }

        static void ImportTable(CsvReader csv, DataTable dt)
        {
            int fieldCount = csv.FieldCount;

            string[] headers = csv.GetFieldHeaders();
            while (csv.ReadNextRecord())
            {
                var row = dt.NewRow();
                for (int i = 0; i < fieldCount; i++)
                {
                    if (dt.Columns.Contains(headers[i]) && csv[i] != headers[i])    
                        row[headers[i]] = csv[i];
                }
                dt.Rows.Add(row);
            }

        }

        static void ImportaMTS()
        { 
            var dt = new TrafficoMTS.FlussiDataTable();
            using (CsvReader csv = new CsvReader(new StreamReader("RilevazioniPerCorsia.csv"), true, ';'))
            {
                ImportTable(csv, dt);
            }

            var ds = new TrafficoMTS();
            TrafficoMTSTableAdapters.TransitiTableAdapter ta = new TrafficoMTSTableAdapters.TransitiTableAdapter();
            TrafficoMTSTableAdapters.RETI_TRAFFICO_POSTAZIONITableAdapter taPost = new TrafficoMTSTableAdapters.RETI_TRAFFICO_POSTAZIONITableAdapter();

            taPost.Fill(ds.RETI_TRAFFICO_POSTAZIONI);
            var dtTransiti = ds.Transiti;

            foreach (var row in dt)
            {
                int anno = int.Parse(row.ANNOMESE.Substring(0, 4));
                int mese = int.Parse(row.ANNOMESE.Substring(5, 2));
                var corsia = row.CORSIA.Substring(0, 1);

                DateTime dataInizio = new DateTime(anno, mese, 1).Date;
                DateTime dataFine = new DateTime(anno, mese, new DateTime(anno, mese, 1).AddMonths(1).AddDays(-1).Day).Date;
                var post = ds.RETI_TRAFFICO_POSTAZIONI.FirstOrDefault(p => p.FONTE == "MTS" && p.POSTAZIONE == decimal.Parse(row.POSTAZIONE));
                if (post == null)
                    continue;
                decimal postazione = post.OBJECTID;
                decimal count = (decimal)ta.Exists(postazione, dataInizio.ToShortDateString());
                if (count==0)
                {
                    AddRow(ds, dataInizio, dataFine, postazione, corsia, "Orario", "Notturno", row._TRANSITI___NOTTURNO);
                    AddRow(ds, dataInizio, dataFine, postazione, corsia, "Orario", "Diurno", row._TRANSITI___DIURNO);
                    AddRow(ds, dataInizio, dataFine, postazione, corsia, "Giorno", "Feriale", row._TRANSITI___FERIALI);
                    AddRow(ds, dataInizio, dataFine, postazione, corsia, "Giorno", "Festivo", row._TRANSITI___FESTIVI);
                    AddRow(ds, dataInizio, dataFine, postazione, corsia, "Tipo", "Leggero", row._TRANSITI___LEGGERI);
                    AddRow(ds, dataInizio, dataFine, postazione, corsia, "Tipo", "Pesante", row._TRANSITI___PESANTI);
                    AddRow(ds, dataInizio, dataFine, postazione, corsia, "Tipo", "NC", row._TRANSITI___NON_CLASSIFICATO);
                }
            }
            ta.Update(ds.Transiti);
            
        }
        private static decimal last_oid = 0;
        private static TrafficoMTS.TransitiRow AddRow(TrafficoMTS ds,DateTime dataInizio,DateTime dataFine,decimal postazione, string corsia,string serie, string classe,string sTransiti)
        {
            int transiti;

            if (int.TryParse(sTransiti, System.Globalization.NumberStyles.AllowThousands,System.Globalization.CultureInfo.CurrentCulture.NumberFormat, out transiti) == false)
                return null;

          
            var nRow = ds.Transiti.NewTransitiRow();
            nRow.DATAINIZIO = dataInizio;
            nRow.DATAFINE = dataFine;
            nRow.OID_POSTAZIONE = postazione;
            nRow.CORSIA = corsia;
            nRow.SERIE = serie;
            nRow.CLASSE = classe;
            nRow.TRANSITI = transiti;
            nRow.OBJECTID = last_oid++;
            ds.Transiti.AddTransitiRow(nRow);
            return nRow;

        }

    }

}
