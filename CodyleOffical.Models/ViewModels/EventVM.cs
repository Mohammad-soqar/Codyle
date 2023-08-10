using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.Models.ViewModels
{
    public class EventVM
    {
        public Event Event { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SponsorList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SpeakerList { get; set; }


    }
}
