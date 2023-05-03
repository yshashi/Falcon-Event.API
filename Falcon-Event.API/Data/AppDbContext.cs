using Falcon_Event.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Falcon_Event.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().ToTable("users");
        builder.Entity<Contact>().ToTable("contacts");
    }
}