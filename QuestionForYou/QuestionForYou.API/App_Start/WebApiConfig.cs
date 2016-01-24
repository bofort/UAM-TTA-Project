using System.Linq;
using System.Net.Http.Formatting;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;
using QuestionForYou.Data.Service;
using QuestionForYou.Data.Storage;
using System.Reflection;
using System.Web.Http;
using System.Web.Security;

namespace QuestionForYou.API
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                //new CamelCasePropertyNamesContractResolver();
            //config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;

            config.MapHttpAttributeRoutes();

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            ConfigureContainer(builder);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }

        private static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register(_ => new QuestionForYouContext("QuestionForYouConnectionString")).As<QuestionForYouContext>();
            builder.RegisterType<QuestionFactory>().As<IQuestionFactory>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<QuestionService>().As<IQuestionService>();
            builder.RegisterType<AnswerService>().As<IAnswerService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
        }
    }
}