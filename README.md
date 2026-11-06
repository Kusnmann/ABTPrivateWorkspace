# ABTPrivateWorkspace

C#-Konsolenprojekt zum Einstieg in die ABT-Openness-gRPC-API. Es registriert einen Client und listet Projekte im angegebenen Ordner auf.

## Voraussetzungen

- .NET 10 SDK
- ABT Site und laufender ABTOpenness-Server
- Die lokal installierten ABTOpenness-Proto-Dateien
- Das Verzeichnis `D:\XWP_Projects` muss existieren und fuer den ABTOpenness-Server erreichbar sein

Die Siemens-Unterlagen sind als "Restricted" gekennzeichnet und werden nicht in dieses oeffentliche Repository kopiert. Das Projekt verwendet standardmaessig die lokal installierten Proto-Dateien aus:

`C:\Program Files\Siemens\ABT Site\Bin\ABTOpennessDocumentation\Proto Files`

Falls die Proto-Dateien bei dir woanders liegen, kannst du den Pfad beim Start angeben:

```powershell
dotnet run --property:ABTOpennessProtoDir="C:\Pfad\zu\Proto Files"
```

## Starten und pruefen

1. Repository klonen und in den Ordner wechseln:

```powershell
git clone https://github.com/Kusnmann/ABTPrivateWorkspace.git
cd ABTPrivateWorkspace
```

2. `dotnet --version` ausfuehren. Die Ausgabe muss mit `10.` beginnen.
3. ABTOpenness starten und sicherstellen, dass das HTTPS-Zertifikat auf dem Rechner vertrauenswuerdig ist.
4. Im Repository-Ordner starten:

```powershell
dotnet run
```

Bei Erfolg erscheinen `Connected to ABTOpenness.`, `Projects found: ...` und fuer jedes gefundene Projekt ein `Project key`.

## Fehler eingrenzen

- `Registration failed`: Die Registrierung wurde vom Server abgelehnt; die angezeigte Meldung hilft bei der Ursache.
- `Unavailable` oder ein Zertifikatsfehler: Serverstatus, Adresse `https://localhost:8086` und Zertifikatsvertrauen pruefen.
- `Projects found: 0`: Pruefen, ob `D:\XWP_Projects` der richtige Ordner ist und Projekte enthaelt.
- Proto-Datei nicht gefunden: Pfad `ABTOpennessProtoDir` kontrollieren.
