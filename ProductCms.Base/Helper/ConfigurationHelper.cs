using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ProductCms.Base.Helper
{
    public class ConfigurationHelper
    {
        public static string GetConnectionString(string connectionString)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var conStr = root.GetConnectionString(connectionString);

            if (string.IsNullOrEmpty(conStr)) throw new Exception(string.Format("Connectionstring is not loaded : {0}", connectionString));

            return conStr;
        }
    }
}
