namespace Toss.Api.Admin.Helpers;

public partial interface ITinyMceHelper
{
    Task<string> GetTinyMceLanguageAsync();
}