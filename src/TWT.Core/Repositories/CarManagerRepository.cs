using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
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

        public async Task<List<Car>> GetAllCar()
        {//Next time Paging ;)
            return await context.Cars.ToListAsync();
        }

        public async Task<ResponseM> AddCar(Car a)
        {
            var checkHP = CorrectHorsePower(a.Power);
            if (checkHP != null)
            {
                return checkHP;
            }

            var checkO = CorrectNameFormat(a.OwnerName);
            if (checkO != null)
            {
                return checkO;
            }

            var checkLP = CorrectLicensePlateFormat(a.LincensePlate);
            if (checkLP != null)
            {
                return checkLP;
            }

            if (await GetCar(a.LincensePlate) != null)
            {
                return new ResponseM
                {
                    Success = false,
                    HttpCode = 400,
                    Message = "Car Exists",
                    Data = null
                };
            }
            await context.Cars.AddAsync(a);
            try
            {
                await context.SaveChangesAsync();
                return new ResponseM
                {
                    Success = true,
                    HttpCode = 200,
                    Message = "Car Added",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseM
                {
                    Success = false,
                    HttpCode = 500,
                    Message = "Something went wrong",
                    Data = null
                };
            }

        }

        public async Task<ResponseM> DeleteCar(string lincensePlate)
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
            else
            {
                try
                {
                    context.Remove(car);
                    await context.SaveChangesAsync();
                    return new ResponseM
                    {
                        Success = true,
                        HttpCode = 200,
                        Message = "Car Deleted",
                        Data = null
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseM
                    {
                        Success = false,
                        HttpCode = 500,
                        Message = "Something went wrong",
                        Data = null
                    };
                }
            }
        }

        public async Task<ResponseM> UpdateCarHorsePower(string lincensePlate, int newHorsePower)
        {
            var checkLP = CorrectLicensePlateFormat(lincensePlate);
            if (checkLP != null)
            {
                return checkLP;
            }

            var checkHP = CorrectHorsePower(newHorsePower);
            if (checkHP != null)
            {
                return checkHP;
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
            else
            {
                try
                {
                    car.Power = newHorsePower;
                    context.Update(car);
                    await context.SaveChangesAsync();
                    return new ResponseM
                    {
                        Success = true,
                        HttpCode = 200,
                        Message = "Car Horse Power Updated",
                        Data = null
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseM
                    {
                        Success = false,
                        HttpCode = 500,
                        Message = "Something went wrong",
                        Data = null
                    };
                }
            }
        }

        public async Task<ResponseM> UpdateCarOwner(string lincensePlate, string newOwner)
        {
            var checkLP = CorrectLicensePlateFormat(lincensePlate);
            if (checkLP != null)
            {
                return checkLP;
            }

            var checkO = CorrectNameFormat(newOwner);
            if (checkO != null)
            {
                return checkO;
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
            else
            {
                try
                {
                    car.OwnerName = newOwner;
                    context.Update(car);
                    await context.SaveChangesAsync();
                    return new ResponseM
                    {
                        Success = true,
                        HttpCode = 200,
                        Message = "Car Owner Updated",
                        Data = null
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseM
                    {
                        Success = false,
                        HttpCode = 500,
                        Message = "Something went wrong",
                        Data = null
                    };
                }
            }
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
                    Message = "Incorrect name format. Correct: 'Bali Zsolt'",
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
                    Message = "Horse Power cannot be less than one",
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
