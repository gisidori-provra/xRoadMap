using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace xRoadMap.Module.BusinessObjects
{

    public enum VisibilityMode
    {
        //
        // Riepilogo:
        //     Visibility is determined automatically.
        Auto,
        //
        // Riepilogo:
        //     An element is visible.
        Visible,
        //
        // Riepilogo:
        //     An element is hidden.
        Hidden
    }

    public enum TipoPosizione
    {
        ProgressivaChilometrica=0,       //Progressiva chilometrica su strada
        Coordinate=1,                    //Coordinate geografiche
        //Toponomastica,                 //Via e Numero Civico
        //Catasto,                       //Dati catastali
    }

    public enum TipoCoordinata
    {
        Geografica=0,
        Proiettata=1
    }


    public enum LivelloGrafo
    {
        LivelloComune = 0,
        Livello1 = 1,
        Livello2 = 2
    }

    public enum TipoGeometriaEvento
    {
        Puntuale=0,
        Lineare=1
    }

    public enum StatoGrafo
    {
        Default=0,
        Bozza = 1,
        Definitivo = 2
    }

    public enum TipoPercorrenza
    {
        Libero,
        SensoUnicoVersoCrescenteProgressivaChilometrica,
        SensoUnicoVersoDecrescenteProgressivaChilometrica,
        SensoUnicoAlternato,
        StradaInterrotta
    }

    public enum TipoSagoma
    {
        Libero,
        Larghezza,
        Lunghezza
    }
}