using HotelForDogs.DbContexts;
using HotelForDogs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Services
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientContext _context;

        public ClientRepository(ClientContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Client GetClient(int clientId)
        {

            return _context.Clients.FirstOrDefault(a => a.ClientId == clientId);
        }
        public void AddClient(int dogId, Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }


            _context.Clients.Add(client);
        }
        public void UpdateClient(Client client)
        {

        }
        public void DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
        }
        public IEnumerable<Client> GetClients()
        {
            return _context.Clients.ToList<Client>();
        }
        public void AddDog(Dog dog)
        {
            if (dog == null)
            {
                throw new ArgumentNullException(nameof(dog));
            }

            _context.Dogs.Add(dog);
        }
        public void DeleteDog(Dog dog)
        {
            _context.Dogs.Remove(dog);
        }
        public void UpdateDog(Dog dog)
        {

        }
        public bool ClientExists(int clientId)
        {
            return _context.Clients.Any(a => a.ClientId == clientId);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
