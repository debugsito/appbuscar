using appbuscar.Models;
using appbuscar.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace appbuscar.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private CuentasRepository _repository;

        public CuentasController(CuentasRepository repository)
        {
            _repository = repository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> Login(string email,string password)
        {
            var user = await _repository.Login(email, password);
            if(user!=null)
                return Ok(user);
            else return BadRequest();
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Users users)
        {
            var ok = await _repository.Register(users);
            if(ok)
                return Ok(ok);
            else return BadRequest();
        }
    }
}
