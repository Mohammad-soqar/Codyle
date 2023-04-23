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
    public class BlogCart
    {

        public int Id { get; set; }

        public int BlogId { get; set; }
        [ForeignKey("BlogId")]
        [ValidateNever]
        public Blog Blog { get; set; }
        

     
    }
}
