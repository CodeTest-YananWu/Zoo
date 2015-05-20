using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DataStore : DbContext
    {
        public DataStore()
            : base("DefaultConnection")
        {
        }
        public DbSet<Zookeeper> Zookeepers { get; set; }
        public DbSet<Animal> Animals { get; set; }
    }
}
