using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IndieVisible.Web
{
    public class EtagAttribute : Attribute, IActionFilter
    {
        private readonly int[] _statusCodes;

        public EtagAttribute(params int[] statusCodes)
        {
            _statusCodes = statusCodes;
            if (statusCodes.Length == 0)
            {
                _statusCodes = new[] { 200 };
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotSupportedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Request.Method == "GET" && _statusCodes.Contains(context.HttpContext.Response.StatusCode))
            {
                string content = JsonConvert.SerializeObject(context.Result);

                string etag = ETagGenerator.GetETag(context.HttpContext.Request.Path.ToString(), Encoding.UTF8.GetBytes(content));

                if (context.HttpContext.Request.Headers.Keys.Contains(HeaderNames.IfNoneMatch) && context.HttpContext.Request.Headers[HeaderNames.IfNoneMatch].ToString() == etag)
                {
                    context.Result = new StatusCodeResult(304);
                }
                context.HttpContext.Response.Headers.Add(HeaderNames.ETag, new[] { etag });
            }
        }
    }

    // Helper class that generates the etag from a key (route) and content (response)
    public static class ETagGenerator
    {
        public static string GetETag(string key, byte[] contentBytes)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] combinedBytes = Combine(keyBytes, contentBytes);

            return GenerateETag(combinedBytes);
        }

        private static string GenerateETag(byte[] data)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(data);
                string hex = BitConverter.ToString(hash);
                return hex.Replace("-", "");
            }
        }

        private static byte[] Combine(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            Buffer.BlockCopy(a, 0, c, 0, a.Length);
            Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }
    }
}
