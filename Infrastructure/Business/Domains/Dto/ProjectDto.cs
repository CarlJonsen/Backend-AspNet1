using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Domains.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Budget { get; set; }

        public string ClientName { get; set; } = null!;
        public string ProjectOwnerName { get; set; } = null!;
        public bool IsCompleted => EndDate < DateTime.Now;
    }
}
