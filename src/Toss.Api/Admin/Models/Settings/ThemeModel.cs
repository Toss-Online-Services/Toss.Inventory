namespace Toss.Api.Admin.Models.Settings;

public partial record StoreInformationSettingsModel
{
   

    #region Nested classes

    public partial record ThemeModel
    {
        public string SystemName { get; set; }
        public string FriendlyName { get; set; }
        public string PreviewImageUrl { get; set; }
        public string PreviewText { get; set; }
        public bool SupportRtl { get; set; }
        public bool Selected { get; set; }
    }

    #endregion
}
