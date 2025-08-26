namespace Taskms.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //Creating DB Schemas
        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Department> Departments { get; set; }

        //Setting DB Schmea Tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Department ID's
            var hrDepartmentId = Guid.Parse("60bece64-d9fe-4533-a326-08569eaa37df");
            var salesDepartmentId = Guid.Parse("927759d0-61d9-49e9-9f04-48536964b6c9");
            var marketingDepartmentId = Guid.Parse("fd9e1927-baaa-4d65-8380-f7b0cb35beed");

            //Departments
            modelBuilder.Entity<Department>().HasData(
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

            //Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("954f60ae-b788-4bc2-b2a1-45abb9a8e6fd"),
                    Name = "Mery",
                    Surname = "Glenn",
                    Email = "mary@company.com",
                    Password = "mery1234!",
                    Title = "Human Resources Manager",
                    DepartmentId = hrDepartmentId,
                    Role = "Manager"
                },
                new User
                {
                    Id = Guid.Parse("fbe707f5-4ded-46e9-8f96-499efc03425b"),
                    Name = "Mustafa",
                    Surname = "Ocak",
                    Email = "mustafa@company.com",
                    Password = "mustafa1234!",
                    Title = "Human Resources Specialist",
                    DepartmentId = hrDepartmentId,
                    Role = "Employee"
                },
                new User
                {
                    Id = Guid.Parse("53e9054e-7028-4efc-ad10-4fc21da7a7c8"),
                    Name = "Sedat",
                    Surname = "Akkuş",
                    Email = "sedat@company.com",
                    Password = "sedat1234!",
                    Title = "Human Resources Specialist",
                    DepartmentId = hrDepartmentId,
                    Role = "Employee"
                },
                new User
                {
                    Id = Guid.Parse("86dfdcd5-bd0e-4d0c-b754-7d36055761cb"),
                    Name = "John",
                    Surname = "Doe",
                    Email = "john@company.com",
                    Password = "john1234!",
                    Title = "Sales Department Manager",
                    DepartmentId = salesDepartmentId,
                    Role = "Manager"
                },
                new User
                {
                    Id = Guid.Parse("b2a90398-fbb9-42c5-8831-b838c3948f86"),
                    Name = "Ceyda",
                    Surname = "Aksaç",
                    Email = "ceyda@company.com",
                    Password = "ceyda1234!",
                    Title = "Sales Specialist",
                    DepartmentId = salesDepartmentId,
                    Role = "Employee"
                },
                new User
                {
                    Id = Guid.Parse("702a82ba-02ca-4ab8-82d1-94f501e535e0"),
                    Name = "Yağizhan",
                    Surname = "Avci",
                    Email = "yağizhan@company.com",
                    Password = "yağizhan1234!",
                    Title = "Sales Specialist",
                    DepartmentId = salesDepartmentId,
                    Role = "Employee"
                },
                new User
                {
                    Id = Guid.Parse("69bdc567-73b3-425d-a0e3-ca5243435da1"),
                    Name = "Semih",
                    Surname = "Özdoğan",
                    Email = "semih@company.com",
                    Password = "semih1234!",
                    Title = "Marketing Department Manager",
                    DepartmentId = marketingDepartmentId,
                    Role = "Manager"
                },
                new User
                {
                    Id = Guid.Parse("6ad6fc80-aedc-453f-86f6-ae1daee3bdd2"),
                    Name = "Murat",
                    Surname = "Atalik",
                    Email = "murat@company.com",
                    Password = "murat1234!",
                    Title = "Marketing Specialist",
                    DepartmentId = marketingDepartmentId,
                    Role = "Employee"
                },
                new User
                {
                    Id = Guid.Parse("e21dbfee-6bc8-44fc-b921-5a703cb0ba84"),
                    Name = "Arya",
                    Surname = "Açikgöz",
                    Email = "arya@company.com",
                    Password = "arya1234!",
                    Title = "Marketing Specialist",
                    DepartmentId = marketingDepartmentId,
                    Role = "Employee"
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