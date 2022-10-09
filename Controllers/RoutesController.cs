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
    [Route("api/routes")]
    [ApiController]
    public class RoutesController: ControllerBase
    {
        private IRoutesRepository _repository;

        public RoutesController(IRoutesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/routes
        [HttpGet]
        public async Task<IActionResult> GetRoutes()
        {
            return Ok(await _repository.GetRoutes());
        }

        // GET: api/routes/5
        [HttpGet("{id}", Name = "Get-Route")]
        public async Task<IActionResult> GetRoute(int id)
        {
            return Ok(await _repository.GetRoute(id));
        }

        // POST: api/routes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Routes routes)
        {
            return Ok(await _repository.Insert(routes));
        }

        // PUT: api/routes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Routes routes)
        {
            if (id != routes.Id) return BadRequest();
            else return Ok(await _repository.Update(routes));
        }

        // DELETE: api/routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}

