using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext() { }
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("Client_DB");
        }
    }
}
