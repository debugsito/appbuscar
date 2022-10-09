using System;
using appbuscar.Models;

namespace appbuscar.Interfaces
{
    public interface IScheduleRoutesRepository
    {
        Task<bool> Delete(int id);
        Task<ScheduleRoutes> GetScheduleRoute(int id);
        Task<IEnumerable<ScheduleRoutes>> GetScheduleRoutes();
        Task<bool> Insert(ScheduleRoutes scheduleRoute);
        Task<bool> Update(ScheduleRoutes scheduleRoute);
    }
}

