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
        private readonly DogHotelContext _context;

        public ClientRepository(DogHotelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Client GetClient(int clientId)
        {

            return _context.Clients.FirstOrDefault(a => a.ClientId == clientId);
        }
        public void AddClient(Client client)
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
