using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ClientWebApp_OpusXenta_Test_ChamaraD.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }


        [Display(Name = "Login Email")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        [Required(ErrorMessage = "Login Email is Required")]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(255, ErrorMessage = "Must be between 3 and 255 characters", MinimumLength = 3)]
        public string Password { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        
      
      
        public int UserTypeID { get; set; }

     
        [Display(Name = "User Type Name")]
        public string UserTypeName { get; set; }

     


        [Display(Name = "Active User")]
        public bool IsActive { get; set; }

    }
}