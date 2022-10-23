using System;
using appbuscar.Interfaces;
using appbuscar.Models;
using Microsoft.EntityFrameworkCore;

namespace appbuscar.Repositories
{
    public class BusesRepository: IBusesRepository
    {
        private readonly appbuscarContext _context;

        public BusesRepository(appbuscarContext context)
        {
            _context = context;
        }
        //READ ALL
        public async Task<IEnumerable<Buses>> GetBuses()
        {
            return await _context.Buses.ToListAsync();
        }

        //READ ONE
        public async Task<Buses> GetBus(int id)
        {
            return await _context.Buses.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Buses bus)
        {
            await _context.Buses.AddAsync(bus);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Update(Buses bus)
        {
            _context.Buses.Update(bus);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var bus = await _context.Buses.FindAsync(id);
            if (bus == null) return false;
            else
            {
                _context.Buses.Remove(bus);
                var countRowsAffected = await _context.SaveChangesAsync();
                return countRowsAffected > 0;
            }
        }
    }
}