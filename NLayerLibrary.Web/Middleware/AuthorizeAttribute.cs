using NLayerLibrary.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerLibrary.Web.Controllers;
using System;
using NLayerLibrary.Web.Models;

namespace NLayerLibrary.Web.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var account = (Person)context.HttpContext.Items["User"];
            if (account == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Not Autorized" }) { StatusCode = StatusCodes.Status401Unauthorized};
            }
        }
    }
}