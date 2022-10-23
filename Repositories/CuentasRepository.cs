using appbuscar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appbuscar.Repositories
{
    public class CuentasRepository : Controller
    {
        private readonly appbuscarContext _context;

        public CuentasRepository(appbuscarContext context)
        {
            _context = context;
        }

        public async Task<Users> Login(string email,string password)
        {
            return await _context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
        }

        public async Task<bool> Register(Users user)
        {
            await _context.Users.AddAsync(user);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }
    }
}
