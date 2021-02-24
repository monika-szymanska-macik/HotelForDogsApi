using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Entities
{
    public class StayAtHotel
    {

        [Key]
        public int StayId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public int ClientId { get; set; }

    }
}
