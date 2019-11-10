using Microsoft.Extensions.DependencyInjection;
using WebApi.NetCore.Template.DAL;

namespace WebApi.NetCore.Template.Start.Initialization
{
    public static class ContainerConfiguration
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, MainUnitOfWork>();
        }
    }
}