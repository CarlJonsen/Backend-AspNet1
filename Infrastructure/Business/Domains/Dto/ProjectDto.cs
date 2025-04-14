using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Domains.Dto
{
    public class ProjectDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; } = null!;
        [Required]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int Budget { get; set; }
        [Required]
        public int ClientId { get; set; }
        public string ClientName { get; set; } = null!;

        [Required]
        public int ProjectOwnerId { get; set; }
        public string ProjectOwnerName { get; set; } = null!;
        public bool IsCompleted => EndDate < DateTime.Now;
    }
}
