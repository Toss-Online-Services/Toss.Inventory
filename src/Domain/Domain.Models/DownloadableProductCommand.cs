namespace Domain.Models;
public record DownloadableProductCommand
{
    public bool IsDownload { get; init; }
    public int DownloadId { get; init; }
    public bool UnlimitedDownloads { get; init; }
    public int MaxNumberOfDownloads { get; init; }
    public int? DownloadExpirationDays { get; init; }
    public int DownloadActivationTypeId { get; init; }
    public bool HasSampleDownload { get; init; }
    public int SampleDownloadId { get; init; }
    public bool HasUserAgreement { get; init; }
    public string UserAgreementText { get; init; }
}
