using System.Web;
using System.Web.Mvc;

namespace ClientWebApp_OpusXenta_Test_ChamaraD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
