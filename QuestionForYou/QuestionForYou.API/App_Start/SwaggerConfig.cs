using System.Web.Http;
using WebActivatorEx;
using QuestionForYou.API;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace QuestionForYou.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {

                        c.SingleApiVersion("v1", "QuestionForYou.API");
                        c.IncludeXmlComments(GetXmlCommentsPath());

                    })
                .EnableSwaggerUi(c =>
                    {
                        c.InjectStylesheet(thisAssembly, "ReatApi.Assets.test.css");

                        c.CustomAsset("index.html", thisAssembly, "ReatApi.Assets.index.html");

                        c.DisableValidator();
                    });
        }

        private static string GetXmlCommentsPath()
        {
            return $@"{System.AppDomain.CurrentDomain.BaseDirectory}\QuestionForYou.xml";
        }

    }
}