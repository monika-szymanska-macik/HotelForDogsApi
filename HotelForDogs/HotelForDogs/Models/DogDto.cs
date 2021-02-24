using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Models
{
    public class DogDto
    {
        public int DogId { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public int Weight { get; set; }

        public int ClientId { get; set; }
    }
}
