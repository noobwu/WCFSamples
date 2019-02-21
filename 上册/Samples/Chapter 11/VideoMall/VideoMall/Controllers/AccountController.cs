using System;
using System.Web.Mvc;
using System.Web.Security;
using Artech.VideoMall.Common.Extensions;
using Artech.VideoMall.Infrastructure.Interface;
using Artech.VideoMall.Models;
namespace Artech.VideoMall.Controllers
{
    public class AccountController : ExtendedController
    {
        public ISecurityAudit SecurityAuditService { get; private set; }
        public AccountController(ISecurityAudit securityAuditService)
        {
            this.SecurityAuditService = securityAuditService;
        }
        public ActionResult SignIn()
        {
            return View(new LoginInfo());
        }
        [HttpPost]
        public ActionResult SignIn(LoginInfo loginInfo, string returnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (Membership.ValidateUser(loginInfo.UserName, loginInfo.Password))
            {
                this.SecurityAuditService.AuditForAuthenticationSuccess(loginInfo.UserName);
                FormsAuthentication.SetAuthCookie(loginInfo.UserName, false);
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Products");
                }
                return Redirect(returnUrl);
            }
            else
            {
                this.SecurityAuditService.AuditForAuthenticationFailure(loginInfo.UserName);
                ModelState.AddModelError(Guid.NewGuid().ToString(), "输入的用户名/密码不合法");
                return View();
            }
        }         
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Products");
        }
    }
}
