using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.NetCore.Template.DAL.Models;

namespace WebApi.NetCore.Template.DAL.EntityConfiguration
{
    public class TestModelConfiguration : IEntityTypeConfiguration<TestModel>
    {
        public void Configure(EntityTypeBuilder<TestModel> builder)
        {
            builder.Property(x => x.Name).IsRequired();
        }
    }
}