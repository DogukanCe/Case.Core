using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Case.Serivce.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            // Request Logging
            var request = context.Request;
            var requestLog = new RequestLog
            {
                Method = request.Method,
                Path = request.Path,
                QueryString = request.QueryString.Value,
                Headers = request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
                Body = await GetRequestBody(request)
            };
            logger.Information("{@Request}", requestLog);

            // Response Logging
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                var response = context.Response;
                var responseLog = new ResponseLog
                {
                    StatusCode = response.StatusCode,
                    Headers = response.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
                    Body = await GetResponseBody(response)
                };
                logger.Information("{@Response}", responseLog);

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> GetRequestBody(HttpRequest request)
        {
            request.EnableBuffering();
            var bodyStream = request.Body;
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await bodyStream.ReadAsync(buffer, 0, buffer.Length);
            bodyStream.Seek(0, SeekOrigin.Begin);
            var bodyText = Encoding.UTF8.GetString(buffer);
            return bodyText;
        }

        private async Task<string> GetResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return bodyText;
        }
    }
}
