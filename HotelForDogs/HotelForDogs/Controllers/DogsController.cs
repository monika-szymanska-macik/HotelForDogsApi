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
    [Route("api/clients/{clientId}/dogs")]
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
        [HttpGet("{dogId}", Name = "GetDogForClient")]
        public ActionResult<DogDto> GetDogForClient(int dogId, int clientId)
        {
            var dogForClientFromRepo = _dogRepository.GetDog(dogId, clientId);
            return Ok(_mapper.Map<DogDto>(dogForClientFromRepo));
        }

        [HttpPost]
        public ActionResult<DogDto> CreateDogForClient(int clientId, DogForCreationDto dog)
        {
            if(!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            var dogEntity = _mapper.Map<Entities.Dog>(dog);
            _dogRepository.AddDog(clientId, dogEntity);
            _dogRepository.Save();

            var dogToReturn = _mapper.Map<DogDto>(dogEntity);
            return CreatedAtRoute("GetDogForClient",
                new { clientId = clientId, dogId = dogToReturn.DogId }, dogToReturn);

        }
        [HttpPut("{dogId}")]
        public ActionResult UpdateDogForClient(int clientId, int dogId, DogToUpdateDto dog)
        {
            if(!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }
            var dogForClientFromRepo = _dogRepository.GetDog(dogId, clientId);
            if(dogForClientFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(dog, dogForClientFromRepo);
            _dogRepository.UpdateDog(dogForClientFromRepo);
            _dogRepository.Save();
            return NoContent();
        }

    }
}
