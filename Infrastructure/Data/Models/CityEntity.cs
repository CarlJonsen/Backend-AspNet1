using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public class CityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public CountryEntity Country { get; set; }

        public ICollection<UserEntity> Users { get; set; }
        public ICollection<ClientEntity> Clients { get; set; }
    }
}
