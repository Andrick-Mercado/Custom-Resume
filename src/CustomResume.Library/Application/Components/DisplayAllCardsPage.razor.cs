using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure;
using CustomResume.Library.Infrastructure.FileServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using MudBlazor;

namespace CustomResume.Library.Application.Components;

public partial class DisplayAllCardsPage
{
    [Parameter] public string ClientRouteName { get; set; } = default!;
    [Inject] private IWebsiteRepo WebsiteRepo { get; set; } = default!;
    [Inject] private AppInfoRouter AppInfoRouter { get; set; } = default!;
    [Inject] private IDirectoryService<byte[]> DirectoryService { get; set; } = default!;
    [Inject] private ILogger<DisplayAllCardsPage> Logger { get; set; } = default!;
    [Inject] private ISnackbar Snackbar { get; set; } = default!;
    private bool _hasLoaded = false;
    private WebsiteData _websiteDatabaseData;
    private OtherPages _currentPage;

    protected override async Task OnInitializedAsync()
    {
        if (_hasLoaded && ClientRouteName == _currentPage?.Endpoint) return;

        _websiteDatabaseData = await WebsiteRepo.GetWebsiteData();
        _currentPage = _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);

        _hasLoaded = _currentPage is not null;
        StateHasChanged();
    }

    protected override async Task OnParametersSetAsync()
    {
        if (_websiteDatabaseData is null)
        {
            _websiteDatabaseData = await WebsiteRepo.GetWebsiteData();
            _currentPage = _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        }
        else if (_currentPage is not null && ClientRouteName != _currentPage.Endpoint)
        {
            _currentPage = _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        }
        else
        {
            _currentPage ??= _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        }

        _hasLoaded = _currentPage is not null;
        StateHasChanged();
    }

    private IEnumerable<IGrouping<string, Card>> GetCardsGroupedByCardName()
    {
        return _currentPage?.Cards.GroupBy(x => x.Name) ?? Array.Empty<IGrouping<string, Card>>();
    }

    private Card GetFirstCard()
    {
        return _currentPage?.Cards.FirstOrDefault() ?? new Card();
    }

    private async Task UploadFileAsync(IBrowserFile file)
    {
        if (file is null) return;

        const long maxFileSize = 1024 * 1024 * 5; // 5MB limit
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var fileExtension = Path.GetExtension(file.Name).ToLowerInvariant();

        if (!allowedExtensions.Contains(fileExtension))
        {
            Snackbar.Add($"File type {fileExtension} is not allowed. Please upload {string.Join(", ", allowedExtensions)}", Severity.Error);
            return;
        }

        if (file.Size > maxFileSize)
        {
            Snackbar.Add($"File is too large. Max size allowed is {maxFileSize / 1024 / 1024}MB", Severity.Error);
            return;
        }

        try
        {
            var fileName = Path.GetFileName(file.Name);
            Logger?.LogInformation("Uploading file: {FileName}, Size: {FileSize}, ContentType: {FileContentType}", fileName, file.Size, file.ContentType);

            using var stream = file.OpenReadStream(maxFileSize);
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            var buffer = memoryStream.ToArray();

            var writeResult = await DirectoryService.WriteBytesAsync(fileName, buffer);
            if (writeResult.IsSuccessful)
            {
                Snackbar.Add($"File '{fileName}' uploaded successfully", Severity.Success);
                Logger?.LogInformation("Successfully uploaded and saved: {FileName}", fileName);
            }
            else
            {
                var errors = string.Join(", ", writeResult.Errors);
                Snackbar.Add($"Failed to save file: {errors}", Severity.Error);
                Logger?.LogError("Failed to save file {FileName}: {Errors}", fileName, errors);
            }
        }
        catch (Exception ex)
        {
            Logger?.LogError(ex, "Unexpected error during file upload: {FileName}", file.Name);
            Snackbar.Add("An error occurred while uploading the file. Please try again.", Severity.Error);
        }
    }
}