using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using Microsoft.AspNetCore.Http;

namespace XperienceCommunity.OutputCache.Extensions
{
    internal static class KenticoFeatureExtensions
    {
        /// <summary>
        /// Checks if the current request is in preview mode.
        /// </summary>
        /// <param name="context">The HttpContext object.</param>
        /// <returns>True if the request is in preview mode, otherwise false.</returns>
        internal static bool InPreview(this HttpContext context)
        {
            return context?.Kentico()?.Preview()?.Enabled ?? false;
        }

        /// <summary>
        /// Checks if the current request is in edit mode.
        /// </summary>
        /// <param name="context">The HttpContext object.</param>
        /// <returns>True if the request is in edit mode, otherwise false.</returns>
        internal static bool InEditMode(this HttpContext context)
        {
            return context?.Kentico()?.PageBuilder()?.EditMode ?? false;
        }
    }
}
