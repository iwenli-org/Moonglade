using System;
using System.Net;
using System.Threading.Tasks;
using Edi.Captcha;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moonglade.Configuration.Abstraction;
using Moonglade.Core;
using Moonglade.Core.Notification;
using Moonglade.Model;
using Moonglade.Model.Settings;
using Moonglade.Web.Models;
using Newtonsoft.Json;
using X.PagedList;


namespace Moonglade.Web.Controllers
{
    public class IpController : MoongladeController
    {
        private readonly IBlogConfig _blogConfig;
        private CommentService _commentService;
        private readonly IMoongladeNotificationClient _notificationClient;

        public IpController(
           ILogger<IpController> logger,
           IOptions<AppSettings> settings,
           CommentService commentService,
           IBlogConfig blogConfig,
           IMoongladeNotificationClient notificationClient = null)
           : base(logger, settings)
        {
            _blogConfig = blogConfig;

            _commentService = commentService;
            _notificationClient = notificationClient;
        }


        public Task G()
        {
            Response.StatusCode = (int)HttpStatusCode.OK;

            return Response.WriteAsync(JsonConvert.SerializeObject(
              new
              {
                  Request.Scheme,
                  headers = Request.Headers,
                  IpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                  CommentContent = GetUserAgent(),
              }));
        }

        public new async Task<IActionResult> Redirect(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                url = "http://www.woshipm.com/zhichang/4137496.html";
            }
            try
            {
                if (_blogConfig.EmailSettings.SendEmailOnNewComment && null != _notificationClient)
                {
                    var ips = Request.Headers.ContainsKey("X-Forwarded-For") ? Request.Headers["X-Forwarded-For"].ToString() : "";
                    var ip = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                    await _notificationClient.SendNewCommentNotificationAsync(new CommentListItem
                    {
                        Username = "路由预警",
                        Email = "iwenli@qq.com",
                        IpAddress = ip,
                        CommentContent = GetUserAgent() + Environment.NewLine + url + Environment.NewLine + ips,
                        PostTitle = $"https://www.ip138.com/iplookup.asp?ip={ip}&action=2",
                        IsApproved = false,
                        CreateOnUtc = DateTime.UtcNow
                    }, s => Utils.ConvertMarkdownContent(s, Utils.MarkdownConvertType.Html));
                    return base.Redirect(url);

                }

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { msg = "config err" });
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error GetIp");
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { msg = "runner err" });
            }
        }

    }
}
