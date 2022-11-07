using EntitiesDTO;
using Entities;
using AutoMapper;

namespace Infrastructure.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<Client, ClientDTO>().ReverseMap();
        }
    }
}