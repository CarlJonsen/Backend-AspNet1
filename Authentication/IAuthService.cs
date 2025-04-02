using Infrastructure.Business.Domains.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginRequest request);
    }
}
