using Grpc.Core;
using Widge.DotNet.Grpc.Testing;

namespace Widge.DotNet.Grpc.Testing.Services;

public class GreeterService : Protos.Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<Protos.HelloReply> SayHello(Protos.HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new Protos.HelloReply
        {
            Message = String.Format("Hello {0}! [from dotnet]", request.Name)
        });
    }
}
