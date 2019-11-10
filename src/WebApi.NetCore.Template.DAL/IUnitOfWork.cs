using System.Threading.Tasks;
using WebApi.NetCore.Template.DAL.Models;

namespace WebApi.NetCore.Template.DAL
{
    public interface IUnitOfWork
    {
        IRepository<TestModel> TestModelRepository { get; }

        void Commit();

        Task CommitAsync();
    }
}