using Microsoft.EntityFrameworkCore;
using StorageInstruments.DataContract.Repository;
using StorageInstruments.DataContract.Utils;
using StorageInstruments.Model;

namespace StorageInstruments.Data
{
    public class UserRepository : BaseRepository<User, InstrumentDbContext>, IRepository<User>
    {
        public UserRepository(InstrumentDbContext context, ISeriLog logger) : base(context, logger)
        {
        }
    }
}
