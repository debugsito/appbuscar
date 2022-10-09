using System;
using appbuscar.Models;

namespace appbuscar.Interfaces
{
    public interface IBusesRepository
    {
        Task<bool> Delete(int id);
        Task<Buses> GetBus(int id);
        Task<IEnumerable<Buses>> GetBuses();
        Task<bool> Insert(Buses bus);
        Task<bool> Update(Buses bus);
    }
}

