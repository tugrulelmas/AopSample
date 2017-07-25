using AopSample.ApplicationServices;
using AopSample.DTOs;
using System;
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

        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get() {
            var result = userService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(Guid id) {
            var result = userService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Add([FromBody]UserDTO user) {
            userService.Add(user);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
