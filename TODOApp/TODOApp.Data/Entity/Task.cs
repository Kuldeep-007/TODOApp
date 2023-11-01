namespace TODOApp.Data.Entity
{
    public class WorkItem : Entity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledOn { get; set; }
    }
}
