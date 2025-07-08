using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Data;

/// <summary>
/// Entity Framework Core DbContext for accessing the application's data.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    /// <summary>
    /// Represents the Tasks table in the database.
    /// </summary>
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}