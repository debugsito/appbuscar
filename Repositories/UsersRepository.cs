using System;
using appbuscar.Interfaces;
using appbuscar.Models;
using Microsoft.EntityFrameworkCore;

namespace appbuscar.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private readonly appbuscarContext _context;

        public UsersRepository(appbuscarContext context)
        {
            _context = context;
        }
        //READ ALL
        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //READ ONE
        public async Task<Users> GetUser(int id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Users user)
        {
            await _context.Users.AddAsync(user);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Update(Users user)
        {
            _context.Users.Update(user);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;
            else
            {
                _context.Users.Remove(user);
                var countRowsAffected = await _context.SaveChangesAsync();
                return countRowsAffected > 0;
            }
        }
    }
}

