using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Data.Entity.Log
{
    public class IntegrationLog
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public string ApiPath { get; set; }
        public string HttpStatusCode { get; set; }
        public string RequestJson { get; set; }
        public string ResponseJson { get; set; }
        public DateTime RequestStartTime { get; set; }
        public DateTime RequestEndTime { get; set; }
    }
}
