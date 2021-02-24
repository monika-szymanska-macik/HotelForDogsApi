using HotelForDogs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelForDogs.Services
{
    public interface IDogRepository
    {
        Dog GetDog(int dogId);
        void AddDog(Dog dog);
        void DeleteDog(Dog dog);
        void UpdateDog(Dog dog);
        IEnumerable<Dog> GetDogs();
        bool Save();
        IEnumerable<Dog> GetClientDogs(int clientId);
    }
}
