using Microsoft.EntityFrameworkCore;
using StorageInstruments.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageInstruments.Data
{
    public class InstrumentDbContext : DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }

        public DbSet<User> Users { get; set; }
        public InstrumentDbContext(DbContextOptions<InstrumentDbContext> options)
            : base(options)
        {

        }
    }
}
