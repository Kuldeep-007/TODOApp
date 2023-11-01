using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOApp.Data.Entity;

namespace TODOApp.Data.Repositories.Interfaces
{
    public interface IWorkItemRepository
    {
        Task<IEnumerable<WorkItem>> GetAllWorkItems();
    }
}
