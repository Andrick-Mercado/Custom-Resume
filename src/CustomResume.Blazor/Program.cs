using CustomResume.Blazor;
using CustomResume.Library;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

//var websiteRepo = new WebsiteRepo(new DatabaseService(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }));
//await websiteRepo.InitializeAsync();
//builder.Services.AddSingleton<IWebsiteRepo>(websiteRepo);
//builder.Services.AddSingleton<IProfileService, ProfileService>();
//builder.Services.AddBlazoredLocalStorageAsSingleton();

await builder.Services.AddCustomResumeBlazorServicesAsync(builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();