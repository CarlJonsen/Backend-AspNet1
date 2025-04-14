using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Domains.Dto
{
    public class UpdateProjectRequest
    {
        [Required]
        public string ProjectName { get; set; } = string.Empty;
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
        [Required]
        public int ProjectOwnerId { get; set; }
    }
}
