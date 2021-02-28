using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Models
{
    public class ClientDto
    {
        public int ClientId { get; set; } 
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
