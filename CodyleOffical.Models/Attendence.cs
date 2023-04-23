using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.Models
{
    public class Attendence
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string typeOfAttendence { get; set; }
      
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        [ValidateNever]
        public Event Event { get; set; }

        //[ValidateNever]
        //public string ApplicationUserId { get; set; }
        //[ForeignKey("ApplicationUserId")]
        //[ValidateNever]
        //public ApplicationUser ApplicationUser { get; set; }
    }
}
