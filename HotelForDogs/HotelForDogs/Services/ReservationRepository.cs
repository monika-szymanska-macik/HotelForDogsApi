using HotelForDogs.DbContexts;
using HotelForDogs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Services
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DogHotelContext _context;
        public ReservationRepository(DogHotelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Reservation GetReservation(int dogId, int clientId)
        {
            return _context.Reservations
                .Where(r => r.ClientId == clientId).FirstOrDefault();
        }
        public IEnumerable<Reservation> GetClientReservations(int clientId)
        {
            return _context.Reservations
                        .Where(r => r.ClientId == clientId)
                        .ToList();
        }
        public void AddReservation(Reservation reservation, int clientId)
        {
            if(reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            reservation.ClientId = clientId;
            _context.Reservations.Add(reservation);
        }
        public void UpdateReservation(Reservation reservation)
        {

        }
        public void DeleteReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
        }
        public IEnumerable<Reservation> GetReservations()
        {
            return _context.Reservations.ToList<Reservation>();
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
