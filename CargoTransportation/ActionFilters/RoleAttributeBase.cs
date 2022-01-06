using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RequestHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoTransportation.ActionFilters
{
    public abstract class RoleAttributeBase : IActionFilter
    {
        private IRequestManager RequestManager { get; set; }
        protected abstract string RequiredRole { get; set; }

        public RoleAttributeBase(IRequestManager request)
        {
            this.RequestManager = request;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!RequestManager.HttpClient.UserRoles.Contains(RequiredRole))
                context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}
