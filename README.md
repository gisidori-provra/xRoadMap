# xRoadMap23

Un sistema completo di gestione dell'infrastruttura stradale sviluppato per la Provincia di Ravenna, Italia. Questa applicazione fornisce strumenti per gestire, monitorare e mantenere le reti stradali e l'infrastruttura associata.

## 🚗 Panoramica

xRoadMap23 è un'applicazione desktop Windows costruita con DevExpress XAF (eXpressApp Framework) che consente una gestione efficiente dell'infrastruttura stradale incluse strade, ponti, gallerie, sistemi di illuminazione, vegetazione e vario arredo stradale. Il sistema si integra con database spaziali e fornisce strumenti completi per il monitoraggio e la reportistica dell'infrastruttura.

## ✨ Caratteristiche Principali

- **Gestione Rete Stradale**: Gestione completa di segmenti stradali, intersezioni e routing
- **Monitoraggio Infrastrutture**: Monitoraggio di ponti, gallerie, illuminazione, vegetazione e altro arredo stradale
- **Integrazione Dati Spaziali**: Capacità GIS con supporto database spaziali (Oracle SDE)
- **Gestione Ordinanze**: Tracciamento e gestione delle ordinanze municipali che influenzano l'infrastruttura stradale
- **Sistema Ispezioni**: Pianificazione e registrazione delle ispezioni dell'infrastruttura
- **Strumenti Sincronizzazione**: Utilità per sincronizzazione dati e import/export
- **Architettura Multi-Modulo**: Design modulare per estensibilità e manutenzione

## 🛠️ Stack Tecnologico

- **.NET Framework 4.8**: Framework applicativo core
- **DevExpress XAF**: Framework per applicazioni enterprise
- **DevExpress Controls**: Componenti UI ricchi (v24.2.7)
- **Oracle Database**: Archiviazione dati primaria con estensioni spaziali
- **NetTopologySuite**: Elaborazione geometrie spaziali
- **Windows Forms**: Framework UI desktop

## 📋 Requisiti di Sistema

### Ambiente di Sviluppo
- **Visual Studio 2017 o successivo**
- **.NET Framework 4.8 Developer Pack**
- **DevExpress Controls v24.2.7** (licenza richiesta)
- **Oracle Data Access Components**

### Ambiente di Esecuzione
- **Windows 10 o successivo**
- **.NET Framework 4.8 Runtime**
- **Oracle Client** (per connettività database)
- **Minimo 4GB RAM**
- **100MB+ spazio disco disponibile**

## 🏗️ Struttura del Progetto

```
xRoadMap/
├── xRoadMap23.sln                    # File soluzione principale
├── SyncAppostamenti.sln              # Soluzione sincronizzazione
├── xRoadMap23.Module/                # Logica business core e modello dati
│   ├── BusinessObjects/              # Entità dominio (strade, ponti, etc.)
│   ├── Controllers/                  # Controller logica business
│   └── DatabaseUpdate/               # Script migrazione database
├── xRoadMap23.Module.Win/            # Moduli UI specifici per Windows
├── xRoadMap23.Win/                   # Applicazione Windows Forms principale
├── xRoadMap23.cspra.Module/          # Estensioni specifiche provinciali
├── SyncAppostamenti/                 # Utilità sincronizzazione dati
├── SyncAppCmd/                       # Strumento sync da riga di comando
├── SyncModule/                       # Modulo sincronizzazione
└── ImportTransiti/                   # Utilità importazione dati traffico
```

## 🚀 Iniziare

### Compilazione dell'Applicazione

1. **Clona il repository**:
   ```bash
   git clone https://github.com/GIsidori/xRoadMap.git
   cd xRoadMap
   ```

2. **Installa i Componenti DevExpress**:
   - Assicurati che DevExpress Universal subscription v24.2.7 sia installato
   - Registra gli assembly DevExpress in GAC se richiesto

3. **Configura la Connessione Database**:
   - Aggiorna le stringhe di connessione nei file `App.config`
   - Assicurati che il database Oracle sia accessibile
   - Esegui gli script di aggiornamento database se necessario

4. **Compila la Soluzione**:
   ```bash
   # Utilizzando Visual Studio
   Apri xRoadMap23.sln in Visual Studio
   Build -> Build Solution (Ctrl+Shift+B)

   # Utilizzando MSBuild
   msbuild xRoadMap23.sln /p:Configuration=Release
   ```

### Esecuzione dell'Applicazione

1. **Applicazione Principale**:
   - Imposta `xRoadMap23.Win` come progetto di avvio
   - Configura la stringa di connessione in `App.config`
   - Premi F5 per eseguire o compila ed esegui l'eseguibile

2. **Strumenti di Sincronizzazione**:
   - Compila `SyncAppostamenti.sln` per le utilità di sincronizzazione dati
   - Usa `SyncAppCmd` per operazioni da riga di comando

## 🗃️ Configurazione Database

L'applicazione richiede un database Oracle con estensioni spaziali. Configura la stringa di connessione nel file `App.config` dell'applicazione:

```xml
<connectionStrings>
    <add name="ConnectionString" 
         connectionString="Data Source=your_server;User Id=your_user;Password=your_password;" 
         providerName="Oracle.ManagedDataAccess.Client" />
</connectionStrings>
```

## 📊 Entità Principali

Il sistema gestisce varie entità dell'infrastruttura stradale:

- **Strada**: Segmenti stradali principali e proprietà
- **Ponte**: Strutture e specifiche dei ponti
- **Galleria**: Infrastruttura gallerie
- **Illuminazione**: Sistemi di illuminazione stradale
- **Vegetazione**: Gestione vegetazione stradale
- **Tombino**: Punti di accesso utility
- **Ordinanza**: Regolamenti municipali
- **Ispezione**: Record ispezioni infrastruttura

## 🔧 Sviluppo

### Aggiungere Nuove Funzionalità

1. **Business Objects**: Aggiungi nuove entità in `xRoadMap23.Module/BusinessObjects/`
2. **Controllers**: Implementa logica business nelle classi controller appropriate
3. **Personalizzazione UI**: Estendi Windows forms in `xRoadMap23.Module.Win/`
4. **Modifiche Database**: Aggiorna schema attraverso il meccanismo di aggiornamento database XAF

### Stile del Codice

- Segui le convenzioni di codifica Microsoft C#
- Usa nomi significativi per classi e metodi
- Documenta le API pubbliche con commenti XML
- Implementa gestione errori e logging appropriati

## 🤝 Contribuire

Questo progetto è mantenuto dalla Provincia di Ravenna. Per contributi:

1. Fai un fork del repository
2. Crea un branch per la nuova funzionalità
3. Implementa le modifiche con test appropriati
4. Invia una pull request con descrizione dettagliata

## 📄 Licenza

Questo progetto è software proprietario sviluppato per la Provincia di Ravenna. Contatta il team di sviluppo per informazioni sulla licenza.

## 📞 Supporto

Per supporto tecnico o domande:

- **Organizzazione**: Provincia di Ravenna
- **Applicazione**: xRoadMap v1.0.0.47
- **Framework**: DevExpress XAF

## 🗺️ Progetti Correlati

- **ImportTransiti**: Utilità importazione dati traffico
- **SyncAppostamenti**: Strumenti sincronizzazione dati
- **SyncModule**: Framework sincronizzazione core

---

*Questa applicazione fa parte dell'iniziativa infrastruttura digitale della Provincia di Ravenna per una gestione e manutenzione efficiente della rete stradale.*