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
    [Route("api/buses")]
    [ApiController]
    public class BusesController: ControllerBase
    {
        private IBusesRepository _busesRepository;

        public BusesController(IBusesRepository repository)
        {
            _busesRepository = repository;
        }

        // GET: api/buses
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _busesRepository.GetBuses());
        }

        // GET: api/buses/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _busesRepository.GetBus(id));
        }

        // POST: api/buses
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Buses buses)
        {
            return Ok(await _busesRepository.Insert(buses));
        }

        // PUT: api/buses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Buses buses)
        {
            if (id != buses.Id) return BadRequest();
            else return Ok(await _busesRepository.Update(buses));
        }

        // DELETE: api/buses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _busesRepository.Delete(id));
        }
    }
}

