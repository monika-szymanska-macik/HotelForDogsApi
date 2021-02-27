using AutoMapper;
using HotelForDogs.Models;
using HotelForDogs.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
        public IActionResult UpdateDogForClient(int clientId, int dogId, DogToUpdateDto dog)
        {
            if(!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }
            var dogForClientFromRepo = _dogRepository.GetDog(dogId, clientId);
            if(dogForClientFromRepo == null)
            {
                var dogToAdd = _mapper.Map<Entities.Dog>(dog);
                dogToAdd.DogId = dogId;

                _dogRepository.AddDog(clientId, dogToAdd);
                _dogRepository.Save();

                var dogToReturn = _mapper.Map<DogDto>(dogToAdd);

                return CreatedAtRoute("GetDogForClient",
                    new { clientId, dogId = dogToReturn.DogId },
                    dogToReturn);
            }
            _mapper.Map(dog, dogForClientFromRepo);
            _dogRepository.UpdateDog(dogForClientFromRepo);
            _dogRepository.Save();
            return NoContent();
        }

        [HttpPatch("{dogId}")]
        public ActionResult PartiallyUpdateDogForClient(int clientId,
            int dogId,
            JsonPatchDocument<DogToUpdateDto> patchDocument)
        {
            if(_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }
            var dogForClientFromRepo = _dogRepository.GetDog(dogId, clientId);

            if(dogForClientFromRepo == null)
            {
                var dogDto = new DogToUpdateDto();
                patchDocument.ApplyTo(dogDto, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
                if(!TryValidateModel(dogDto))
                {
                    return ValidationProblem(ModelState);
                }
                var dogToAdd = _mapper.Map<Entities.Dog>(dogDto);
                dogToAdd.DogId = dogId;

                _dogRepository.AddDog(clientId, dogToAdd);
                _dogRepository.Save();

                var dogToReturn = _mapper.Map<DogDto>(dogToAdd);

                return CreatedAtRoute("GetDogForClient",
                    new { clientId, dogId = dogToReturn.DogId },
                    dogToReturn);
            }
            var dogToPatch = _mapper.Map<DogToUpdateDto>(dogForClientFromRepo);

            patchDocument.ApplyTo(dogToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            if(!TryValidateModel(dogToPatch))
            {
                return ValidationProblem(ModelState);
            }

            TryValidateModel(dogToPatch);

            _mapper.Map(dogToPatch, dogForClientFromRepo);
            _dogRepository.UpdateDog(dogForClientFromRepo);
            _dogRepository.Save();
            return NoContent();
        }

        [HttpDelete("{dogId}")]
        public ActionResult DeleteDogForClient(int clientId, int dogId)
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
            _dogRepository.DeleteDog(dogForClientFromRepo);
            _dogRepository.Save();

            return NoContent();
        }
        public override ActionResult ValidationProblem(
            [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}
