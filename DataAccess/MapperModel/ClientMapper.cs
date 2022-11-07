using DataAccess.Context;
using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.MapperModel
{
    public class ClientMapper : IClientMapper
    {
        private readonly ClientDbContext _clientContext;
        public ClientMapper(ClientDbContext clientContext)
        {
            _clientContext = clientContext;
        }

        public async Task<bool> CreateClientAsync(Client client)
        {
            await _clientContext.Clients.AddAsync(client);
            var save = await _clientContext.SaveChangesAsync();
            if (save != 0)
                return true;
            return false;
        }

        public async Task<Client?> GetClientByCustomerNumberAsync(int customerNumber)
        {
            return await _clientContext.Clients.FirstOrDefaultAsync(c => c.CustomerNumber == customerNumber);
        }

        public async Task<bool> UpdateClientAsync(Client client)
        {
            _clientContext.Clients.Update(client);
            var save = await _clientContext.SaveChangesAsync();
            if (save != 0)
                return true;
            return false;
        }

        public async Task<bool> DeleteClientAsync(Client client)
        {
            _clientContext.Clients.Remove(client);
            var save = await _clientContext.SaveChangesAsync();
            if (save != 0)
                return true;
            return false;
        }
    }
}