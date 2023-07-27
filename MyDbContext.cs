using Microsoft.EntityFrameworkCore;
using WebApplication1;

public class MyDbContext : DbContext
{
    public MyDbContext() { }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    public virtual DbSet<MyModel>? MyModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MyModel>()
            .HasKey(o => o.Data);
    }
}