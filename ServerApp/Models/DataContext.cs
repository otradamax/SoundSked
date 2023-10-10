using Microsoft.EntityFrameworkCore;

namespace ServerApp.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opts): base(opts) {}

    public DbSet<List> Lists {get; set;}
    public DbSet<Album> Albums {get; set;}
    public DbSet<List_Album> List_Albums {get; set;}
}