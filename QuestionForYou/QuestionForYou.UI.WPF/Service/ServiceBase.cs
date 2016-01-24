using System;
using System.Configuration;
using System.Net.Http;

namespace QuestionForYou.UI.WPF.Service
{
    public class ServiceBase
    {
        public static HttpClient CreateClient()
        {
            return new HttpClient
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiAddress"])
            };
        }
    }
}