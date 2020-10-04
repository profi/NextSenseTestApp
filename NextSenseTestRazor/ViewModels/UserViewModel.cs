using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NextSenseTestRazor.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Nameis required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Names required")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderTypeEnum Gender { get; set; }
        public string Genderr { get; set; }

    }
}
