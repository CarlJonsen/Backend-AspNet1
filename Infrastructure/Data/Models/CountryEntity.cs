using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public class CountryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CityEntity> Cities { get; set; }
    }
}
