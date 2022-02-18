using Grpc.Core;

namespace api.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<GreetingReply> SayHello(GreetingRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GreetingReply
        {
            Message = "Hello " + request.Name
        });
    }
    public override Task<GreetingReply> SayGoodbye(GreetingRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GreetingReply
        {
            Message = "Goodbye " + request.Name
        });
    }
}