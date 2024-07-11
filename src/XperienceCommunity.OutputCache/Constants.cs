namespace XperienceCommunity.OutputCache
{
    internal static class Constants
    {
        /// <summary>
        /// Contains the keys for item dependencies.
        /// </summary>
        internal readonly struct ItemKeys
        {
            /// <summary>
            /// The key for dependency keys.
            /// </summary>
            internal const string DependencyKeys = "DependencyKeys";
        }

        internal readonly struct CacheSegments
        {
            /// <summary>
            /// Represents the cache segment for a content item.
            /// </summary>
            internal const string ContentItem = "contentitem";

            /// <summary>
            /// Represents the cache segment for a web page item.
            /// </summary>
            internal const string WebPageItem = "webpageitem";

            /// <summary>
            /// Represents the cache segment for a channel.
            /// </summary>
            internal const string Channel = "bychannel";

            /// <summary>
            /// Represents the cache segment for an item by its GUID.
            /// </summary>
            internal const string ByGuid = "byguid";

            /// <summary>
            /// Represents the cache segment for an item by its ID.
            /// </summary>
            internal const string ById = "byid";

            /// <summary>
            /// Represents the cache segment for an item by its name.
            /// </summary>
            internal const string ByName = "byname";

            /// <summary>
            /// Represents the cache segment for an item by its path.
            /// </summary>
            internal const string ByPath = "bypath";

            /// <summary>
            /// Represents the cache segment for items of a specific content type.
            /// </summary>
            internal const string ByContentType = "bycontenttype";

            /// <summary>
            /// Represents the cache segment for children of a specific path.
            /// </summary>
            internal const string ChildrenOfPath = "childrenofpath";
        }
    }
}
