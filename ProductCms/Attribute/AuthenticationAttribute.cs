using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductCms.Base.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCms.Base.Extension;

namespace ProductCms.Attribute
{
    public class AuthenticationAttribute : TypeFilterAttribute
    {
        public AuthenticationAttribute() : base(typeof(AuthenticationAttributeImplementation))
        {

        }

        private class AuthenticationAttributeImplementation : IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext context)
            {
                var authToken = context.HttpContext.Request.Headers[ApiConstant.ApiHeaders.AuthorizationToken];

                if (string.IsNullOrEmpty(authToken)) throw new Exception(string.Format("{0} is required.", ApiConstant.ApiHeaders.AuthorizationToken));

                //convertion headers to find user.
                string decodedToken = authToken.ToString().DecodeBase64();
                string[] userInfo = decodedToken.Split(':');

                if (userInfo == null || userInfo.Count() != 2) throw new Exception(string.Format("{0} must be in format (username:password)", ApiConstant.ApiHeaders.AuthorizationToken));

                //to-do : check user here.

                if (!(userInfo[0] == "client1" && userInfo[1] == "client1_password"))
                {
                    //todo:convert response to http 403 status code.
                    throw new Exception("Authentication Failed");
                } 
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {

            }
        }
    }
}
