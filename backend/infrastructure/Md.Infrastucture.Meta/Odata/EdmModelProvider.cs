using Md.Infrastucture.Meta.Attributes;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Reflection;

namespace Md.Infrastucture.Meta.Odata
{
    public static class EdmModelProvider
    {
        public static IEdmModel GetEdmModel(string assemblyName)
        {
            ODataConventionModelBuilder builder = new();

            foreach (Type type in GetTypesInNamespace(Assembly.Load(assemblyName)))
            {
                EntityTypeConfiguration entityType = builder.AddEntityType(type);
                builder.AddEntitySet(type.Name, entityType);
            }

            return builder.GetEdmModel();
        }

        private static IEnumerable<Type> GetTypesInNamespace(Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.GetCustomAttribute(typeof(ResourceAttribute)) != default);
        }
    }
}
