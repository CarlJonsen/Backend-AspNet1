using Infrastructure.Business.Domains.Dto;
using Infrastructure.Data.Models;
using BCrypt.Net;
using Infrastructure.Data.Repository.Interfaces;
using Infrastructure.Business.Services.Interfaces;

namespace Infrastructure.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUserAsync(CreateUserRequest request)
        {

            var emailExists = await _userRepository.ExistsAsync(u => u.Email == request.Email);
            if (emailExists)
                throw new Exception("E-postadressen är redan registrerad.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new UserEntity
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
                PasswordHash = hashedPassword,
                Role = "User"
            };

            return await _userRepository.AddAsync(user);
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.Firstname,
                LastName = u.Lastname
            });
        }
    }
}
