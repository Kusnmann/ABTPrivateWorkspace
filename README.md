# ABTPrivateWorkspace

C#-Konsolenprojekt zum Einstieg in die ABT-Openness-gRPC-API. Es registriert einen Client und listet Projekte im angegebenen Ordner auf.

## Voraussetzungen

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- ABT Site und laufender ABTOpenness-Server
- Die lokal installierten ABTOpenness-Proto-Dateien
- Das Verzeichnis `D:\XWP_Projects` muss existieren und fuer den ABTOpenness-Server erreichbar sein

Die Siemens-Unterlagen sind als "Restricted" gekennzeichnet und werden nicht in dieses oeffentliche Repository kopiert. Das Projekt verwendet standardmaessig die lokal installierten Proto-Dateien aus:

`C:\Program Files\Siemens\ABT Site\Bin\ABTOpennessDocumentation\Proto Files`

Falls die Proto-Dateien bei dir woanders liegen, kannst du den Pfad beim Start angeben:

```powershell
dotnet run --project .\ABTPrivateWorkspace.csproj --property:ABTOpennessProtoDir="C:\Pfad\zu\Proto Files"
```

## Starten und pruefen

Installiere zuerst das .NET 10 SDK. Dein aktuelles SDK 8.0.427 kann dieses Projekt mit Ziel `net10.0` nicht bauen. Pruefe nach der Installation:

```powershell
dotnet --list-sdks
```

Die Liste muss ein SDK `10.x` enthalten.

### Mit Git

Pruefe, ob Git installiert ist:

```powershell
git --version
```

Wenn eine Versionsnummer erscheint, klone das Projekt und wechsle in den Ordner:

```powershell
git clone https://github.com/Kusnmann/ABTPrivateWorkspace.git
Set-Location .\ABTPrivateWorkspace
```

### Ohne Git

Auf GitHub **Code > Download ZIP** waehlen und das Archiv nach `D:\Test` entpacken. Der entpackte Ordner heisst normalerweise `ABTPrivateWorkspace-main`.

```powershell
Set-Location D:\Test\ABTPrivateWorkspace-main
```

### Starten

Im Projektordner ausfuehren:

```powershell
dotnet run --project .\ABTPrivateWorkspace.csproj
```

Bei Erfolg erscheinen `Connected to ABTOpenness.`, `Projects found: ...` und fuer jedes gefundene Projekt ein `Project key`.

## Fehler eingrenzen

- `git` wird nicht erkannt: Git installieren oder den ZIP-Weg verwenden.
- `NETSDK1045`: .NET 10 SDK installieren; .NET 8 reicht fuer `net10.0` nicht.
- `Registration failed`: Die Registrierung wurde vom Server abgelehnt; die angezeigte Meldung hilft bei der Ursache.
- `Unavailable` oder ein Zertifikatsfehler: Serverstatus, Adresse `https://localhost:8086` und Zertifikatsvertrauen pruefen.
- `Projects found: 0`: Pruefen, ob `D:\XWP_Projects` der richtige Ordner ist und Projekte enthaelt.
- Proto-Datei nicht gefunden: Pfad `ABTOpennessProtoDir` kontrollieren.
