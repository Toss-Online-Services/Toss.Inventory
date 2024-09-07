namespace Application.Products.Models.Product;
public record DownloadableProductViewModel(bool IsDownload, int DownloadId, bool UnlimitedDownloads, int MaxNumberOfDownloads, int? DownloadExpirationDays, int DownloadActivationTypeId, bool HasSampleDownload, int SampleDownloadId, bool HasUserAgreement, string UserAgreementText);
