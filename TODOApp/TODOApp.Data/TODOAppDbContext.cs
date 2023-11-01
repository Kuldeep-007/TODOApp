using Microsoft.EntityFrameworkCore;
using TODOApp.Data.Entity;

namespace TODOApp.Data
{
    public class TODOAppDbContext : DbContext
    {
        public TODOAppDbContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<WorkItem> WorkItem { get; set; }

        /// <summary>
        /// Configure the entity rules
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //WorkItem
            modelBuilder.Entity<WorkItem>().ToTable("WorkItem");
            modelBuilder.Entity<WorkItem>().HasKey(t => t.Id);
            modelBuilder.Entity<WorkItem>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
