using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Models
{
    public class ReservationForManipulationDto
    {
        [Required(ErrorMessage = "You should enter the number of days of stay")]
        public int DaysNumberOfStay { get; set; }
    }
}
