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
  public  class Company
    {
        public int CompanyID { get; set; }

        public string CompanyName { get; set; }

        public string  Email { get; set; }

        public string  LogoPath { get; set; }

        public string  Website { get; set; }
    }
}
