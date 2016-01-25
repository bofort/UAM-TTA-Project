using System.Web.Http;
using WebActivatorEx;
using RestApiProject;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace RestApiProject
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            Swashbuckle.Bootstrapper.Init(GlobalConfiguration.Configuration);

            // NOTE: If you want to customize the generated swagger or UI, use SwaggerSpecConfig and/or SwaggerUiConfig here ...

            SwaggerSpecConfig.Customize(c =>
            {
                c.IncludeXmlComments(GetXmlCommentsPath());
            });
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\RestApp.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
