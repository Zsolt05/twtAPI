using Microsoft.AspNetCore.Mvc;
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

        // GET: api/Car
        [HttpGet]
        public async Task<ResponseM> GetCarByLicensePlate([FromQuery(Name = "LicensePlate")] string licensePlate)
        {
            return await carManager.GetCarByLicensePlate(licensePlate);
        }

        // GET api/Car/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return null;
        }

        // POST api/Car
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Car/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Car/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
