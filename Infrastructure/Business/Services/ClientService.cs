using Infrastructure.Business.Domains.Dto;
using Infrastructure.Business.Services.Interfaces;
using Infrastructure.Data.Models;
using Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Services
{
    public class ClientService: IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> CreateClientAsync(CreateClientRequest request)
        {
            // Kolla om klient med samma namn+mail redan finns?
            var exists = await _clientRepository.ExistsAsync(c =>
                c.ClientName == request.ClientName && c.Email == request.Email);

            if (exists)
                throw new Exception("Klienten finns redan.");

            var client = new ClientEntity
            {
                ClientName = request.ClientName,
                Email = request.Email,
                Phone = request.Phone,
                BillingAddress = request.BillingAddress,
                BillingReference = request.BillingReference
            };

            return await _clientRepository.AddAsync(client);
        }

        public async Task<IEnumerable<ClientEntity>> GetAllClientsAsync()
        {
            return await _clientRepository.GetAllAsync();
        }
    }
}
