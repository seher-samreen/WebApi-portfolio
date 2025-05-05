using AutoMapper;
using PortfolioManagementApi.DTOs;
using PortfolioManagementApi.Models;

namespace PortfolioManagementApi.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap(); // ✅ Enables mapping both ways
        }
    }
}
