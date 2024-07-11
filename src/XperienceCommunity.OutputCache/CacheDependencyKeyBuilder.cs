using System.Text;

namespace XperienceCommunity.OutputCache
{
    /// <summary>
    /// Represents a builder for generating cache dependency keys.
    /// </summary>
    public class CacheDependencyKeyBuilder
    {
        private readonly HashSet<string> _keys;
        private string? _prefix;

        private CacheDependencyKeyBuilder()
        {
            _keys = new HashSet<string>();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CacheDependencyKeyBuilder"/> class.
        /// </summary>
        /// <returns>The new instance of <see cref="CacheDependencyKeyBuilder"/>.</returns>
        public static CacheDependencyKeyBuilder Create()
        {
            return new CacheDependencyKeyBuilder();
        }

        /// <summary>
        /// Adds a cache dependency key based on the channel name.
        /// </summary>
        /// <param name="channelName">The channel name.</param>
        /// <returns>The current instance of <see cref="CacheDependencyKeyBuilder"/>.</returns>
        public CacheDependencyKeyBuilder AddChannel(string channelName)
        {
            return AddKey($"{Constants.CacheSegments.Channel}|{channelName}");
        }

        /// <summary>
        /// Adds a cache dependency key based on the children of a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The current instance of <see cref="CacheDependencyKeyBuilder"/>.</returns>
        public CacheDependencyKeyBuilder AddChildrenOfPath(string path)
        {
            return AddKey($"{Constants.CacheSegments.ChildrenOfPath}|{path}");
        }

        /// <summary>
        /// Adds a cache dependency key based on the code name.
        /// </summary>
        /// <param name="codeName">The code name.</param>
        /// <returns>The current instance of <see cref="CacheDependencyKeyBuilder"/>.</returns>
        public CacheDependencyKeyBuilder AddCodeName(string codeName)
        {
            return AddKey($"{Constants.CacheSegments.ByName}|{codeName}");
        }

        /// <summary>
        /// Adds a cache dependency key based on the content type.
        /// </summary>
        /// <param name="contentType">The content type.</param>
        /// <returns>The current instance of <see cref="CacheDependencyKeyBuilder"/>.</returns>
        public CacheDependencyKeyBuilder AddContentType(string contentType)
        {
            return AddKey($"{Constants.CacheSegments.ByContentType}|{contentType}");
        }

        /// <summary>
        /// Adds a cache dependency key based on the GUID.
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <returns>The current instance of <see cref="CacheDependencyKeyBuilder"/>.</returns>
        public CacheDependencyKeyBuilder AddGuid(Guid guid)
        {
            return AddKey($"{Constants.CacheSegments.ByGuid}|{guid}");
        }

        /// <summary>
        /// Adds a cache dependency key based on the ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The current instance of <see cref="CacheDependencyKeyBuilder"/>.</returns>
        public CacheDependencyKeyBuilder AddId(int id)
        {
            return AddKey($"{Constants.CacheSegments.ById}|{id}");
        }

        /// <summary>
        /// Adds a cache dependency key based on the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The current instance of <see cref="CacheDependencyKeyBuilder"/>.</returns>
        public CacheDependencyKeyBuilder AddPath(string path)
        {
            return AddKey($"{Constants.CacheSegments.ByPath}|{path}");
        }

        /// <summary>
        /// Builds the cache dependency keys.
        /// </summary>
        /// <returns>An array of cache dependency keys.</returns>
        public string[] Build()
        {
            return [.. _keys];
        }

        /// <summary>
        /// Sets the prefix for content item cache dependency keys.
        /// </summary>
        /// <returns>The current instance of <see cref="CacheDependencyKeyBuilder"/>.</returns>
        public CacheDependencyKeyBuilder ForContentItem()
        {
            _prefix = Constants.CacheSegments.ContentItem;
            return this;
        }

        /// <summary>
        /// Sets the prefix for web page item cache dependency keys.
        /// </summary>
        /// <returns>The current instance of <see cref="CacheDependencyKeyBuilder"/>.</returns>
        public CacheDependencyKeyBuilder ForWebPageItem()
        {
            _prefix = Constants.CacheSegments.WebPageItem;
            return this;
        }

        private CacheDependencyKeyBuilder AddKey(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                _keys.Add($"{_prefix}|{key}");
            }

            return this;
        }
    }
}
