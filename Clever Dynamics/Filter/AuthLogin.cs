using Clever_Dynamics_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Clever_Dynamics.Filter
{
    public class AuthLogin : AuthorizeAttribute, IAuthorizationFilter
    {
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            SessionHalper sessionHalper = new SessionHalper();


            string login = await sessionHalper.GetStringAsync("Login", context.HttpContext);


            if (login == string.Empty)
            {

                context.Result = new UnauthorizedResult();
            }
        }
    }
}
