using Microsoft.AspNetCore.Http.Extensions;

namespace BackendApiTest.Api.PresentationExtensions
{
    public static class HttpExtensions
    {
        public static string GetPersonIp(this HttpContext httpContext) => httpContext.Connection.RemoteIpAddress!.ToString();

        public static string GetCurrentPageUrl(this HttpContext context)
        => context.Request.GetEncodedUrl();
        public static string GetCurrentDomain(this HttpContext context)
       => (context.Request.IsHttps ? "https://" : "http://") + context.Request.Host.Value;
        public static string GetCurrentHttpsDomain(this HttpContext context)
            => "https://" + context.Request.Host.Value;
    }
}
