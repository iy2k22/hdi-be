using Hdi.BE.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hdi.BE.Contexts;

public class HdiDbContext : DbContext
{
    public DbSet<Continent> Continents { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<ScoreType> ScoreTypes { get; set; }
    
    public HdiDbContext(DbContextOptions<HdiDbContext> options) : base(options)
    {}
}