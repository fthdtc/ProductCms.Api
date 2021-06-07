using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProductCms.Base.Helper;
using ProductCms.Data.Entity.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProductCms.Service.Middleware
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            using (MemoryStream requestBodyStream = new MemoryStream())
            {
                using (MemoryStream responseBodyStream = new MemoryStream())
                {
                    Stream originalRequestBody = context.Request.Body;

                    Stream originalResponseBody = context.Response.Body;

                    try
                    {
                        DateTime startTime = DateTime.Now;
                        string requestBodyText = string.Empty;
                        string responseBody = string.Empty;

                        await context.Request.Body.CopyToAsync(requestBodyStream);
                        requestBodyStream.Seek(0, SeekOrigin.Begin);

                        requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();

                        requestBodyStream.Seek(0, SeekOrigin.Begin);
                        context.Request.Body = requestBodyStream;

                        context.Response.Body = responseBodyStream;

                        Stopwatch watch = Stopwatch.StartNew();
                        await _next(context);
                        watch.Stop();

                        responseBodyStream.Seek(0, SeekOrigin.Begin);
                        responseBody = new StreamReader(responseBodyStream).ReadToEnd();

                        var integrationLog = new IntegrationLog
                        {
                            Method = context.Request.Method,
                            ApiPath = context.Request.Path,
                            HttpStatusCode = context.Response.StatusCode.ToString(),
                            RequestJson = requestBodyText,
                            ResponseJson = responseBody,
                            RequestStartTime = startTime,
                            RequestEndTime = DateTime.Now
                        };

                        LogHelper.Info(string.Format("Api Request:\n{0}", JsonConvert.SerializeObject(integrationLog)));

                        responseBodyStream.Seek(0, SeekOrigin.Begin);

                        await responseBodyStream.CopyToAsync(originalResponseBody);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Exception(ex, string.Format("error occoured in LoggerMiddleware : {0}", ex.Message));
                        byte[] data = System.Text.Encoding.UTF8.GetBytes("Unhandled Error occured, the error has been logged and the persons concerned are notified!! Please, try again in a while.");
                        originalResponseBody.Write(data, 0, data.Length);
                    }
                    finally
                    {
                        context.Request.Body = originalRequestBody;
                        context.Response.Body = originalResponseBody;
                    }
                }
            }
        }
    }
}