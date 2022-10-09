using System;
using appbuscar.Interfaces;
using appbuscar.Models;
using Microsoft.EntityFrameworkCore;

namespace appbuscar.Repositories
{
    public class RoutesRepository: IRoutesRepository
    {
        private readonly appbuscarContext _context;

        public RoutesRepository(appbuscarContext context)
        {
            _context = context;
        }
        //READ ALL
        public async Task<IEnumerable<Routes>> GetRoutes()
        {
            return await _context.Routes.ToListAsync();
        }

        //READ ONE
        public async Task<Routes> GetRoute(int id)
        {
            return await _context.Routes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Routes route)
        {
            await _context.Routes.AddAsync(route);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Update(Routes route)
        {
            _context.Routes.Update(route);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null) return false;
            else
            {
                _context.Routes.Remove(route);
                var countRowsAffected = await _context.SaveChangesAsync();
                return countRowsAffected > 0;
            }
        }

    }
}

