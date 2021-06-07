using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Base.Constants
{
    public static class ApiConstant
    {
        public static class ApiStatus
        {
            public const string Live = "Live";
            public const string Success = "Success";
            public const string Error = "Error";
        }

        public static class ApiHeaders
        {
            public const string AuthorizationToken = "AuthorizationToken";
        }
    }
}
