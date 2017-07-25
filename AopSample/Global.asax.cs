using AopSample.IoC;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace AopSample
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start() {
            Bootstrapper.Initialise();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new DIControllerActivator());
        }
    }
}
