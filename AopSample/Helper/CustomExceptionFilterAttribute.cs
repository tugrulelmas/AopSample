using AopSample.DynamicHandlers;
using AopSample.IoC;
using System.Linq;
using System.Web.Http.Filters;

namespace AopSample.Helper
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context) {
            var dynamicHandlers = Container.ResolveAll<IDynamicHandler>().OrderBy(d => d.Order);
            IExceptionContext exceptionContext = new ExceptionContext(context);
            foreach (var dynamicHandlerItem in dynamicHandlers) {
                dynamicHandlerItem.OnException(exceptionContext);
            }
        }
    }
}