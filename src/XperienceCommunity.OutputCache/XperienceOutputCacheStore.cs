using CMS.Helpers.Caching;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Memory;

namespace XperienceCommunity.OutputCache
{
    public sealed class XperienceOutputCacheStore: IOutputCacheStore
    {
        private readonly IMemoryCache _cache;
        private readonly ICacheDependencyAdapter _cacheDependencyAdapter;

        public XperienceOutputCacheStore(IMemoryCache cache, ICacheDependencyAdapter cacheDependencyAdapter)
        {
            _cache = cache;
            _cacheDependencyAdapter = cacheDependencyAdapter;
        }

        public ValueTask EvictByTagAsync(string tag, CancellationToken cancellationToken)
        {
            _cache.Remove(tag);

            return ValueTask.CompletedTask;
        }

        public ValueTask<byte[]?> GetAsync(string key, CancellationToken cancellationToken)
        {
            _cache.TryGetValue(key, out byte[]? value);
            return new ValueTask<byte[]?>(value);
        }

        public ValueTask SetAsync(string key, byte[] value, string[]? tags, TimeSpan validFor, CancellationToken cancellationToken)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = validFor
            };

            if (tags?.Length > 0)
            {
                var changeToken = _cacheDependencyAdapter.GetChangeToken(tags);

                options.AddExpirationToken(changeToken);
            }

            _cache.Set(key, value, options);

            return ValueTask.CompletedTask;
        }
    }
}
