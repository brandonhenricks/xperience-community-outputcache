using CMS.ContactManagement;
using CMS.Helpers;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Primitives;
using XperienceCommunity.OutputCache.Extensions;

namespace XperienceCommunity.OutputCache.Policies
{
    public sealed class XperienceOutputCachePolicy : IOutputCachePolicy
    {
        private readonly IWebPageDataContextRetriever _webPageDataContextRetriever;

        public XperienceOutputCachePolicy(IWebPageDataContextRetriever webPageDataContextRetriever)
        {
            _webPageDataContextRetriever = webPageDataContextRetriever;
        }

        public ValueTask CacheRequestAsync(OutputCacheContext context, CancellationToken cancellation)
        {
            var attemptOutputCaching = AttemptOutputCaching(context);
            context.EnableOutputCaching = attemptOutputCaching;
            context.AllowCacheLookup = attemptOutputCaching;
            context.AllowCacheStorage = attemptOutputCaching;
            context.AllowLocking = true;

            context.CacheVaryByRules.VaryByValues.TryAdd(nameof(ContactInfo.ContactID),
                ContactManagementContext.CurrentContactID.ToString());

            // Vary by any query by default
            context.CacheVaryByRules.QueryKeys = "*";
            context.CacheVaryByRules.RouteValueNames = "*";

            return ValueTask.CompletedTask;
        }

        public ValueTask ServeFromCacheAsync(OutputCacheContext context, CancellationToken cancellation)
        {
            return ValueTask.CompletedTask;
        }

        public ValueTask ServeResponseAsync(OutputCacheContext context, CancellationToken cancellation)
        {
            var response = context.HttpContext.Response;

            // Verify existence of cookie headers
            if (!StringValues.IsNullOrEmpty(response.Headers.SetCookie))
            {
                context.AllowCacheStorage = false;
                return ValueTask.CompletedTask;
            }

            // Check response code
            if (response.StatusCode != StatusCodes.Status200OK &&
                response.StatusCode != StatusCodes.Status301MovedPermanently)
            {
                context.AllowCacheStorage = false;
                return ValueTask.CompletedTask;
            }

            var cacheKeys = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            if (_webPageDataContextRetriever.TryRetrieve(out var pageData))
            {
                cacheKeys.Add($"webpageitem|bychannel|{pageData.WebPage.WebsiteChannelName}");

                cacheKeys.Add($"webpageitem|byid|{pageData.WebPage.WebPageItemID}|{pageData.WebPage.LanguageName}");
            }

            var cacheItemKeys = context.HttpContext.GetDependencyKeys();

            foreach (var key in cacheItemKeys)
            {
                cacheKeys.Add(key);
            }

            foreach (var key in cacheKeys)
            {
                CacheHelper.EnsureDummyKey(key);

                context.Tags.Add(key);
            }

            context.AllowCacheStorage = true;

            return ValueTask.CompletedTask;
        }

        private static bool AttemptOutputCaching(OutputCacheContext context)
        {
            // Check if the current request fulfills the requirements to be cached

            var request = context.HttpContext.Request;

            // Verify the method
            if (!HttpMethods.IsGet(request.Method) &&
                !HttpMethods.IsHead(request.Method))
            {
                return false;
            }

            if (context.HttpContext.InPreview()|| context.HttpContext.InEditMode())
            {
                return false;
            }

            // Verify existence of authorization headers
            if (!StringValues.IsNullOrEmpty(request.Headers.Authorization) ||
                request.HttpContext.User?.Identity?.IsAuthenticated == true)
            {
                return false;
            }

            return true;
        }
    }
}
