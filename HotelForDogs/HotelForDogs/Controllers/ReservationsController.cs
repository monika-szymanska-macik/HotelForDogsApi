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


    }
}
