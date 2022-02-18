using api;
namespace client;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly api.Greeter.GreeterClient _greeterClient;

    public Worker(ILogger<Worker> logger, Greeter.GreeterClient greeterClient)
    {
        _logger = logger;
        _greeterClient = greeterClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);

            var metadata = new Grpc.Core.Metadata { { "dapr-app-id", "api" } };

            var helloResponse = await _greeterClient.SayHelloAsync(new GreetingRequest { Name = "Bug" }, metadata, cancellationToken: stoppingToken);

            _logger.LogInformation("Got hello response from greeter: {response}", helloResponse.Message);

            var goodbyeResponse = await _greeterClient.SayGoodbyeAsync(new GreetingRequest { Name = "Bug" }, metadata, cancellationToken: stoppingToken);

            _logger.LogInformation("Got goodbye response from greeter: {response}", goodbyeResponse.Message);
        }
    }
}
