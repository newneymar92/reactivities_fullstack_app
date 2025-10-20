using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options): DbContext(options)
{
    // DbSet<Activity> Activities { get; set; }
    public required DbSet<Activity> Activities { get; set;  }
}