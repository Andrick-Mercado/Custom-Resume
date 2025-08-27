using CustomResume.Blazor;
using CustomResume.Library;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Logging.SetMinimumLevel(LogLevel.Information);
#if DEBUG
builder.Logging.SetMinimumLevel(LogLevel.Debug);
#endif

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

await builder.Services.AddCustomResumeBlazorServicesAsync(builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();