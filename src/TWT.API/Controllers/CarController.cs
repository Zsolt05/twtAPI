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

        // GET: api/Car/LicensePlate?Name=ABC-123
        [HttpGet("LicensePlate")]
        public async Task<ResponseM> GetCarByLicensePlate([FromQuery(Name = "Text")] string Text)
        {
            return await carManager.GetCarByLicensePlate(Text);
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

        // PUT api/Car/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Car/ABC-123
        [HttpDelete("{licensePlate}")]
        public async Task<ResponseM> DeleteCar(string licensePlate)
        {
            return await carManager.DeleteCar(licensePlate);
        }
    }
}
