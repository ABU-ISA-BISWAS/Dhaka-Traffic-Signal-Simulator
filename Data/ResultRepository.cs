using DhakaTrafficSim.Core;

namespace DhakaTrafficSim.Data;

public class ResultRepository : IDisposable
{
    private readonly TrafficDbContext _db = new();

    public ResultRepository()
    {
        _db.Database.EnsureCreated();
    }

    public void Save(SimulationResult r)
    {
        _db.Runs.Add(new SimulationRun
        {
            PolicyName = r.PolicyName,
            TotalTicks = r.TotalTicks,
            VehiclesArrived = r.VehiclesArrived,
            VehiclesPassed = r.VehiclesPassed,
            AverageWait = r.AverageWait,
            MaxQueueLength = r.MaxQueueLength,
            RunAt = DateTime.Now
        });
        _db.SaveChanges();
    }

    public List<SimulationRun> GetRecent(int count = 10) =>
        _db.Runs.OrderByDescending(x => x.Id).Take(count).ToList();

    public void Dispose() => _db.Dispose();
}