using TWT.Core.Models;
using TWT.Data.Models;

namespace TWT.Core.Repositories.Interfaces
{
    public interface ICarManagerRepository
    {
        Task<ResponseM> AddCar(Car a);
        Task<ResponseM> UpdateCarOwner(string lincensePlate, string newOwner);
        Task<ResponseM> UpdateCarHorsePower(string lincensePlate, int newHorsePower);
        Task<ResponseM> DeleteCar(string lincensePlate);
        Task<ResponseM> GetCarByLicensePlate(string lincensePlate);
        Task<ResponseM> GetCarsByOwners(string ownerName);
        Task<ResponseM> GetCarsByHorsePower(int hoursePower);
        Task<Car?> GetCar(string lincensePlate);
        Task<List<Car>> GetAllCar();
    }
}