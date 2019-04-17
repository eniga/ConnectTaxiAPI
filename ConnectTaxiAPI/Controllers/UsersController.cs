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
    public class UsersController : Controller
    {
        UsersRepo repo;

        public UsersController(IConfiguration configuration)
        {
            repo = new UsersRepo(configuration);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return repo.ListUsers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return repo.GetUser(id);
        }

        [HttpGet("username/{username}")]
        public Users GetUsers(string username)
        {
            return repo.GetUserByUsername(username);
        }

        // POST api/values
        [HttpPost]
        public AddRecordResponse Post([FromBody]Users value)
        {
            return repo.AddUser(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Users value)
        {
            return repo.UpdateUser(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            return repo.DeleteUser(id);
        }
    }
}
