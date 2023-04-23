using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ValidateNever]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm tt}")]
        public DateTime? Date { get; set; }
        public string Location { get; set; }
        public string LocationUrl { get; set; }
        public double Price { get; set; }

        [ValidateNever]
        public string Finished { get; set; }

        [ValidateNever]
        public string Slides { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

        [ValidateNever]
        public DateTime? DatePosted { get; set; }
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

        public int NumberOfTickets { get; set; }

        public int? ApplicationCompanyId { get; set; }
        [ValidateNever]
        public ApplicationCompany? Sponsor { get; set; }

    }
}
