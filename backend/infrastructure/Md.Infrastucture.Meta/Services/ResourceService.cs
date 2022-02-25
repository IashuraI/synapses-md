using Md.Infrastucture.Meta.Attributes;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;

namespace Md.Infrastucture.Meta.Services
{
    public class ResourceService
    {
        private readonly IMemoryCache _memoryCache;

        private Dictionary<string, Type> _resourceType = null!;

        public ResourceService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Dictionary<string, Type> GetResourceTypesDictionary()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            if (_memoryCache.TryGetValue($"ResourceTypes{nameof(AppDomain.FriendlyName)}", out _resourceType))
            {
                return _resourceType;
            }
            else
            {
                _resourceType = new Dictionary<string, Type>();

                foreach (Assembly assembly in assemblies)
                {
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.GetCustomAttributes(typeof(ResourceAttribute), true).Length > 0)
                        {
                            _resourceType.Add(nameof(type), type);
                        }
                    }
                }

                _memoryCache.Set($"ResourceTypes{nameof(AppDomain.FriendlyName)}", _resourceType);

                return _resourceType;
            }
        }
    }
}
