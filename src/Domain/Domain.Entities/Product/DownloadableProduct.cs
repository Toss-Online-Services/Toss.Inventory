using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class DownloadableProduct : ValueObject
{
    public bool IsDownload { get; private set; }
    public int DownloadId { get; private set; }
    public bool UnlimitedDownloads { get; private set; }
    public int MaxNumberOfDownloads { get; private set; }
    public int? DownloadExpirationDays { get; private set; }
    public int DownloadActivationTypeId { get; private set; }
    public bool HasSampleDownload { get; private set; }
    public int SampleDownloadId { get; private set; }
    public bool HasUserAgreement { get; private set; }
    public string UserAgreementText { get; private set; }

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

