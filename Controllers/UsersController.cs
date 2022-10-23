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
    [Route("api/users")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private IUsersRepository _repository;

        public UsersController(IUsersRepository repository)
        {
            _repository = repository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repository.GetUsers();
            if (result!=null)
            {
                return Ok(result);
            }
            else return BadRequest();
        }

        // GET: api/users/5
        [HttpGet("{id}", Name = "Get-User")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _repository.GetUser(id);
            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest();
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Users users)
        {
            var result = await _repository.Insert(users);
            if (result)
            {
                return Ok(result);
            }
            else return BadRequest();
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Users users)
        {
            if (id != users.Id) return BadRequest();
            else return Ok(await _repository.Update(users));
        }

        // DELETE: api/users/5
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

