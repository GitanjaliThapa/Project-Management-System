using Microsoft.EntityFrameworkCore;
using Milestone3Project.Models;

namespace Milestone3Project.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }  // Changed this from 'Tasks' to 'ProjectTasks' for consistency
        public DbSet<Subtask> Subtasks { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
    }

}




// using Microsoft.EntityFrameworkCore;
//
// namespace Milestone3Project.Models
// {
//     public class AppDbContext : DbContext
//     {
//         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
//
//         public DbSet<User> Users { get; set; }
//     }
// }