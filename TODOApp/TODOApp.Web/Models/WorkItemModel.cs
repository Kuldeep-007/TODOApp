namespace TODOApp.Web.Models
{
    public class WorkItemModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledOn { get; set; }
    }
}
