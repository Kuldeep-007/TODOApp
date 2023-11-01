using TODOApp.Data.Entity;

namespace TODOApp.Data.Repositories
{
    public class RepositoryBase
    {
        internal TODOAppDbContext _dbContext;
        internal protected IGenericRepository<WorkItem> _workItemRepository;

        public RepositoryBase(TODOAppDbContext context)
        {
            _dbContext = context;
            _workItemRepository = new GenericRepository<WorkItem>(_dbContext);
        }
    }
}
