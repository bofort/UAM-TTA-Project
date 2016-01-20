using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
