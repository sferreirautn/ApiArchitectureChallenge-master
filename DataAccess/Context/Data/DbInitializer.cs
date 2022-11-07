using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Context.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new ClientDbContext(serviceProvider.GetRequiredService<DbContextOptions<ClientDbContext>>()))
            {
                if (_context.Clients.Any())
                {
                    return;
                }

                _context.Clients.AddRange(
                    new Client { Id = 1, Name = "Luis", LastName = "Lopez", CustomerNumber = 101 },
                    new Client { Id = 2, Name = "Ricardo", LastName = "Bifano", CustomerNumber = 102 },
                    new Client { Id = 3, Name = "Lautaro", LastName = "Albarese", CustomerNumber = 103 }
                 );

                _context.SaveChanges();
            }
        }
    }
}
