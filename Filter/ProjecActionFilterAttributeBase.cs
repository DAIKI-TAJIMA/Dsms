using Microsoft.AspNetCore.Mvc.Filters;

namespace Dsms.Filter
{
    public class ProjecActionFilterAttributeBase : ActionFilterAttribute
    {
        public ProjecActionFilterAttributeBase()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
