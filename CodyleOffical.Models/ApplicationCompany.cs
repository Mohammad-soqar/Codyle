using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.Models
{
    public class ApplicationCompany
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? PhoneNumber { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }

      
        public int CompTypeId { get; set; }
        [ValidateNever]
        public CompType? CompType { get; set; }
        public ICollection<Event> Events { get; set; }


    }
}
