using HotelForDogs.DbContexts;
using HotelForDogs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Services
{
    public class DogRepository : IDogRepository
    {
        private readonly DogHotelContext _context;
        public DogRepository(DogHotelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddDog(int clientId, Dog dog)
        {
            
            if (dog == null)
            {
                throw new ArgumentNullException(nameof(dog));
            }

            dog.ClientId = clientId;
            _context.Dogs.Add(dog);
        }

        public void DeleteDog(Dog dog)
        {
            _context.Dogs.Remove(dog);
        }

        public Dog GetDog(int dogId, int clientId)
        {
            return _context.Dogs
                .Where(d => d.DogId == dogId && d.ClientId == clientId).FirstOrDefault();
        }

        public IEnumerable<Dog> GetClientDogs(int clientId)
        {
            return _context.Dogs
                        .Where(c => c.ClientId == clientId)
                        .OrderBy(c => c.Name).ToList();
        }


        public IEnumerable<Dog> GetDogs()
        {
            return _context.Dogs.ToList<Dog>();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateDog(Dog dog)
        {
            
        }
    }
}
