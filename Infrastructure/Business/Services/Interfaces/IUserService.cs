using Infrastructure.Business.Domains.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserRequest request);

        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
