using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appbuscar.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using appbuscar.Interfaces;
using appbuscar.Models;

namespace appbuscar.Controllers
{
    [Route("api/schedule-routes")]
    [ApiController]
    public class ScheduleRoutesController: ControllerBase
    {
        private IScheduleRoutesRepository _repository;

        public ScheduleRoutesController(IScheduleRoutesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/schedule-routes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetScheduleRoutes());
        }

        // GET: api/schedule-routes/5
        [HttpGet("{id}", Name = "Get-Schedule-Route")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.GetScheduleRoute(id));
        }

        // POST: api/schedule-routes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScheduleRoutes routes)
        {
            return Ok(await _repository.Insert(routes));
        }

        // PUT: api/schedule-routes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ScheduleRoutes routes)
        {
            if (id != routes.Id) return BadRequest();
            else return Ok(await _repository.Update(routes));
        }

        // DELETE: api/schedule-routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}

