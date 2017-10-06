using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using JobScheduler.Api.Models;
using JobScheduler.Api.Infrastructure;
using JobScheduler.Api.Repositories;

namespace JobScheduler.Api.Controllers
{
    [Route("api/classifications")]
    public class ClassificationsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Classification> _classifications;

        public ClassificationsController(IMapper mapper, IRepositoryBase<Classification> classifications)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _classifications = classifications ?? throw new ArgumentNullException(nameof(classifications));
        }

        // GET api/classifications
        [HttpGet]
        public async Task<IEnumerable<ClassificationDto>> Get() 
            => (await _classifications.GetAll())?.Select(x =>_mapper.Map<ClassificationDto>(x));

        // GET api/classifications/{id}
        [HttpGet("{id}")]
        public async Task<ClassificationDto> Get(string id) 
            => _mapper.Map<ClassificationDto>(await _classifications.GetById(id));

        // POST api/classifications
        [HttpPost]
        public async Task<ClassificationDto> Post([FromBody] ClassificationDto classification) 
            => _mapper.Map<ClassificationDto>(await _classifications.Insert(_mapper.Map<Classification>(classification)));

        // PUT api/classifications/{id}
        [HttpPut("{id}")]
        public async Task Put(string id,[FromBody] ClassificationDto classification)
            => await _classifications.Update(id, _mapper.Map<Classification>(classification));

        // DELETE api/classifications/{id}
        [HttpDelete("{id}")]
        public async Task<ClassificationDto> Delete(string id)
            => _mapper.Map<ClassificationDto>(await _classifications.Remove(id));
    }
}
