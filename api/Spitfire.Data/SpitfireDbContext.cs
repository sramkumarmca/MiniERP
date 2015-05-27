using System.Data.Entity;
using Spitfire.Data.Configurations;
using Spitfire.Domain;

namespace Spitfire.Data
{
    public class SpitfireDbContext : DbContext
    {
        public IDbSet<User> Users { get; set; }

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
