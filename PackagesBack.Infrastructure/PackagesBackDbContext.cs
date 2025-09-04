using Microsoft.EntityFrameworkCore;
using PackagesBack.Domain.Entities;

namespace PackagesBack.Infrastructure;

public class PackagesBackDbContext(DbContextOptions<PackagesBackDbContext> options) : DbContext(options)
{
    public DbSet<Package> Packages { get; set; }

}

/*
public class PackagesBackDbContext :DbContext
{
    public PackagesBackDbContext(DbContextOptions<PackagesBackDbContext> options) : base(options) { }
    
    public DbSet<Package> Packages { get; set; }
    
}
*/