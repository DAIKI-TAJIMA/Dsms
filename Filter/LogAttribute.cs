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
using Dsms.Business;
using Dsms.Model;

namespace Dsms.Filter
{
    public class LogAttribute : ProjecActionFilterAttributeBase
    {
        public LogAttribute()
        {
            this.Order = 0;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //
            ProjecControllerBase controller = (ProjecControllerBase)context.Controller;
            //
            Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor action = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            //
            L1_SOSAModel model = new L1_SOSAModel();
            model.CD_USER = controller.SessionMan.UserCd;
            model.ID_SESSION = controller.SessionMan.SessionId;
            model.ID_PROGRAM = controller.ProgramId;
            model.ID_GAMEN = controller.GamenId;
            model.AN_CONTROLLER = string.Format("{0}Controller", action.ControllerName);
            model.AN_ACTION = action.ActionName;
            model.TM_SHORI = null;
            model.AN_IP_ADDRESS = context.HttpContext.Connection.RemoteIpAddress.ToString();

            CommonBusiness bs = new CommonBusiness(controller.ConnectionInfo, controller.BCP);
            bs.InsertL1Sosa(model);

            base.OnActionExecuting(context);
        }

    }
}
