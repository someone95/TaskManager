using Common.Entities;
using System.Data.Entity;

namespace DatabaseAccess.DatabaseContext
{
    public class TaskManagerContext : DbContext
    {
        internal DbSet<User> Users { get; set; }
        internal DbSet<Task> Tasks { get; set; }
        internal DbSet<Comment> Comments { get; set; }
        internal DbSet<Logwork> Logworks { get; set; }

        public TaskManagerContext()
            : base("TaskManagerContext")
        {

        }
    }

}
