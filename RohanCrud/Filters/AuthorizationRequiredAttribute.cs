using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace RohanCrud.Filters
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionContext)
        {
            string tokenVal = actionContext.Request.Headers.GetValues("Token").First();
            string hardcodedTokenCheck = "shake_and_bake";
            if (tokenVal != hardcodedTokenCheck)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage
                    (System.Net.HttpStatusCode.Unauthorized)
                { ReasonPhrase = "Tokens do not match!" };
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage
                    (System.Net.HttpStatusCode.Unauthorized)
                { ReasonPhrase = "No Token found" };
            }
            base.OnActionExecuted(actionContext);
        }
    }
}