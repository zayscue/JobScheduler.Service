using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobScheduler.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobScheduler.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClassificationsController : Controller
    {
        private readonly DataAccess _dba;

        public ClassificationsController(DataAccess dba)
        {
            _dba = dba;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Classification>> Get() => await _dba.GetClassifications();
    }
}
