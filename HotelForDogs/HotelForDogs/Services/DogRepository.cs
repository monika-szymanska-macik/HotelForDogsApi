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

        public Dog GetDog(int dogId)
        {
            return _context.Dogs.FirstOrDefault(a => a.DogId == dogId);
        }

        public IEnumerable<Dog> GetDogs()
        {
            return _context.Dogs.ToList<Dog>();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateDog(Dog dog)
        {
            
        }
    }
}
