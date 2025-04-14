using Infrastructure.Business.Domains.Dto;
using Infrastructure.Business.Services.Interfaces;
using Infrastructure.Data.Models;
using Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync(string sortByDaysLeft = "asc")
        {
            bool orderByDescending = sortByDaysLeft.ToLower() == "desc";

            var projects = await _projectRepository.GetAllAsync(
                orderByDescending: orderByDescending,
                sortBy: p => p.EndDate, // 👈 Sortera efter EndDate
                filterBy: null,
                includes: new Expression<Func<ProjectEntity, object>>[]
                {
            p => p.Client,
            p => p.ProjectOwner
                });

            var result = projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                ProjectName = p.ProjectName,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Budget = p.Budget,

                ClientId = p.ClientId,
                ClientName = p.Client?.ClientName ?? "Unknown",

                ProjectOwnerId = p.ProjectOwnerId,
                ProjectOwnerName = p.ProjectOwner != null
                    ? $"{p.ProjectOwner.Firstname} {p.ProjectOwner.Lastname}"
                    : "Unknown"
            });

            return result;
        }
        public async Task<bool> UpdateProjectAsync(int id, UpdateProjectRequest request)
        {
            var project = await _projectRepository.GetAsync(p => p.Id == id);

            if (project == null)
                return false;

            project.ProjectName = request.ProjectName;
            project.Description = request.Description;
            project.ImageUrl = request.ImageUrl;
            project.StartDate = request.StartDate;
            project.EndDate = request.EndDate;
            project.Budget = request.Budget;
            project.ClientId = request.ClientId;
            project.ProjectOwnerId = request.ProjectOwnerId;

            return await _projectRepository.UpdateAsync(project); // 👈 returnerar true/false
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            return await _projectRepository.DeleteAsync(p => p.Id == id);
        }

        public async Task<ProjectDto?> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetAsync(
                p => p.Id == id,
                p => p.Client,
                p => p.ProjectOwner
            );

            if (project == null)
                return null;

            return new ProjectDto
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                ImageUrl = project.ImageUrl,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Budget = project.Budget,
                ClientId = project.ClientId,
                ClientName = project.Client?.ClientName ?? "Unknown",
                ProjectOwnerId = project.ProjectOwnerId,
                ProjectOwnerName = project.ProjectOwner != null
                    ? $"{project.ProjectOwner.Firstname} {project.ProjectOwner.Lastname}"
                    : "Unknown"
            };
        }
    }
}
