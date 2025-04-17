namespace PortfolioManagementApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; } // Foreign key for Identity user
        public bool IsDeleted { get; set; } = false; // Soft delete property
    }

}
