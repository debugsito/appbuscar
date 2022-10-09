using System;
using appbuscar.Models;

namespace appbuscar.Interfaces
{
    public interface IRolesRepository
    {
        Task<bool> Delete(int id);
        Task<Roles> GetRole(int id);
        Task<IEnumerable<Roles>> GetRoles();
        Task<bool> Insert(Roles role);
        Task<bool> Update(Roles role);
    }
}

