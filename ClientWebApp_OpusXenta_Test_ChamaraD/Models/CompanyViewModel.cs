using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientWebApp_OpusXenta_Test_ChamaraD.Models
{
    public class CompanyViewModel
    {
        public int CompanyID { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Display(Name = "Login Email")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }

        [Display(Name = "Company Logo")]
        //public string LogoPath { get; set; }
        public HttpPostedFileBase LogoPath { get; set; }

        //[Url]
        public string Website { get; set; }

        [NotMapped]
        public IEnumerable<EmployeeViewModel> EmployeeList { get; set; }


    }
}