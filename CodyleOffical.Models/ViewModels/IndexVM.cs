using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.Models.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<Event> Event { get; set; }
     
        public IEnumerable<Blog> Blog { get; set; }
 

    }
}
