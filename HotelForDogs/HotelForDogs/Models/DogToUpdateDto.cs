using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Models
{
    public class DogToUpdateDto : DogForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a breed")]
        public override string Breed { get => base.Breed; set => base.Breed = value; }
    }
}
