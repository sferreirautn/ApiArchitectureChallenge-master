using AutoMapper;
using Core.Interfaces;
using DataAccess.Interfaces;
using Entities;
using EntitiesDTO;
using static Core.Helpers.Exceptions;

namespace Core.ServiceModel
{
    public class ClientService : IClientService
    {
        private readonly IClientMapper _clientMapper;
        private readonly IMapper _mapper;
        public ClientService(IClientMapper clientMapper, IMapper mapper)
        {
            _clientMapper = clientMapper;
            _mapper = mapper;
        }

        public async Task<bool> CreateClientAsync(ClientDTO clientDTO)
        {
            Client client = _mapper.Map<Client>(clientDTO);
            return await _clientMapper.CreateClientAsync(client);
        }

        public async Task<ClientDTO?> GetClientByCustomerNumberAsync(int customerNumber)
        {
            ClientDTO clientDTO = _mapper.Map<ClientDTO>(await _clientMapper.GetClientByCustomerNumberAsync(customerNumber));
            return clientDTO;
        }

        public async Task<bool> UpdateClientAsync(ClientDTO clientDTO)
        {
            Client? client = await _clientMapper.GetClientByCustomerNumberAsync(clientDTO.CustomerNumber);
            if (client == null)
                throw new UnprocessableEntity("customer doesn't exist");

            client.Name = clientDTO.Name;
            client.LastName = clientDTO.LastName;
            //No permito que edite el CustomerNumber
            return await _clientMapper.UpdateClientAsync(client);
        }

        public async Task<bool> DeleteClientAsync(int customerNumber)
        {
            Client? client = await _clientMapper.GetClientByCustomerNumberAsync(customerNumber);
            if (client == null)
                throw new UnprocessableEntity("customer doesn't exist");

            
            return await _clientMapper.DeleteClientAsync(client);
        }
    }
}