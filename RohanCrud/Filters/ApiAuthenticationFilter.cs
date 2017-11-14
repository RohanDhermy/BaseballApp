using RohanCrud.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;

namespace RohanCrud.Filters
{
    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        public override bool OnAuthorizeUser(string userName, string password, HttpActionContext context)
        {
            if (userName == "rickybobby" && password == "shakenbake")
            {
                BasicAuthenticationIdentity basicIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicIdentity != null)
                {
                    basicIdentity.UserId = 2;
                    basicIdentity.FullName = "Ricky Bobby";
                }
                return true;
            }
            return false;
        }
    }
}