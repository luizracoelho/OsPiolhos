using Piolhos.Repository.Mappers.Registers;
using System.Web;
using System.Web.Http;

namespace Piolhos.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RegisterMappings.Register();
        }
    }
}
