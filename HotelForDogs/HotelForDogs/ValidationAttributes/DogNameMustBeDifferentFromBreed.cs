using HotelForDogs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.ValidationAttributes
{
    public class DogNameMustBeDifferentFromBreed : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dog = (DogForManipulationDto)validationContext.ObjectInstance;
            if(dog.Name == dog.Breed)
            {
                return new ValidationResult(
                    ErrorMessage,
                    new[] { nameof(DogForManipulationDto) });
            }
            return ValidationResult.Success;
        }
    }
}
