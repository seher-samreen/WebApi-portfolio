namespace PortfolioManagementApi.DTOs
{
    public record ExperienceDto
    (
        int Id,
        string CompanyName,
        string Position,
        DateTime StartDate,
        DateTime? EndDate
    );
}
