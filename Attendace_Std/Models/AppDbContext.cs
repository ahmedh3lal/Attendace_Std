using Microsoft.EntityFrameworkCore;

namespace Attendace_Std.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Level> levels { get; set; }
        public DbSet<Factory> factories { get; set; }
        public DbSet<Supervisor> supervisors { get; set; }
        public DbSet<Std_factory> std_Factories { get; set; }
        public DbSet<std_supervisor> std_Supervisors { get; set; }
        public DbSet<Specialization> specializations { get; set; }
        public DbSet<Student_attendace> student_attendaces { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_attendace>().HasKey(x => new { x.Id, x.Student_Id, x.DateOnly });
            base.OnModelCreating(modelBuilder);
        }
    }
}
