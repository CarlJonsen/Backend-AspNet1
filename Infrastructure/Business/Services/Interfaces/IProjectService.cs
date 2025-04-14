using Infrastructure.Business.Domains.Dto;
using Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Services.Interfaces
{
    public interface IProjectService
    {
        Task<bool> CreateProjectAsync(CreateProjectRequest request);
        Task<IEnumerable<ProjectDto>> GetAllProjectsAsync(string sortByDaysLeft);
        Task<bool> UpdateProjectAsync(int id, UpdateProjectRequest request);
        Task<bool> DeleteProjectAsync(int id);
        Task<ProjectDto?> GetProjectByIdAsync(int id);
    }
}
