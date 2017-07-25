using AopSample.ApplicationServices;
using AopSample.IoC;
using AopSample.Repositories;
using System.Reflection;
using System.Web.Http;
using System.Linq;
using Castle.Core;
using AopSample.Helper;
using AopSample.DynamicHandlers;
using AopSample.Interceptors;
using AopSample.Validation;

namespace AopSample
{
    public class Bootstrapper
    {
        public static void Initialise() {
            Container.Register<ServiceInterceptor>();
            Container.Register<ICurrentContext, CurrentContext>(LifestyleType.PerWebRequest);
            Container.RegisterWithBase(typeof(ICustomValidator<>), typeof(CustomValidator<>));
            Container.Register<IUserRepository, UserRepository>();
            Container.Register<ILog, Log>();
            Container.RegisterServices<IService, UserService>();

            Container.Register<IServiceInterceptor, DataValidationInterceptor>();

            Container.Register<IDynamicHandler, AuthenticationHandler>(LifestyleType.PerWebRequest);

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