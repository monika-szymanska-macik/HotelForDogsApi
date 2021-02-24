using HotelForDogs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Services
{
    public interface IClientRepository
    {
        Client GetClient(int clientId);
        void AddClient(int dogId, Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        IEnumerable<Client> GetClients();
        void AddDog(Dog dog);
        void DeleteDog(Dog dog);
        void UpdateDog(Dog dog);
        bool ClientExists(int clientId);
        bool Save();
    }
}
