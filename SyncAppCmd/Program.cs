using System;
using System.Collections.Generic;
using System.Text;

namespace SyncAppCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cmd = "synch";
                if (args.Length != 0)
                    cmd = args[0];
                switch (cmd.ToLower())
                {
                    case "synch":
                        SyncModule.Sync.ImportaAppostamenti();
                        SyncModule.Sync.UpdateAppostamenti();
                        break;
                    case "load":
                        SyncModule.Sync.ImportaAppostamenti();
                        break;
                    case "update":
                        SyncModule.Sync.UpdateAppostamenti();
                        break;
                    default:
                       ShowUsage(cmd);
                       break;
               }
                System.Console.WriteLine("Comando eseguito");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        static void ShowUsage(string cmd)
        {
            System.Console.WriteLine(string.Format("Comando {0} non valido",cmd));
            System.Console.WriteLine();
            System.Console.WriteLine("Utilizzo: SyncAppCmd [Synch|Load|Update]");
            System.Console.WriteLine();
            System.Console.WriteLine("Synch: sincronizza entrambi i database");
            System.Console.WriteLine("Load: Carica dati da database appostamenti");
            System.Console.WriteLine("Update: aggiorna feature class Appostamenti su SDE");
            System.Console.WriteLine();

        }
        


    }
}
