using StorageInstruments.DTO;
using System.Threading.Tasks;

namespace StorageInstruments.DataContract.Service
{
    public interface IUserService
    {
        Task<UserDto> Login(string username, string password);
    }
}
