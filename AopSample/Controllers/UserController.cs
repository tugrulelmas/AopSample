using AopSample.ApplicationServices;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AopSample.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) {
            this.userService = userService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get() {
            return Request.CreateResponse(HttpStatusCode.OK, new { Name = "Yaprak" });
        }
    }
}
