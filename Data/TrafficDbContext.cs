using Microsoft.EntityFrameworkCore;

namespace DhakaTrafficSim.Data;

public class TrafficDbContext : DbContext
{
    public DbSet<SimulationRun> Runs => Set<SimulationRun>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=traffic.db");
}