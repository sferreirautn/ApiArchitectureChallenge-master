using Entities;

namespace DataAccess.Interfaces
{
    public interface IClientMapper
    {
        Task<bool> CreateClientAsync(Client client);

        Task<Client?> GetClientByCustomerNumberAsync(int customerNumber);

        Task<bool> UpdateClientAsync(Client client);

        Task<bool> DeleteClientAsync(Client client);
    }
}