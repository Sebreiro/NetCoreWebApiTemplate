using System;
using WebApi.NetCore.Template.DAL.Models;

namespace WebApi.NetCore.Template.Api.Dto
{
    public class TestModelDto
    {
        public string Name { get; set; }
        
        public DateTime Created { get; set; }

        public static TestModelDto FromTestModel(TestModel model)
        {
            return new TestModelDto
            {
                Name = model.Name,
                Created = model.Created
            };
        }

        public static TestModel ToTestModel(TestModelDto dto)
        {
            return new TestModel
            {
                Name = dto.Name,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };
        }
    }
}