using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Web.Mvc;

namespace DataContractLayer
{
   public class User
    {
        public int UserID { get; set; }

        [Display(Name = "User Name")]
        [StringLength(250, ErrorMessage = "Must be between 5 and 250 characters", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        public string Password { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string  FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

       


        [Display(Name = "User Type ID")]
        public int UserTypeID { get; set; }


        [Display(Name = "Active User")]
        public bool IsActive { get; set; }

        [NotMapped]
        public IEnumerable<UserType> UserTypes { get; set; }

        [NotMapped]
        [Display(Name = "User Type Name")]
        public string UserTypeName { get; set; }

        //[NotMapped]
        //public IEnumerable<SelectListItem> UserTypesList { get; set; }
    }
}
