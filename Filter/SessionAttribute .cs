using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
// SetStringとGetStringの拡張メソッドを使うのに必要
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;

using Dsms.Controller;
using Dsms.Resource;

namespace Dsms.Filter
{
    public class SessionAttribute : ProjecActionFilterAttributeBase
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Enums.Code_ユーザ権限[] aaa = ((ProjecControllerBase)context.Controller).UsableRoles;

            string actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            string controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            string userCd = ((ProjecControllerBase)context.Controller).SessionMan.UserCd;
            string sessionId = ((ProjecControllerBase)context.Controller).SessionMan.SessionId;
            string gamenId = ((ProjecControllerBase)context.Controller).GamenId;
            string programId = ((ProjecControllerBase)context.Controller).ProgramId;
            string usersIpAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();

            //string userCd = context.HttpContext.Session.GetString("CD_USER");
            if (userCd == null)
            {
                context.Result = new RedirectToRouteResult(
                                new RouteValueDictionary
                                {
                                                        { "area", "DME001" },
                                                        { "controller", "DME001_001" },
                                                        { "action", "init" }
                                });
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
