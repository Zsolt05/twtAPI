using Microsoft.AspNetCore.Mvc;
using TWT.Data.Models;

namespace TWT.Core.Repositories.Interfaces
{
    public interface ICarManagerRepository
    {
        Task<IActionResult> AddCar(Car a);
        Task<IActionResult> UpdateCarOwner(string lincensePlate, string newOwner);
        Task<IActionResult> UpdateCarHorsePower(string lincensePlate, int newHorsePower);
        Task<IActionResult> DeleteCar(string lincensePlate);
        Task<Car> GetCarByLicensePlate(string lincensePlate);
        Task<IActionResult> GetCarsByOwners(string lincensePlate);
        Task<IActionResult> GetCarsByHorsePower(string lincensePlate);
    }
}
