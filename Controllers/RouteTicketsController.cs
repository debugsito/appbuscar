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
    [Route("api/route-tickets")]
    [ApiController]
    public class RouteTicketsController: ControllerBase
    {
        private IRouteTicketsRepository _repository;

        public RouteTicketsController(IRouteTicketsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/route-tickets
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repository.GetRouteTickets();
            if (result!=null)
            {
                return Ok(result);
            }
            else return BadRequest();
        }

        // GET: api/route-tickets/5
        [HttpGet("{id}", Name = "Get-Route-Ticket")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _repository.GetRouteTicket(id);
            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest();
        }

        // POST: api/route-tickets
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RouteTickets routes)
        {
            var result = await _repository.Insert(routes);
            if (result)
            {
                return Ok(result);
            }
            else return BadRequest();
        }

        // PUT: api/route-tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RouteTickets routes)
        {
            if (id != routes.Id) return BadRequest();
            else return Ok(await _repository.Update(routes));
        }

        // DELETE: api/route-tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            else return BadRequest();
        }
    }
}

