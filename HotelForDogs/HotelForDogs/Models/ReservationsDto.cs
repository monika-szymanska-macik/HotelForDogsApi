using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Models
{
    public class ReservationsDto
    {
        public int ReservationId { get; set; }
        public TimeSpan DaysNumberOfStay { get; set; }
        public int ClientId { get; set; }
    }
}
