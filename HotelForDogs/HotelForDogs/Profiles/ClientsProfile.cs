using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Profiles
{
    public class ClientsProfile : Profile
    {
        public ClientsProfile()
        {
            CreateMap<Entities.Client, Models.ReservationDto>()
                .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}" )
                );

            CreateMap<Models.ClientForCreationDto, Entities.Client>();
        }
    }
}
