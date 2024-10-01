using Blazored.LocalStorage;
using CustomResume.Library.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CustomResume.Library;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomResumeMauiServices(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseService, MockedDatabaseService>();
        services.AddScoped<IWebsiteRepo, WebsiteRepo>();
        services.AddScoped<IProfileService, ProfileService>();

        services.AddSingleton(new AppInfoRouter(isThisMauiApp: true));

        services.AddSingleton(typeof(IDirectoryService<>), typeof(DirectoryService<>));
        services.AddBlazoredLocalStorage();
        return services;
    }

    public static async Task<IServiceCollection> AddCustomResumeBlazorServicesAsync(this IServiceCollection services, string baseAddress)
    {
        var websiteRepo = new WebsiteRepo(new DatabaseService(new HttpClient { BaseAddress = new Uri(baseAddress) }));
        await websiteRepo.EnsureInitializedAsync();
        services.AddSingleton<IWebsiteRepo>(websiteRepo);

        services.AddSingleton<IProfileService, ProfileService>();

        services.AddSingleton(new AppInfoRouter(isThisMauiApp: false));

        services.AddBlazoredLocalStorageAsSingleton();
        return services;
    }
}