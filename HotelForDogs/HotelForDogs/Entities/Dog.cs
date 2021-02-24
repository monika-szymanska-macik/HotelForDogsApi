using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Entities
{
    public class Dog
    {
        [Key]
        public int DogId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Breed { get; set; }

        [Required]
        public int Weight { get; set; }

    }
}
