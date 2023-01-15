using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TWT.Core.Filters;
using TWT.Core.Models;
using TWT.Core.Repositories.Interfaces;
using TWT.Data;
using TWT.Data.Models;

namespace TWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarManagerRepository carManager;

        public CarController(ICarManagerRepository carManager)
        {
            this.carManager = carManager;
        }

        // GET: api/Car/All
        [HttpGet("All")]
        public async Task<List<Car>> GetAllCar()
        {
            return await carManager.GetAllCar();
        }

        // GET: api/Car/ABC-123
        [HttpGet("LicensePlate/{licensePlate}")]
        public async Task<ResponseM> GetCarByLicensePlate(string licensePlate)
        {
            return await carManager.GetCarByLicensePlate(licensePlate);
        }

        // GET api/Car/Owner?Name=Bali Zsolt
        [HttpGet("Owner")]
        public async Task<ResponseM> GetCarsByOwners([FromQuery(Name = "Name")] string Name)
        {
            return await carManager.GetCarsByOwners(Name);
        }

        // GET api/Car/HorsePower/300
        [HttpGet("HorsePower/{horsePower}")]
        public async Task<ResponseM> GetCarsByHorsePower(int horsePower)
        {
            return await carManager.GetCarsByHorsePower(horsePower);
        }

        // POST api/Car
        [AuthorizeByKey]
        [HttpPost]
        public async Task<ResponseM> AddCar([FromBody] Car car)
        {
            return await carManager.AddCar(car);
        }

        // PUT api/Car/LicensePlate/ABC-123?Owner=Bali Zsolt&HorsePower=300
        [AuthorizeByKey]
        [HttpPut("LicensePlate/{lincensePlate}")]
        public async Task<ResponseM> UpdateCarOwner(string lincensePlate, [FromQuery(Name = "Owner")] string? owner, [FromQuery(Name = "HorsePower")] int? horsePower)
        {
            if (string.IsNullOrWhiteSpace(owner) && !horsePower.HasValue)
            {
                return new ResponseM
                {
                    Success = false,
                    Data = null,
                    HttpCode = 400,
                    Message = "Specify what you want to modify"
                };
            }

            if (owner != null)
            {
                var a = await carManager.UpdateCarOwner(lincensePlate, owner);
                if (!a.Success)
                {
                    return a;
                }
            }
            if (horsePower != null)
            {
                var a = await carManager.UpdateCarHorsePower(lincensePlate, (int)horsePower);
                if (!a.Success)
                {
                    return a;
                }
            }
            return new ResponseM
            {
                Success = true,
                HttpCode = 200,
                Message = "Car Updated",
                Data = null
            };
        }

        // DELETE api/Car/ABC-123
        [HttpDelete("{licensePlate}")]
        public async Task<ResponseM> DeleteCar(string licensePlate)
        {
            return await carManager.DeleteCar(licensePlate);
        }
    }
}
