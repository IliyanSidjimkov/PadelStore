
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PadelStore.Web.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        

        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection,
            Type serviceType)
        {
            Assembly servicesAssembly = serviceType.Assembly;

            IEnumerable<Type> serviceInterfaces = servicesAssembly
                .GetTypes()
                .Where(t => t.IsInterface &&
                            t.Name.StartsWith("I") && t.Name.EndsWith("Service"))
                .ToArray();
            foreach (Type currentServiceType in serviceInterfaces)
            {
                Type implementationType = servicesAssembly
                    .GetTypes()
                    .Single(t => t is { IsClass: true, IsAbstract: false } &&
                                 currentServiceType.IsAssignableFrom(t));

                serviceCollection.AddScoped(currentServiceType, implementationType);
            }

            return serviceCollection;
        }
    }
}
