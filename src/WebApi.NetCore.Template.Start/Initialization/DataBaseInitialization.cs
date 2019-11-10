using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.NetCore.Template.DAL;

namespace WebApi.NetCore.Template.Start.Initialization
{
    public class DataBaseInitialization
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            MigrateDb(serviceProvider);
        }

        private static void MigrateDb(IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<MainContext>();

            // auto migration
            context.Database.Migrate();
        }
    }
}