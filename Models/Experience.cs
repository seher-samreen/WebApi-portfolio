namespace PortfolioManagementApi.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Soft delete flag
        public bool IsDeleted { get; set; } = false;
    }


}
