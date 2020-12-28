using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContractLayer
{
    public class APIResult
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string SyncCode { get; set; }

        //  public HttpStatusCode httpCode { get; set; }
    }
}
