using System;
using appbuscar.Models;

namespace appbuscar.Interfaces
{
    public interface IRoutesRepository
    {
        Task<bool> Delete(int id);
        Task<Routes> GetRoute(int id);
        Task<IEnumerable<Routes>> GetRoutes();
        Task<bool> Insert(Routes route);
        Task<bool> Update(Routes route);
    }
}

