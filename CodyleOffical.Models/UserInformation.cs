using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodyleOffical.Models
{
    public class UserInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        [Phone]
        [ValidateNever]
        public string PhoneNumber { get; set; }
        public string password { get; set; }
    }
}
