using System;
using appbuscar.Models;

namespace appbuscar.Interfaces
{
    public interface IRouteTicketsRepository
    {
        Task<bool> Delete(int id);
        Task<RouteTickets> GetRouteTicket(int id);
        Task<IEnumerable<RouteTickets>> GetRouteTickets();
        Task<bool> Insert(RouteTickets routeTickets);
        Task<bool> Update(RouteTickets routeTickets);
    }
}

