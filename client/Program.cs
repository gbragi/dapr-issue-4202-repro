using api;
using client;
using Grpc.Core;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services
    .AddHostedService<Worker>()
    .AddGrpcClient<Greeter.GreeterClient>(o => o.Address = new Uri($"http://localhost:{Environment.GetEnvironmentVariable("DAPR_GRPC_PORT")}"))
    // .ConfigureChannel(o =>
    // {
    //     var credentials = CallCredentials.FromInterceptor((context, metadata) =>
    //    {
    //        metadata.Add("dapr-app-id", "api");
    //        return Task.CompletedTask;
    //    });

    //     o.Credentials = ChannelCredentials.Create(ChannelCredentials.Insecure, credentials);
    // })
    )
    .Build();

await host.RunAsync();
