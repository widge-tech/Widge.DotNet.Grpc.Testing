using Grpc.Core;

using Microsoft.Playwright;

using Widge.DotNet.Grpc.Testing;

namespace Widge.DotNet.Grpc.Testing.Services;

public class GreeterService : Protos.Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    private readonly IPlaywright playwright;
    private readonly IBrowser browser;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
        playwright = Playwright.CreateAsync().Result;
        browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true,
        }).Result;
    }

    public override Task<Protos.HelloReply> SayHello(Protos.HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new Protos.HelloReply
        {
            Message = String.Format("Hello {0}! [from dotnet]", request.Name)
        });
    }

    public async override Task<Protos.PDFResponse> GeneratePDF(Protos.PDFRequest request, ServerCallContext context)
    {
        var page = await browser.NewPageAsync();
        await page.GotoAsync(request.Url);
        await page.EmulateMediaAsync(new PageEmulateMediaOptions { Media = Media.Screen });
        var pdf = await page.PdfAsync(new PagePdfOptions
        {
            Format = "A4",
            Margin = new Margin
            {
                Top = "80",
                Bottom = "80"
            },
            Path = "page.pdf"
        });
        return new Protos.PDFResponse
        {
            Pdf = Google.Protobuf.ByteString.CopyFrom(pdf)
        };
    }
}
