using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientWebApp_OpusXenta_Test_ChamaraD.Models
{
    public class SecurityProfileModelView
    {

        [Display(Name = "ID")]
        public int SecurityProfileID { get; set; }

        [Display(Name = "Security Profile Name")]
        [Required(ErrorMessage = "Security Profile Name is required")]
        public string Name { get; set; }
        public bool IsCreate { get; set; }
        public bool IsRead { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
    }
}