using System.Data.Entity;
using Spitfire.Data.Configurations;
using Spitfire.Domain;

namespace Spitfire.Data
{
    public class SpitfireDbContext : DbContext
    {
        public IDbSet<User> Users { get; set; }

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Country> Countries { get; set; }

        public IDbSet<City> Cities { get; set; }


        public SpitfireDbContext()
            : base("SpitfireDbContext")
        {
        }

        public SpitfireDbContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
