# ABTPrivateWorkspace

Kleines C#-Beispiel fuer einen Client, der sich bei ABTOpenness registriert und Projektinformationen abfragt.

## Beispiel

`Program.cs` verbindet sich mit dem gRPC-Server, wartet auf die erste Registrierungsantwort, liest den Heartbeat-Stream weiter und ruft danach `GetProjects` auf.

## Voraussetzungen

Der Stand ist noch kein eigenstaendig startbares .NET-Projekt. Zum Bauen werden benoetigt:

- das .NET SDK
- `Grpc.Net.Client` und die passenden gRPC-Abhaengigkeiten
- die Siemens-ABTOpenness-gRPC-Clienttypen, die den Namespace `Siemens.BASys.ABTOpenness.Services.Grpc` bereitstellen

Die Siemens-Clienttypen sind hier noch nicht enthalten. Deshalb kann der Code noch nicht mit `dotnet run` gestartet werden. Als naechster Schritt muss geklaert werden, aus welchem Siemens-SDK, NuGet-Paket oder generierten Quellcode diese Typen bezogen werden.

## Lokale Einstellungen

In `Program.cs` sind derzeit diese Beispielwerte eingetragen:

- Server: `https://localhost:8086`
- Projektordner: `C:\ABTProjects`

Passe sie an deine ABTOpenness-Installation an. Bei HTTPS muss das Serverzertifikat vom Rechner als vertrauenswuerdig akzeptiert werden.
