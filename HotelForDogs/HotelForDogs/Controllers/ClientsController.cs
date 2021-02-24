using HotelForDogs.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Controllers
{
    [ApiController]
    public class ClientsController : ControllerBase 
    {
        private readonly IClientRepository _clientRepository;
        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }
        [HttpGet("api/clients")]
        public IActionResult GetClients()
        {
            var clientsFromRepo = _clientRepository.GetClients();
            return new JsonResult(clientsFromRepo);
        }
    }
}
