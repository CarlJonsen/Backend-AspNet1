using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public class ProjectEntity
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Budget { get; set; }

        // FK till användaren som skapat projektet
        public int ProjectOwnerId { get; set; }
        public UserEntity ProjectOwner { get; set; }

        // FK till klienten
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; }
    }
}
