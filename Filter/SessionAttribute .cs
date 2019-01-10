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
        public SessionAttribute()
        {
            this.Order = 1;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //
            ProjecControllerBase controller = (ProjecControllerBase)context.Controller;
            // 
            Enums.Code_ユーザ権限[] usableRoles = controller.UsableRoles;
            string userCd = controller.SessionMan.UserCd;
            Enums.Code_ユーザ権限 kengen = controller.SessionMan.Kengen;

            if (userCd == Constants.STRANGER_USERCD || !((IList<Enums.Code_ユーザ権限>)usableRoles).Contains(kengen))
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
