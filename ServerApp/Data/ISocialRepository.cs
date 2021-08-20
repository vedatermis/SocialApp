using ServerApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public interface ISocialRepository
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}
