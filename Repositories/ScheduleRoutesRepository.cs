using System;
using appbuscar.Interfaces;
using appbuscar.Models;
using Microsoft.EntityFrameworkCore;

namespace appbuscar.Repositories
{
    public class ScheduleRoutesRepository: IScheduleRoutesRepository
    {
        private readonly appbuscarContext _context;

        public ScheduleRoutesRepository(appbuscarContext context)
        {
            _context = context;
        }
        //READ ALL
        public async Task<IEnumerable<ScheduleRoutes>> GetScheduleRoutes()
        {
            return await _context.ScheduleRoutes.ToListAsync();
        }

        //READ ONE
        public async Task<ScheduleRoutes> GetScheduleRoute(int id)
        {
            return await _context.ScheduleRoutes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(ScheduleRoutes bus)
        {
            await _context.ScheduleRoutes.AddAsync(bus);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Update(ScheduleRoutes scheduleRoutes)
        {
            _context.ScheduleRoutes.Update(scheduleRoutes);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var scheduleRoute = await _context.ScheduleRoutes.FindAsync(id);
            if (scheduleRoute == null) return false;
            else
            {
                _context.ScheduleRoutes.Remove(scheduleRoute);
                var countRowsAffected = await _context.SaveChangesAsync();
                return countRowsAffected > 0;
            }
        }
    }
}

