using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.NetCore.Template.Start.Initialization
{
    public static class OptionsInitialization
    {
        public static void Initialize(IServiceCollection serviceCollection,IConfiguration configurationRoot)
        {
//            serviceCollection.Configure<TestOptions>(configurationRoot.GetSection("testOptions"));
        }
    }
}