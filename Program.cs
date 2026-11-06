using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Siemens.BASys.ABTOpenness.Services.Grpc;

internal static class Program
{
    private static async Task Main()
    {
        const string serverAddress = "https://localhost:8086";
        const string projectFolder = @"C:\ABTProjects";
        string clientId = Guid.NewGuid().ToString("N");

        using var channel = GrpcChannel.ForAddress(serverAddress);
        using var lifetime = new CancellationTokenSource();
        var registration =
            new ClientRegistrationService.ClientRegistrationServiceClient(channel);
        using var heartbeat = registration.Register(
            new ClientRegistrationRequest { ClientId = clientId },
            cancellationToken: lifetime.Token);

        Task heartbeatTask = Task.CompletedTask;
        try
        {
            using var connectionTimeout =
                CancellationTokenSource.CreateLinkedTokenSource(lifetime.Token);
            connectionTimeout.CancelAfter(TimeSpan.FromSeconds(15));
            if (!await heartbeat.ResponseStream.MoveNext(connectionTimeout.Token))
            {
                Console.WriteLine("Registration stream closed.");
                return;
            }

            Console.WriteLine("Connected to ABTOpenness.");
            heartbeatTask = ReadHeartbeatsAsync(
                heartbeat.ResponseStream, lifetime.Token);

            var projects = new ProjectService.ProjectServiceClient(channel);
            var reply = await projects.GetProjectsAsync(
                new GetProjectsRequest { ProjectFolderRoot = projectFolder },
                deadline: DateTime.UtcNow.AddSeconds(30),
                cancellationToken: lifetime.Token);

            if (reply.Result.Code !=
                (uint)ABTOpennessResultCode.Types.Enum.Success)
            {
                Console.WriteLine($"GetProjects failed: {reply.Result.Code}");
                return;
            }

            Console.WriteLine($"Projects found: {reply.Projects.Count}");
            foreach (var project in reply.Projects)
            {
                Console.WriteLine($"Project key: {project.ProjectKey}");
            }
        }
        catch (RpcException ex)
        {
            Console.WriteLine($"gRPC error: {ex.StatusCode} - {ex.Status.Detail}");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Connection timed out or was cancelled.");
        }
        finally
        {
            lifetime.Cancel();
            await heartbeatTask;
        }
    }

    private static async Task ReadHeartbeatsAsync<T>(
        IAsyncStreamReader<T> stream,
        CancellationToken cancellationToken)
    {
        try
        {
            while (await stream.MoveNext(cancellationToken))
            {
                // Keep the registration stream active.
            }

            Console.WriteLine("Server closed the heartbeat stream.");
        }
        catch (OperationCanceledException)
            when (cancellationToken.IsCancellationRequested)
        {
            // Normal shutdown.
        }
        catch (RpcException)
            when (cancellationToken.IsCancellationRequested)
        {
            // Normal shutdown.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Heartbeat disconnected: {ex.Message}");
        }
    }
}
