# ABTPrivateWorkspace

Kleines C#-Konsolenprojekt zum Einstieg in die ABT-Openness-gRPC-API. Das Beispiel registriert den Client, haelt den Heartbeat aktiv und fragt Projekte ab.

## Voraussetzungen

- .NET 10 SDK
- ABT Site und der laufende ABTOpenness-Server
- Die lokal installierten ABTOpenness-Proto-Dateien

Die Proto-Dateien werden nicht in dieses Repository kopiert. Die Siemens-Unterlagen sind als "Restricted" gekennzeichnet. Das Projekt verwendet standardmaessig diesen lokalen Ordner:

`C:\Program Files\Siemens\ABT Site\Bin\ABTOpennessDocumentation\Proto Files`

Falls die Dateien bei dir woanders liegen, kannst du den Ordner beim Start angeben:

```powershell
dotnet run --property:ABTOpennessProtoDir="C:\Pfad\zu\Proto Files"
```

## Starten

1. `Program.cs` oeffnen und Serveradresse sowie Projektordner anpassen.
2. Im Repository-Ordner `dotnet run` ausfuehren.

Der Standard ist `https://localhost:8086` und `C:\ABTProjects`. Das HTTPS-Zertifikat des Servers muss auf dem Rechner vertrauenswuerdig sein.
