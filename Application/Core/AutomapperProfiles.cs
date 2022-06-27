using AutoMapper;
using Domain;

namespace Application.Core
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Workday, Workday>();
            CreateMap<Packet, Packet>();
        }
    }
}
