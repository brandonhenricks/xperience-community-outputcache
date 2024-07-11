using Microsoft.AspNetCore.Http;

namespace XperienceCommunity.OutputCache.Extensions
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Adds the specified dependency keys to the HttpContext items.
        /// </summary>
        /// <param name="context">The HttpContext.</param>
        /// <param name="dependencyKeys">The dependency keys to add.</param>
        public static void AddDependencyKeys(this HttpContext context, string[] dependencyKeys)
        {
            context.Items.Add(Constants.ItemKeys.DependencyKeys, dependencyKeys);
        }

        /// <summary>
        /// Gets the dependency keys from the HttpContext items.
        /// </summary>
        /// <param name="context">The HttpContext.</param>
        /// <returns>The dependency keys.</returns>
        public static string[] GetDependencyKeys(this HttpContext context)
        {
            return context?.Items[Constants.ItemKeys.DependencyKeys] as string[] ?? [];
        }
    }
}
