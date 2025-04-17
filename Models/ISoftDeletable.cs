namespace PortfolioManagementApi.Models
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}
