using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using DataSpace.Models;
using Castle.Core.Internal;

namespace DataSpace.Attributes
{
    public class AuthorizeAdminAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            String customerID = context.HttpContext.Session.GetString(nameof(Person.FamilyName));
            if (String.IsNullOrEmpty(customerID))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
