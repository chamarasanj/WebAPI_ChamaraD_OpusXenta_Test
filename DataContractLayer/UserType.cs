using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataContractLayer
{
  public  class UserType
    {
        public int ID { get; set; }

        [Display(Name = "User Type")]
        [Required(ErrorMessage = "User Type is required")]
        public string UserTypeName { get; set; }


    }
}
