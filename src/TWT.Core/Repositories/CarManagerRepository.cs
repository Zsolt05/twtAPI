using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using TWT.Core.Constans;
using TWT.Core.Models;
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

        public async Task<Car?> GetCar(string lincensePlate)
        {
            return await context.Cars.FirstOrDefaultAsync(x => x.LincensePlate.Equals(lincensePlate));
        }

        public async Task<ResponseM> GetCarByLicensePlate(string lincensePlate)
        {
            var checkLP = CorrectLicensePlateFormat(lincensePlate);
            if (checkLP != null)
            {
                return checkLP;
            }
            Car? car = await GetCar(lincensePlate);
            if (car == null)
            {
                return new ResponseM
                {
                    Success = false,
                    HttpCode = 404,
                    Message = "Car Not Found",
                    Data = null
                };
            }
            return new ResponseM
            {
                Success = true,
                HttpCode = 200,
                Message = "Car Found",
                Data = car
            };
        }

        public async Task<ResponseM> GetCarsByHorsePower(int hoursePower)
        {
            
            var check = CorrectHorsePower(hoursePower);
            if (check != null)
            {
                return check;
            }
            var cars = await context.Cars.Where(x => x.Power.Equals(hoursePower)).ToListAsync();
            if (cars.Count == 0)
            {
                return new ResponseM
                {
                    Success = false,
                    HttpCode = 404,
                    Message = "Car Not Found",
                    Data = null
                };
            }
            else
            {
                return new ResponseM
                {
                    Success = true,
                    HttpCode = 200,
                    Message = $"{cars.Count} Car Found",
                    Data = cars
                };
            }
        }

        public async Task<ResponseM> GetCarsByOwners(string ownerName)
        {
            var checkLP = CorrectNameFormat(ownerName);
            if (checkLP != null)
            {
                return checkLP;
            }
            var cars = await context.Cars.Where(x => x.OwnerName.Equals(ownerName)).ToListAsync();
            if (cars.Count == 0)
            {
                return new ResponseM
                {
                    Success = false,
                    HttpCode = 404,
                    Message = "Car Not Found",
                    Data = null
                };
            }
            else
            {
                return new ResponseM
                {
                    Success = true,
                    HttpCode = 200,
                    Message = $"{cars.Count} Car Found",
                    Data = cars
                };
            }
        }

        public Task<ResponseM> AddCar(Car a)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseM> DeleteCar(string lincensePlate)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseM> UpdateCarHorsePower(string lincensePlate, int newHorsePower)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseM> UpdateCarOwner(string lincensePlate, string newOwner)
        {
            throw new NotImplementedException();
        }

        private static ResponseM? CorrectLicensePlateFormat(string lincensePlate)
        {
            if (!Regex.Match(lincensePlate, Regexes.LincensePlateRegex).Success)
            {
                return new ResponseM
                {
                    Success = false,
                    HttpCode = 404,
                    Message = "Lincense Plate has wrong format",
                    Data = null
                };
            }
            else
            {
                return null;
            }
        }
        private static ResponseM? CorrectNameFormat(string name)
        {
            if (!Regex.Match(name, Regexes.OwnerNameRegex).Success)
            {
                return new ResponseM
                {
                    Success = false,
                    HttpCode = 400,
                    Message = "Incorrect name format. Correct: \"Bali Zsolt\"",
                    Data = null
                };
            }
            else
            {
                return null;
            }
        }
        private static ResponseM? CorrectHorsePower(int power)
        {
            if (power < 1)
            {
                return new ResponseM
                {
                    Success = false,
                    HttpCode = 400,
                    Message = "Horsepower cannot be less than one",
                    Data = null
                };
            }
            else
            {
                return null;
            }
        }
    }
}
