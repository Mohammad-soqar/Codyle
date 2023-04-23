using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.Models
{
    public class Services
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string BusinessName { get; set; }
        public string TypeOfService { get; set; }
        public string Budget { get; set; }
        public string Description { get; set; }
        public string ProductService { get; set; }

        [ValidateNever]
        public string? SMPlatforms { get; set; }
        [ValidateNever]
        public string? WebsiteUrl { get; set; }

        [ValidateNever]
        public string? LaunchDate { get; set; }

        [ValidateNever]
        public string? Guidelines { get; set; }

        [ValidateNever]
        public string? FavoritewebUrl1 { get; set; }

        [ValidateNever]
        public string? FavoritewebUrl2 { get; set; }

        [ValidateNever]
        public string? FavoritewebUrl3 { get; set; }

        [ValidateNever]
        public string? Maintenance { get; set; }

        [ValidateNever]
        public string? SocialMediaM { get; set; }

        [ValidateNever]
        public string? InstagramURL { get; set; }




    }
}
