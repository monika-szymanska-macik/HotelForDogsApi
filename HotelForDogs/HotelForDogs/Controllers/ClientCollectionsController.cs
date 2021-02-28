using AutoMapper;
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
    [Route("api/clientcollections")]
    public class ClientCollectionsController : ControllerBase
    {
        private readonly IDogRepository _dogRepository;
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        public ClientCollectionsController(IDogRepository dogRepository, IMapper mapper, IClientRepository clientRepository)
        {
            _dogRepository = dogRepository ?? throw new ArgumentNullException(nameof(dogRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }
        
        [HttpPost]
        public ActionResult<IEnumerable<ReservationDto>> CreateClientCollection(
            IEnumerable<ClientForCreationDto> clientCollection)
        {
            var clientEntities = _mapper.Map<IEnumerable<Entities.Client>>(clientCollection);
            foreach(var client in clientEntities)
            {
                _clientRepository.AddClient(client);
            }
            _clientRepository.Save();

            return Ok();
        }
    }
}
