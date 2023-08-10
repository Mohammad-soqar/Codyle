using CodyleOfficial.Models;
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
        public ICollection<EventFollowers> Followers { get; set; }

        [ValidateNever]
        public ICollection<EventLike> EventLikes { get; set; }

        [ValidateNever]
        public int NumberOfLikes { get; set; }

        [ValidateNever]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm tt}")]
        public DateTime? StartDate { get; set; }

        [ValidateNever]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm tt}")]
        public DateTime? EndDate { get; set; }

        [ValidateNever]
        public string ScheduleUrl { get; set; }

        [ValidateNever]
        public string Duration { get; set; }

        public string Location { get; set; }

        public string LocationUrl { get; set; }

        public double Price { get; set; }

        [ValidateNever]
        public string Status { get; set; }

        [ValidateNever]
        public string Type { get; set; } //Online //F2F //F2F & Online

        [ValidateNever]
        public string YouTubeLink { get; set; }

        [ValidateNever]
        public string Slides { get; set; }

        [ValidateNever]
        public string Thumbnail { get; set; }

        [ValidateNever]
        public DateTime? DatePosted { get; set; }

        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

        public int NumberOfTickets { get; set; }

        public int? ApplicationCompanyId { get; set; }

        [ValidateNever]
        public ICollection<ApplicationCompany>? Sponsor { get; set; }

        public int? SpeakerpId { get; set; }
        [ValidateNever]

        public ICollection<Speaker> Speakers { get; set; } 



    }
}
