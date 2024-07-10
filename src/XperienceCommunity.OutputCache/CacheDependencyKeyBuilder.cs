using System.Text;

namespace XperienceCommunity.OutputCache
{
    public class CacheDependencyKeyBuilder
    {
        private readonly HashSet<string> _keys;
        private string? _prefix;

        private CacheDependencyKeyBuilder()
        {
            _keys = new HashSet<string>();
        }

        public static CacheDependencyKeyBuilder Create()
        {
            return new CacheDependencyKeyBuilder();
        }

        public CacheDependencyKeyBuilder AddChannel(string channelName)
        {
            return AddKey($"bychannel|{channelName}");
        }

        public CacheDependencyKeyBuilder AddChildrenOfPath(string path)
        {
            return AddKey($"childrenofpath|{path}");
        }

        public CacheDependencyKeyBuilder AddCodeName(string codeName)
        {
            return AddKey($"byname|{codeName}");
        }

        public CacheDependencyKeyBuilder AddContentType(string contentType)
        {
            return AddKey($"bycontenttype|{contentType}");
        }

        public CacheDependencyKeyBuilder AddGuid(Guid guid)
        {
            return AddKey($"byguid|{guid}");
        }

        public CacheDependencyKeyBuilder AddId(int id)
        {
            return AddKey($"byid|{id}");
        }
        
        public CacheDependencyKeyBuilder AddPath(string path)
        {
            return AddKey($"bypath|{path}");
        }

        public string[] Build()
        {
            return _keys.ToArray();
        }

        public CacheDependencyKeyBuilder ForContentItem()
        {
            _prefix = "contentitem";
            return this;
        }

        public CacheDependencyKeyBuilder ForWebPageItem()
        {
            _prefix = "webpageitem";
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
