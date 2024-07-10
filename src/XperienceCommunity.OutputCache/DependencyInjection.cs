using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.DependencyInjection;
using XperienceCommunity.OutputCache.Policies;

namespace XperienceCommunity.OutputCache
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds XperienceOutputCacheStore as a singleton service to the IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the service to.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddXperienceOutputCache(this IServiceCollection services)
        {
            services.AddSingleton<IOutputCacheStore, XperienceOutputCacheStore>();
            return services;
        }

        /// <summary>
        /// Adds a custom output cache policy to the OutputCacheOptions.
        /// </summary>
        /// <param name="options">The OutputCacheOptions to add the policy to.</param>
        /// <param name="policyName">The name of the policy.</param>
        /// <param name="expirationTimeSpan">The expiration time span for the policy.</param>
        public static void AddXperienceOutputCachePolicy(this OutputCacheOptions options, string policyName, TimeSpan expirationTimeSpan)
        {
            options.AddPolicy(policyName, builder =>
                    builder
                        .AddPolicy<XperienceOutputCachePolicy>()
                        .Expire(expirationTimeSpan)
                , true);
        }
    }
}
