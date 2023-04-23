using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.Models.ViewModels
{
    public class AttendenceVM
    {
        public Attendence Attendence { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> EventList { get; set; }
        

    }
}
