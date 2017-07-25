using AopSample.Helper;
using System.Web.Http;

namespace AopSample.Controllers
{
    [CustomActionFilter]
    [CustomExceptionFilter]
    public class BaseController : ApiController
    {
    }
}
