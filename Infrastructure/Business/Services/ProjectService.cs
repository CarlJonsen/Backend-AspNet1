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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;

        public ProjectService(
            IProjectRepository projectRepository,
            IUserRepository userRepository,
            IClientRepository clientRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _clientRepository = clientRepository;
        }

        public async Task<bool> CreateProjectAsync(CreateProjectRequest request)
        {
            var userExists = await _userRepository.ExistsAsync(u => u.Id == request.ProjectOwnerId);
            if (!userExists)
                throw new Exception("Ogiltigt användar-ID");

            var clientExists = await _clientRepository.ExistsAsync(c => c.Id == request.ClientId);
            if (!clientExists)
                throw new Exception("Ogiltigt klient-ID");

            var project = new ProjectEntity
            {
                ProjectName = request.ProjectName,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Budget = request.Budget,
                ProjectOwnerId = request.ProjectOwnerId,
                ClientId = request.ClientId
            };

            return await _projectRepository.AddAsync(project);
        }

        public async Task<IEnumerable<ProjectEntity>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllAsync();
        }
    }
}
