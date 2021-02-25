using AutoMapper;
using HotelForDogs.Entities;
using HotelForDogs.Models;
using HotelForDogs.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientsController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<ClientDto>> GetClients()
        {
            var clientsFromRepo = _clientRepository.GetClients();
            return Ok(_mapper.Map<IEnumerable<ClientDto>>(clientsFromRepo));
        }
        [HttpGet("{clientId}", Name ="GetClient")]
        public IActionResult GetClient(int clientId)
        {
            var clientFromRepo = _clientRepository.GetClient(clientId);

            if (clientFromRepo == null)
            {
                return NotFound();
            }
      
            return Ok(_mapper.Map<ClientDto>(clientFromRepo));
        }
        [HttpPost]
        public ActionResult<ClientDto> CreateAclient(ClientForCreationDto client)
        {
            var clientEntity = _mapper.Map<Client>(client);
            _clientRepository.AddClient(clientEntity);
            _clientRepository.Save();

            var clientToReturn = _mapper.Map<ClientDto>(clientEntity);
            return CreatedAtRoute("GetClient",
                new { clientId = clientToReturn.ClientId }, 
                clientToReturn);

        }
    }
}
