using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;


namespace coretask2
{
    public class SetAccessGlobally:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var value = context.HttpContext.Session.GetString("Name");
            if (value == null)
            {
                context.Result =
                    new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"Contrller","MasterCRUD" },
                        {"Action", "Login" }
                    });
            }
            base.OnActionExecuting(context);
        }

    }
}
