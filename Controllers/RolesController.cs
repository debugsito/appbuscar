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
    [Route("api/roles")]
    [ApiController]
    public class RolesController: ControllerBase
    {
        private IRolesRepository _repository;

        public RolesController(IRolesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/roles
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _repository.GetRoles());
        }

        // GET: api/roles/5
        [HttpGet("{id}", Name = "Get-Role")]
        public async Task<IActionResult> GetRole(int id)
        {
            return Ok(await _repository.GetRole(id));
        }

        // POST: api/roles
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Roles roles)
        {
            return Ok(await _repository.Insert(roles));
        }

        // PUT: api/roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Roles roles)
        {
            if (id != roles.Id) return BadRequest();
            else return Ok(await _repository.Update(roles));
        }

        // DELETE: api/roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}

