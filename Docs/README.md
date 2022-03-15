# Doc

## Play

```cs

    playwright = Playwright.CreateAsync().Result;
    browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    {
        Headless = true,
    }).Result;


    public async override Task<Protos.PDFResponse> GeneratePDF(Protos.PDFRequest request, ServerCallContext context)
    {
        var page = await browser.NewPageAsync();
        await page.GotoAsync(request.Url);
        await page.WaitForLoadStateAsync(LoadState.Load);
        await page.WaitForTimeoutAsync(2000);
        await page.EmulateMediaAsync(new PageEmulateMediaOptions { Media = Media.Screen });
        var pdf = await page.PdfAsync(new PagePdfOptions
        {
            Format = "A4",
            Margin = new Margin
            {
                Top = "80",
                Bottom = "80"
            },
        });
        return new Protos.PDFResponse
        {
            Pdf = Google.Protobuf.ByteString.CopyFrom(pdf)
        };
    }
```
