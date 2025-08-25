namespace Taskms.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var hrDepartmentId = Guid.Parse("60bece64-d9fe-4533-a326-08569eaa37df");
            var salesDepartmentId = Guid.Parse("927759d0-61d9-49e9-9f04-48536964b6c9");
            var marketingDepartmentId = Guid.Parse("fd9e1927-baaa-4d65-8380-f7b0cb35beed");

            modelBuilder.Entity<Department>().HasData
            (
                new Department
                {
                    Id = hrDepartmentId,
                    Name = "Human Resources"
                },
                new Department
                {
                    Id = salesDepartmentId,
                    Name = "Sales"
                },
                new Department
                {
                    Id = marketingDepartmentId,
                    Name = "Marketing"
                }
            );

            modelBuilder.Entity<User>().HasData
            (
                new User
                {
                    Id = Guid.Parse("954f60ae-b788-4bc2-b2a1-45abb9a8e6fd"),
                    Name = "Mery",
                    SurName = "Glenn",
                    Email = "mary@company.com",
                    Password = "mery1234!",
                    Title = "Human Resources Specialist",
                    DepartmentId = hrDepartmentId
                },
                new User
                {
                    Id = Guid.Parse("86dfdcd5-bd0e-4d0c-b754-7d36055761cb"),
                    Name = "John",
                    SurName = "Doe",
                    Email = "john@company.com",
                    Password = "john4321!",
                    Title = "Sales Department Manager",
                    DepartmentId = salesDepartmentId
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(w =>
                w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }  
    }
}