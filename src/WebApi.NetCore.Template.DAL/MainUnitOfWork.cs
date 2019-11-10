using System.Threading.Tasks;
using WebApi.NetCore.Template.DAL.Models;

namespace WebApi.NetCore.Template.DAL
{
    public class MainUnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;

        public IRepository<TestModel> TestModelRepository => new Repository<TestModel>(_context);

        public MainUnitOfWork(MainContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}