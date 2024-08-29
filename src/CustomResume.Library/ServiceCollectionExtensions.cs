using Blazored.LocalStorage;
using CustomResume.Library.Infrastructure;
using CustomResume.Library.Infrastructure.FileServices;
using CustomResume.Library.Infrastructure.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace CustomResume.Library;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomResumeMauiServices(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseService, DesktopDatabaseService>();
        services.AddScoped<IWebsiteRepo, WebsiteRepo>();
        services.AddScoped<IProfileService, ProfileService>();

        services.AddSingleton(new AppInfoRouter(AppInfoRouterType.Maui));

        services.AddSingleton(typeof(IDirectoryService<>), typeof(DirectoryService<>));
        services.AddBlazoredLocalStorage();
        return services;
    }

    public static async Task<IServiceCollection> AddCustomResumeBlazorServicesAsync(this IServiceCollection services,
        string baseAddress)
    {
        var websiteRepo =
            new WebsiteRepo(new WebDatabaseService(new HttpClient { BaseAddress = new Uri(baseAddress) }));
        await websiteRepo.EnsureInitializedAsync();
        services.AddSingleton<IWebsiteRepo>(websiteRepo);

        services.AddSingleton<IProfileService, ProfileService>();

        services.AddSingleton(new AppInfoRouter(AppInfoRouterType.Blazor));

        services.AddBlazoredLocalStorageAsSingleton();
        return services;
    }
}