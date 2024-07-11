using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;

namespace XperienceCommunity.OutputCache.Extensions
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Adds the specified dependency keys to the HttpContext items.
        /// </summary>
        /// <remarks>If the HttpContext already contains keys, new keys will be appended.</remarks>
        /// <param name="context">The HttpContext.</param>
        /// <param name="dependencyKeys">The dependency keys to add.</param>
        public static void AddDependencyKeys(this HttpContext context, string[] dependencyKeys)
        {
            if (!context.Items.TryAdd(Constants.ItemKeys.DependencyKeys, dependencyKeys))
            {
                var existingKeys = context.Items[Constants.ItemKeys.DependencyKeys] as string[] ?? [];

                var combinedKeys = existingKeys.Concat(dependencyKeys).ToArray();

                context.Items[Constants.ItemKeys.DependencyKeys] = combinedKeys;
            }
        }

        /// <summary>
        /// Gets the dependency keys from the HttpContext items.
        /// </summary>
        /// <param name="context">The HttpContext.</param>
        /// <returns>The dependency keys.</returns>
        [return: NotNull]
        public static string[] GetDependencyKeys(this HttpContext context)
        {
            return context?.Items[Constants.ItemKeys.DependencyKeys] as string[] ?? [];
        }
    }
}
