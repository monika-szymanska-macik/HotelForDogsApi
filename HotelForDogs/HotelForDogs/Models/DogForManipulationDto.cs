using HotelForDogs.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Models
{
    [DogNameMustBeDifferentFromBreed(ErrorMessage = "Name should be different from the breed")]
    public abstract class DogForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a name.")]
        [MaxLength(50, ErrorMessage = "The name shouldn't have more than 50 characters.")]
        public string Name { get; set; }

        public virtual string Breed { get; set; }

        [Required(ErrorMessage = "You should fill out a weight.")]
        public int Weight { get; set; }

    }
}
