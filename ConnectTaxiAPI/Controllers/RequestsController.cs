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
    public class RequestsController : Controller
    {
        RequestsRepo repo;

        public RequestsController(IConfiguration configuration)
        {
            repo = new RequestsRepo(configuration);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Requests> Get()
        {
            return repo.ListRequests();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Requests Get(int id)
        {
            return repo.GetRequest(id);
        }

        // POST api/values
        [HttpPost]
        public AddRecordResponse Post([FromBody]Requests value)
        {
            return repo.AddRequest(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Requests value)
        {
            return repo.UpdateRequest(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            return repo.DeleteRequest(id);
        }
    }
}
