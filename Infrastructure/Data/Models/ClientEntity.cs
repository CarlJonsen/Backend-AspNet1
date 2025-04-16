using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public class ClientEntity
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BillingAddress { get; set; }
        public string BillingReference { get; set; }

        // Relation till City som ska användas i framtiden
        public int? CityId { get; set; }
        public CityEntity? City { get; set; }

        public ICollection<ProjectEntity> Projects { get; set; }
    }
}
