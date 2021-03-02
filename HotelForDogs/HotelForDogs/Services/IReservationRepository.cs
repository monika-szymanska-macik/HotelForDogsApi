using HotelForDogs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Services
{
    public interface IReservationRepository
    {
        Reservation GetReservation(int dogId, int clientId);
        void AddReservation(Reservation reservation, int clientId);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
        IEnumerable<Reservation> GetReservations();
        IEnumerable<Reservation> GetClientReservations(int clientId);
        bool Save();
    }
}
