using StorageInstruments.DataContract.Repository;
using StorageInstruments.DataContract.Service;
using StorageInstruments.DataContract.Utils;
using StorageInstruments.DTO;
using StorageInstruments.Model;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StorageInstruments.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly ISeriLog logger;

        public UserService(IRepository<User> repository, ISeriLog logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<UserDto> Login(string username, string password)
        {
            if(!string.IsNullOrWhiteSpace(username) || !string.IsNullOrWhiteSpace(password))
            {
                var aux = await repository.GetAllAsync();
                var toParse = aux.FirstOrDefault(x => (x.UserName.Equals(username) && x.Password.Equals(password)));
                if (toParse == null)
                {
                    logger.WriteLog($"Username not found", Microsoft.Extensions.Logging.LogLevel.Warning);
                    return null;
                }
                return DTO.DTO.UserToDto(toParse);
            }
            return null;
        }

        public string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
