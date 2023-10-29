using AutoMapper;
using System.Reflection;

namespace NotesApplication.common.mapping
{
    public class AssemblyMapperProfile : Profile
    {
        public AssemblyMapperProfile(Assembly assembly)
        {
            ApplyMappingFromAssembly(assembly);
        }

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var types = new List<Type>();
            foreach (var type in assembly.GetExportedTypes())
            {
                foreach (var iface in type.GetInterfaces())
                {
                    if (iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(IMapWith<>))
                    {
                        types.Add(type);
                        break;
                    }
                }
            }
            var typesList = types.ToList();
            foreach (var type in typesList)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new Object[] {this});
            }
        }
    }
}
