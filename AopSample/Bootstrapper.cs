using AopSample.ApplicationServices;
using AopSample.IoC;
using AopSample.Repositories;
using System.Reflection;
using System.Web.Http;
using System.Linq;
using Castle.Core;
using AopSample.Helper;

namespace AopSample
{
    public class Bootstrapper
    {
        public static void Initialise() {
            Container.Register<ICurrentContext, CurrentContext>(LifestyleType.PerWebRequest);
            Container.Register<ServiceInterceptor>();
            Container.Register<IUserRepository, UserRepository>();
            Container.Register<ILog, Log>();
            Container.RegisterServices<IService, UserService>();

            var controllerTypes =
                from t in Assembly.GetExecutingAssembly().GetTypes()
                where typeof(ApiController).IsAssignableFrom(t)
                select t;

            foreach (var t in controllerTypes) {
                Container.Register(t, LifestyleType.Transient);
            }
        }
    }
}