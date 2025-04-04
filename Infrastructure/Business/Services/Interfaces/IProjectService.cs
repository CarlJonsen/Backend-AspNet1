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
        Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
        Task<bool> UpdateProjectAsync(int id, UpdateProjectRequest request);
        Task<bool> DeleteProjectAsync(int id);
    }
}
