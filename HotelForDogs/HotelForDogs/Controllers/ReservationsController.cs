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
    [Route("api/clients/{clientId}/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IDogRepository _dogRepository;
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IReservationRepository _reservationRepository;

        public ReservationsController(IDogRepository dogRepository, IMapper mapper, IClientRepository clientRepository, IReservationRepository reservationRepository)
        {
            _dogRepository = dogRepository ?? throw new ArgumentNullException(nameof(dogRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }
        [HttpGet]
        public ActionResult<IEnumerable<ReservationsDto>> GetReservationsForClient(int clientId)
        
        {
            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }
            var reservationsForClientFromRepo = _reservationRepository.GetClientReservations(clientId);
            return Ok(_mapper.Map<IEnumerable<ReservationsDto>>(reservationsForClientFromRepo));
        }
        [HttpGet("{reservationId}", Name = "GetReservationForClient")]
        public ActionResult<ReservationsDto> GetReservationForClient(int dogId, int clientId)
        {
            var reservationForClientFromRepo = _reservationRepository.GetReservation(dogId, clientId);
            return Ok(_mapper.Map<ReservationsDto>(reservationForClientFromRepo));
        }
        [HttpPost]
        public ActionResult<ReservationsDto> CreateReservationForClient(int clientId, ReservationForCreationDto reservation)
        {
            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            var reservationEntity = _mapper.Map<Entities.Reservation>(reservation);
            _reservationRepository.AddReservation(reservationEntity, clientId);
            _reservationRepository.Save();

            var reservationToReturn = _mapper.Map<ReservationsDto>(reservationEntity);
            return CreatedAtRoute("GetReservationForClient",
                new { clientId = clientId, reservationId = reservationToReturn.ReservationId }, reservationToReturn);

        }
        [HttpDelete("{reservationId}")]
        public ActionResult DeleteReservationForClient(int clientId, int dogId)
        {
            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }
            var reservationForClientFromRepo = _reservationRepository.GetReservation(dogId, clientId);
            if (reservationForClientFromRepo == null)
            {
                return NotFound();
            }
            _reservationRepository.DeleteReservation(reservationForClientFromRepo);
            _reservationRepository.Save();

            return NoContent();
        }


    }
}
