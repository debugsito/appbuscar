using System;
using appbuscar.Interfaces;
using appbuscar.Models;
using Microsoft.EntityFrameworkCore;

namespace appbuscar.Repositories
{
    public class RolesRepository: IRolesRepository
    {
        private readonly appbuscarContext _context;

        public RolesRepository(appbuscarContext context)
        {
            _context = context;
        }
        //READ ALL
        public async Task<IEnumerable<Roles>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        //READ ONE
        public async Task<Roles> GetRole(int id)
        {
            return await _context.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Roles role)
        {
            await _context.Roles.AddAsync(role);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Update(Roles roles)
        {
            _context.Roles.Update(roles);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;
            else
            {
                _context.Roles.Remove(role);
                var countRowsAffected = await _context.SaveChangesAsync();
                return countRowsAffected > 0;
            }
        }
    }
}

