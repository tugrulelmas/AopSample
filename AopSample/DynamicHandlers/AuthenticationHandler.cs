using AopSample.Exceptions;
using AopSample.Helper;
using System.Net.Http;
using System.Web.Http;

namespace AopSample.DynamicHandlers
{
    public class AuthenticationHandler : IDynamicHandler
    {
        private readonly ICurrentContext currentContext;

        public AuthenticationHandler(ICurrentContext currentContext) {
            this.currentContext = currentContext;
        }

        public short Order => 0;

        public void AfterSend(IResponseContext responseContext) {
        }

        public void BeforeSend(IRequestContext requestContext) {
            SetContextActionType(requestContext.Request);

            var actionDescriptor = requestContext.Request.GetActionDescriptor();
            var actionAttributes = actionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true);
            var controllerAttributes = actionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true);
            var isAllowAnonymous = (actionAttributes != null && actionAttributes.Count > 0) || (controllerAttributes != null && controllerAttributes.Count > 0);

            HttpRequestMessage request = requestContext.Request;

            if (request.Headers.Authorization == null || string.IsNullOrWhiteSpace(request.Headers.Authorization.Parameter)) {
                if (isAllowAnonymous) {
                    currentContext.UserName = string.Empty;
                    return;
                }
                throw new DenialException("MissingCredential");
            }

            if (request.Headers.Authorization.Scheme != "Basic") {
                if (isAllowAnonymous) {
                    currentContext.UserName = string.Empty;
                    return;
                }

                throw new DenialException("InvalidCredential");
            }

            currentContext.UserName = request.Headers.Authorization.Parameter;
        }

        public void OnException(IExceptionContext exceptionContext) {
        }

        private void SetContextActionType(HttpRequestMessage request) {
            if (request.Method.Method == "DELETE") {
                currentContext.ActionType = ActionType.Delete;
            } else if (request.Method.Method == "PUT") {
                currentContext.ActionType = ActionType.Update;
            } else if (request.Method.Method == "POST") {
                currentContext.ActionType = ActionType.Add;
            } else {
                currentContext.ActionType = ActionType.List;
            }
        }
    }
}