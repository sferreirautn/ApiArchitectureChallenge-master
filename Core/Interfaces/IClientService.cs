using EntitiesDTO;

namespace Core.Interfaces
{
    public interface IClientService
    {
        Task<bool> CreateClientAsync(ClientDTO client);

        Task<ClientDTO?> GetClientByCustomerNumberAsync(int customerNumber);

        Task<bool> UpdateClientAsync(ClientDTO client);

        Task<bool> DeleteClientAsync(int customerNumber);
    }
}