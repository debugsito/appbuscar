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
            var buss = await _busesRepository.GetBuses();
            if(buss!=null)
            {
                return Ok(buss);
            }else return BadRequest();
        }

        // GET: api/buses/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var buss = await _busesRepository.GetBus(id);
            if (buss != null)
            {
                return Ok(buss);
            }
            else return BadRequest();
        }

        // POST: api/buses
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Buses buses)
        {
            var buss = await _busesRepository.Insert(buses);
            if (buss)
            {
                return Ok(buss);
            }
            else return BadRequest();
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
            var buss = await _busesRepository.Delete(id);
            if (buss)
            {
                return Ok(buss);
            }
            else return BadRequest();
        }
    }
}

