using CodyleOffical.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOfficial.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ValidateNever]
        public string LinkedIn { get; set; }

        [ValidateNever]
        public string Instagram { get; set; }

        [ValidateNever]
        public string Behance { get; set; }

        [ValidateNever]
        public string GitHub { get; set; }

        [ValidateNever]
        public string PersonalWebsite { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
        [ValidateNever]
        public ICollection<Event> Events { get; set; }

    }
}
