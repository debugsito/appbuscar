using System;
using appbuscar.Models;

namespace appbuscar.Interfaces
{
    public interface IUsersRepository
    {
        Task<bool> Delete(int id);
        Task<Users> GetUser(int id);
        Task<IEnumerable<Users>> GetUsers();
        Task<bool> Insert(Users user);
        Task<bool> Update(Users user);
    }
}

