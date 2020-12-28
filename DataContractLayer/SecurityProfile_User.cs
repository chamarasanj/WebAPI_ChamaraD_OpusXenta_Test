using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContractLayer
{
  public class SecurityProfile_User
    {

        public int ID { get; set; }

        public int SecurityProfileID { get; set; }
        public string SecurityProfileName { get; set; }

        public int UserID { get; set; }
        public string  UserName { get; set; }
    }
}
