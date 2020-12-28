using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Web.Mvc;


namespace DataContractLayer
{
  public class Employee
    {
        public int EmployeeID { get; set; }

        public string  FirstName { get; set; }

        public string  LastName { get; set; }

        public int  CompanyID { get; set; }

        public string  CompanyName { get; set; }

        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string  Email { get; set; }

        public string  Phone { get; set; }

        public string  Skills { get; set; }

    }
}
