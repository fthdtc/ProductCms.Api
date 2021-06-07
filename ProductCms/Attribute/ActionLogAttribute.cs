using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductCms.Base.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCms.Attribute
{
    public class ActionLogAttribute : TypeFilterAttribute
    {
        public ActionLogAttribute() : base(typeof(ActionLogAttributeImplementation))
        {

        }

        private class ActionLogAttributeImplementation : IActionFilter
        {
            private DateTime startTime { get; set; }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                LogHelper.Info(string.Format("Action Started - Path:{0}", context.HttpContext.Request.Path.Value));
            }

            //improvement: create middleware to implement a listener for actual execution time, or a method attribute in action.
            public void OnActionExecuted(ActionExecutedContext context)
            {
                LogHelper.Info(string.Format("Action Completed - Path:{0}", context.HttpContext.Request.Path.Value));
            }
        }
    }
}
