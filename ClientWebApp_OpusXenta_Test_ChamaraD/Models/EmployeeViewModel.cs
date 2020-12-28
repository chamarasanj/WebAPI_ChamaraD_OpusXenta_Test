using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClientWebApp_OpusXenta_Test_ChamaraD.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompanyID { get; set; }
        public string CompanyName { get; set; }

        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Skills { get; set; }
    }
}