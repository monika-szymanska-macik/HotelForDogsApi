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
    [Route("api/clients/{clientId}/dogs}")]
    public class DogsController : ControllerBase 
    {
        private readonly IDogRepository _dogRepository;
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        public DogsController(IDogRepository dogRepository, IMapper mapper, IClientRepository clientRepository)
        {
            _dogRepository = dogRepository ?? throw new ArgumentNullException(nameof(dogRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }
        [HttpGet]
        public ActionResult<IEnumerable<DogDto>> GetDogsForClient(int clientId)
        {
            if(!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }
            var dogsForClientFromRepo = _dogRepository.GetClientDogs(clientId);
            return Ok(_mapper.Map<IEnumerable<DogDto>>(dogsForClientFromRepo));
        }
    }
}
