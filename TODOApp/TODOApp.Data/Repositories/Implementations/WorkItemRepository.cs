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

        public async Task<bool> AddWorkItem(WorkItem workItem)
        {
            await _workItemRepository.Add(workItem);
            return true;
        }

        public async Task<bool> UpdateWorkItem(WorkItem workItem)
        {
            var item = await _workItemRepository.GetById(workItem.Id);
            item.Subject = workItem.Subject;
            item.ScheduledOn = workItem.ScheduledOn;
            item.Description = workItem.Description;
            item.ModifiedOn = workItem.ModifiedOn;

            await _workItemRepository.Save();
            return true;
        }

        public async Task<bool> DeleteWorkItem(int id)
        {
            await _workItemRepository.Delete(id);
            return true;
        }

        public async Task<bool> CompleteWorkItem(int id)
        {
            var item = await _workItemRepository.GetById(id);
            item.IsActive = false;
            await _workItemRepository.Save();

            return true;
        }
    }
}
