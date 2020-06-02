using StorageInstruments.Model;
using System.Threading.Tasks;

namespace StorageInstruments.DataContract.Service
{
    public interface IUserService
    {
        Task<User> Login(string username, string password);
    }
}
