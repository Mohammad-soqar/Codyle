using CodyleOffical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOfficial.Models.ViewModels
{
    public class EventDetailsVM
    {
        public Event Event { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
        public IEnumerable<Speaker> Speaker { get; set; }
       
    }
}
