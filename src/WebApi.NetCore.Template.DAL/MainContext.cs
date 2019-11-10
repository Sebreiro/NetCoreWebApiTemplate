using Microsoft.EntityFrameworkCore;
using WebApi.NetCore.Template.DAL.EntityConfiguration;
using WebApi.NetCore.Template.DAL.Models;

namespace WebApi.NetCore.Template.DAL
{
    public class MainContext : DbContext
    {
        public DbSet<TestModel> TestModel { get; set; }
        
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TestModelConfiguration());
        }
    }
}