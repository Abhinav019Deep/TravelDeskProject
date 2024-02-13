using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using TravelDeskProject.Models;

public class TravelDbContext : DbContext
{
    //public TravelDbContext()
    //{

    //}
    public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=StuDb;integrated security=true;TrustServerCertificate=true");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Seeding Country Master Data using HasData method
            modelBuilder.Entity<Department>().HasData(
            new() { DepartmentId = 1, DepartmentName = "IT" },
            new() { DepartmentId = 2, DepartmentName = "Sales" },
            new() { DepartmentId = 3, DepartmentName = "HR" }); 
        //Seeding State Master Data using HasData method
    }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<TravelRequest> TravelRequests { get; set; }
}