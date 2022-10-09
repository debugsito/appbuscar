using System;
using appbuscar.Interfaces;
using appbuscar.Models;
using Microsoft.EntityFrameworkCore;

namespace appbuscar.Repositories
{
    public class RouteTicketsRepository: IRouteTicketsRepository
    {
        private readonly appbuscarContext _context;

        public RouteTicketsRepository(appbuscarContext context)
        {
            _context = context;
        }
        //READ ALL
        public async Task<IEnumerable<RouteTickets>> GetRouteTickets()
        {
            return await _context.RouteTickets.ToListAsync();
        }

        //READ ONE
        public async Task<RouteTickets> GetRouteTicket(int id)
        {
            return await _context.RouteTickets.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(RouteTickets routeTicket)
        {
            await _context.RouteTickets.AddAsync(routeTicket);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Update(RouteTickets routeTicket)
        {
            _context.RouteTickets.Update(routeTicket);
            var countRowsAffected = await _context.SaveChangesAsync();
            return countRowsAffected > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var routeTicket = await _context.RouteTickets.FindAsync(id);
            if (routeTicket == null) return false;
            else
            {
                _context.RouteTickets.Remove(routeTicket);
                var countRowsAffected = await _context.SaveChangesAsync();
                return countRowsAffected > 0;
            }
        }
    }
}

