using System;

namespace WebApi.NetCore.Template.DAL.Models
{
    public class TestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}