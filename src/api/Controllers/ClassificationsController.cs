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

        // GET api/classifications
        [HttpGet]
        public async Task<IEnumerable<ClassificationDto>> Get() 
            => (await _dba.GetClassifications())?.Select(x =>_mapper.Map<ClassificationDto>(x));

        // GET api/classifications/{id}
        [HttpGet("{id}")]
        public async Task<ClassificationDto> Get(string id) 
            => _mapper.Map<ClassificationDto>(await _dba.GetClassification(id));

        // POST api/classifications
        [HttpPost]
        public async Task<ClassificationDto> Post([FromBody] ClassificationDto classification) 
            => _mapper.Map<ClassificationDto>(await _dba.InsertClassification(_mapper.Map<Classification>(classification)));

        // PUT api/classifications/{id}
        [HttpPut("{id}")]
        public async Task Put(string id,[FromBody] ClassificationDto classification)
            => await _dba.UpdateClassification(id, _mapper.Map<Classification>(classification));

        // DELETE api/classifications/{id}
        [HttpDelete("{id}")]
        public async Task<ClassificationDto> Delete(string id)
            => _mapper.Map<ClassificationDto>(await _dba.DeleteClassification(id));
    }
}
