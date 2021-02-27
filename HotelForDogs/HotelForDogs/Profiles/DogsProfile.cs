using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Profiles
{
    public class DogsProfile : Profile
    {
        public DogsProfile()
        {
            CreateMap<Entities.Dog, Models.DogDto>();
            CreateMap<Models.DogForCreationDto, Entities.Dog>();
            CreateMap<Models.DogToUpdateDto, Entities.Dog>();
            CreateMap<Entities.Dog, Models.DogToUpdateDto>();
        }
    }
}
