using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace HotelForDogs.Profiles
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            CreateMap<Models.ReservationForCreationDto, Entities.Reservation>();
            CreateMap<Entities.Reservation, Models.ReservationsDto>();
            CreateMap<Models.ReservationForCreationDto, Entities.Reservation>();
            CreateMap<Models.ReservationToUpdateDto, Entities.Reservation>();
            CreateMap<Entities.Reservation, Models.ReservationToUpdateDto>();

        }

    }
}
