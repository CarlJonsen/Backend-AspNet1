using Infrastructure.Business.Domains.Dto;
using Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Services.Interfaces
{
    public interface IClientService
    {
        Task<bool> CreateClientAsync(CreateClientRequest request);
        Task<IEnumerable<ClientEntity>> GetAllClientsAsync();
    }
}
