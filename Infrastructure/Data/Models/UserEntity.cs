using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "User";

        // Extra profilinfo
        public string? PhoneNumber { get; set; }
        public string? JobTitle { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? ImageUrl { get; set; }

        // Relation till City
        public int? CityId { get; set; }
        public CityEntity? City { get; set; }

        // Relationer
        public ICollection<ProjectEntity> OwnedProjects { get; set; }
    }
}
