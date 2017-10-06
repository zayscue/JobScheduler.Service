using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobScheduler.Api.Models;
using JobScheduler.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobScheduler.Api.Controllers
{
    [Route("api/requests")]
    public class RequestsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<JobRequest> _requests;

        public RequestsController(IMapper mapper, IRepositoryBase<JobRequest> requests)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _requests = requests ?? throw new ArgumentNullException(nameof(requests));
        }

        // GET api/requests
        [HttpGet]
        public async Task<IEnumerable<JobRequestDto>> Get() 
            => (await _requests.GetAll())?.Select(x =>_mapper.Map<JobRequestDto>(x));

        // GET api/requests/{id}
        [HttpGet("{id}")]
        public async Task<JobRequestDto> Get(string id) 
            => _mapper.Map<JobRequestDto>(await _requests.GetById(id));

        // POST api/requests
        [HttpPost]
        public async Task<JobRequestDto> Post([FromBody] JobRequestDto request) 
            => _mapper.Map<JobRequestDto>(await _requests.Insert(_mapper.Map<JobRequest>(request)));

        // PUT api/requests/{id}
        [HttpPut("{id}")]
        public async Task Put(string id,[FromBody] JobRequestDto request)
            => await _requests.Update(id, _mapper.Map<JobRequest>(request));

        // DELETE api/requests/{id}
        [HttpDelete("{id}")]
        public async Task<JobRequestDto> Delete(string id)
            => _mapper.Map<JobRequestDto>(await _requests.Remove(id));
    }
}