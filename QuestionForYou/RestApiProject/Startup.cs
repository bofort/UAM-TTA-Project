using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RestApiProject.Startup))]

namespace RestApiProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            Swashbuckle.Bootstrapper.Init(config);

            ConfigureAuth(app);
            app.UseWebApi(config);
        }
    }
}
