namespace LicenseManager.Core.Types
{
    public interface IPagedQuery
    {
        int Page { get; set; }
        int Results { get; set; }
        string OrderBy { get; set; }
        string SortOrder { get; set; }
    }
}