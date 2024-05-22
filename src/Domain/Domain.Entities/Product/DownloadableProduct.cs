﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class DownloadableProduct : Entity
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
}
