using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class DownloadableProduct : ValueObject
{
    public bool IsDownload { get; set; }
    public int DownloadId { get; set; }
    public bool UnlimitedDownloads { get; set; }
    public int MaxNumberOfDownloads { get; set; }
    public int? DownloadExpirationDays { get; set; }
    public int DownloadActivationTypeId { get; set; }
    public bool HasSampleDownload { get; set; }
    public int SampleDownloadId { get; set; }
    public bool HasUserAgreement { get; set; }
    public string UserAgreementText { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsDownload;
        yield return DownloadId;
        yield return UnlimitedDownloads;
        yield return MaxNumberOfDownloads;
        yield return DownloadExpirationDays;
        yield return MaxNumberOfDownloads;
        yield return DownloadActivationTypeId;
        yield return UserAgreementText;
    }
}

