using Microsoft.EntityFrameworkCore;
using TODOApp.Data.Entity;
using TODOApp.Data.Repositories.Interfaces;

namespace TODOApp.Data.Repositories.Implementations
{
    public class WorkItemRepository : RepositoryBase, IWorkItemRepository
    {
        public WorkItemRepository(TODOAppDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<WorkItem>> GetAllWorkItems()
        {
            return await _workItemRepository.All();
        }
    }
}
