using Microsoft.AspNetCore.Mvc;
using TODOApp.Data.Entity;
using TODOApp.Data.Repositories.Interfaces;
using TODOApp.Web.Models;

namespace TODOApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkItemRepository _iWorkItemRepository;

        public HomeController(IWorkItemRepository iWorkItemRepository)
        {
            _iWorkItemRepository = iWorkItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allWorkItems = await _iWorkItemRepository.GetAllWorkItems();
            return View(allWorkItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateWorkItem(WorkItemModel workItem)
        {
            var newWorkItem = new WorkItem()
            {
                Subject = workItem.Subject,
                ScheduledOn = workItem.ScheduledOn,
                Description = workItem.Description,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsActive = true
            };

            if (workItem.Id > 0)
            {
                newWorkItem.Id = workItem.Id;
                return Ok(await _iWorkItemRepository.UpdateWorkItem(newWorkItem));
            }
            else
            {
                return Ok(await _iWorkItemRepository.AddWorkItem(newWorkItem));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWorkItem(int id)
        {
            return Ok(await _iWorkItemRepository.DeleteWorkItem(id));
        }

        [HttpPost]
        public async Task<IActionResult> CompleteWorkItem(int id)
        {
            return Ok(await _iWorkItemRepository.CompleteWorkItem(id));
        }
    }
}
