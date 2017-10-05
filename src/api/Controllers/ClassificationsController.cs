using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using JobScheduler.Api.Models;
using JobScheduler.Api.Infrastructure;

namespace JobScheduler.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClassificationsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DataAccess _dba;

        public ClassificationsController(IMapper mapper, DataAccess dba)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dba = dba ?? throw new ArgumentNullException(nameof(dba));
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<ClassificationDto>> Get() => (await _dba.GetClassifications())?.Select(x =>_mapper.Map<ClassificationDto>(x));
    }
}
