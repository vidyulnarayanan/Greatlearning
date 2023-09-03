using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_FinalProject.Models
{
    public class Registration
    {
        [Display(Name = "id")]
        public int Id { get; set; }
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }
        [Display(Name = "Lastname")]
        public string LastName { get; set; }
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]

        public string DateOfBirth { get; set; }
        [Display(Name = "Gender")]

        public string Gender { get; set; }
        [Display(Name = "Phone number")]

        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]

        public string Email { get; set; }
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]

        public string Address { get; set; }
        [Display(Name = "City")]

        public string City { get; set; }
        [Display(Name = "State")]


        public string State { get; set; }
        [Display(Name = "Pincode")]


        public string Pincode { get; set; }
        [Display(Name = "Username")]

        public string UserName { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
    }
}