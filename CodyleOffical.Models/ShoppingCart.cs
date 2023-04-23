using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        [ValidateNever]
        public Event Event { get; set; }
        
        [Range(1, 5, ErrorMessage =
            "Please enter a value between 1 and 5")]
        public int Count { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Price { get; set; }
    }
}
