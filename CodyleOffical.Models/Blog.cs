using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.Models
{
    public class Blog
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public string blogContent { get; set; }

        public string Author { get; set; }
        public string Date { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

        [ValidateNever]
        public DateTime? DatePosted { get; set; }

        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

    }
}
