using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Entities
{
    public class Reservation
    {

        [Key]
        public int ReservationId { get; set; }
        [Required]
        public DateTimeOffset FirstDay { get; set; }
        public DateTimeOffset LastDay { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public int ClientId { get; set; }

    }
}
