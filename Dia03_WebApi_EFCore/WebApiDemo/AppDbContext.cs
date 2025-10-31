using Microsoft.EntityFrameworkCore;
using WebApiDemo.Models;

namespace WebApiDemo;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<Product> Products => Set<Product>();
}
