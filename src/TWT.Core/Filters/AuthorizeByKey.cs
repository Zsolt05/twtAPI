using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TWT.Core.Filters
{
    public class AuthorizeByKey : Attribute, IAuthorizationFilter
    {//TWTkey BaliZsolt
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var apiKey = context.HttpContext.Request.Headers["Authorization"];
            if (apiKey.Any())
            {
                var subStrings = apiKey.ToString().Split(" ");
                if (!(subStrings.Length >= 2 && subStrings[0] == "TWTkey" && subStrings[1] == "BaliZsolt"))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}

