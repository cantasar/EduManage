using Microsoft.EntityFrameworkCore;

namespace EduManage.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Registry> Registries { get; set; }
}