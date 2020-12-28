using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace ClientWebApp_OpusXenta_Test_ChamaraD
{
    public static class ConsumeWebAPI
    {
        public static HttpClient WebApiClient = new HttpClient();

        static ConsumeWebAPI()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44324/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));




        }
    }
}