using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectTaxiAPI.Models;
using ConnectTaxiAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConnectTaxiAPI.Controllers
{
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {
        VehiclesRepo repo;

        public VehiclesController(IConfiguration configuration)
        {
            repo = new VehiclesRepo(configuration);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Vehicles> ListVehicles()
        {
            return repo.ListVehicles();
        }

        [HttpGet("ByModel/{id}")]
        public List<Vehicles> ListVehiclesByModel(int id)
        {
            return repo.ListVehiclesByModel(id);
        }

        [HttpGet("ByType/{id}")]
        public List<Vehicles> ListVehiclesByType(int id)
        {
            return repo.ListVehiclesByType(id);
        }

        [HttpGet("ByManufacturer/{id}")]
        public List<Vehicles> ListByManufacturers(int id)
        {
            return repo.ListByManufacturers(id);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Vehicles GetVehicle(int id)
        {
            return repo.GetVehicle(id);
        }

        // POST api/values
        [HttpPost]
        public AddRecordResponse AddVehicle([FromBody]Vehicles value)
        {
            return repo.AddVehicle(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response UpdateVehicle([FromBody]Vehicles value)
        {
            return repo.UpdateVehicle(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Response DeleteVehicle(int id)
        {
            return repo.DeleteVehicle(id);
        }

        [HttpGet("models")]
        public List<VehicleModels> ListVehicleModels()
        {
            return repo.ListVehicleModels();
        }

        [HttpGet("models/{id}")]
        public VehicleModels GetVehicleModel(int id)
        {
            return repo.GetVehicleModel(id);
        }

        [HttpPost("models")]
        public AddRecordResponse AddVehicleModel([FromBody] VehicleModels vehicleModel)
        {
            return repo.AddVehicleModel(vehicleModel.VehicleModel);
        }

        [HttpPut("models")]
        public Response UpdateVehicleModel([FromBody] VehicleModels vehicleModel)
        {
            return repo.UpdateVehicleModel(vehicleModel);
        }

        [HttpDelete("models/{id}")]
        public Response DeleteVehicleModel(int id)
        {
            return repo.DeleteVehicleModel(id);
        }

        [HttpGet("types")]
        public List<VehicleTypes> ListVehicleTypes()
        {
            return repo.ListVehicleTypes();
        }

        [HttpGet("types/{id}")]
        public VehicleTypes GetVehicleTypes(int id)
        {
            return repo.GetVehicleType(id);
        }

        [HttpPost("types")]
        public AddRecordResponse AddVehicleTypes([FromBody] VehicleTypes vehicleTypes)
        {
            return repo.AddVehicleType(vehicleTypes.VehicleType);
        }

        [HttpPut("types")]
        public Response UpdateVehicleTypes([FromBody] VehicleTypes vehicleTypes)
        {
            return repo.UpdateVehicleType(vehicleTypes);
        }

        [HttpDelete("types/{id}")]
        public Response DeleteVehicleTypes(int id)
        {
            return repo.DeleteVehicleType(id);
        }

        [HttpGet("manufacturers")]
        public List<VehicleManufacturers> ListVehicleManufacturers()
        {
            return repo.ListVehicleManufacturers();
        }

        [HttpGet("manufacturers/{id}")]
        public VehicleManufacturers GetVehicleManufacturer(int id)
        {
            return repo.GetVehicleManufacturers(id);
        }

        [HttpPost("manufacturers")]
        public AddRecordResponse AddVehicleManufacturers([FromBody] VehicleManufacturers manufacturer)
        {
            return repo.AddVehicleManufacturers(manufacturer);
        }

        [HttpPut("manufacturers")]
        public Response UpdateVehicleManufacturers([FromBody] VehicleManufacturers manufacturer)
        {
            return repo.UpdateVehicleManufacturers(manufacturer);
        }

        [HttpDelete("manufacturers/{id}")]
        public Response DeleteVehicleManufacturers(int id)
        {
            return repo.DeleteVehicleManufacturers(id);
        }
    }
}
