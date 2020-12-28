using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebApp_OpusXenta_Test_ChamaraD.Models
{
    public class SecurityProfile_UserViewModel
    {
        public int ID { get; set; }

        public int SecurityProfileID { get; set; }

        public string  SecurityProfileName { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }
    }
}