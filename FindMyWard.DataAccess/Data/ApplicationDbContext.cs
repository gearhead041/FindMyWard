using FindMyWard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FindMyWard.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<StudentInfo> Students { get; set; }

    public DbSet<WardInfo> Wards { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<Notification> Notifications { get; set; }
}
