using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Domains.Dto
{
    public class CreateClientRequest
    {
        [Required]
        public string ClientName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string BillingAddress { get; set; }

        public string? BillingReference { get; set; }
    }
}
