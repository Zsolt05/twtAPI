using Microsoft.AspNetCore.Mvc;
using TWT.Core.Repositories.Interfaces;
using TWT.Data;
using TWT.Data.Models;

namespace TWT.Core.Repositories
{
    public class CarManagerRepository : ICarManagerRepository
    {
        private readonly CarStoreDbContext context;

        public CarManagerRepository(CarStoreDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<IActionResult> AddCar(Car a)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteCar(string lincensePlate)
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetCarByLicensePlate(string lincensePlate)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetCarsByHorsePower(string lincensePlate)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetCarsByOwners(string lincensePlate)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateCarHorsePower(string lincensePlate, int newHorsePower)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateCarOwner(string lincensePlate, string newOwner)
        {
            throw new NotImplementedException();
        }
    }
}
