using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Moonglade.Web.Middleware.PoweredBy
{
    public class PoweredByMiddleware
    {
        private readonly RequestDelegate _next;

        public PoweredByMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var headers = context.Request.Headers;
            context.Response.Headers["X-Powered-By"] = "Moonglade";
            if (headers.ContainsKey("X-Forwarded-For"))
            {
                context.Connection.RemoteIpAddress = IPAddress.Parse(headers["X-Forwarded-For"].ToString().Split(',', StringSplitOptions.RemoveEmptyEntries)[0]);
            }
            return _next.Invoke(context);
        }
    }
}
