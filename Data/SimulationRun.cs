namespace DhakaTrafficSim.Data;

public class SimulationRun
{
    public int Id { get; set; }
    public string PolicyName { get; set; } = "";
    public int TotalTicks { get; set; }
    public int VehiclesArrived { get; set; }
    public int VehiclesPassed { get; set; }
    public double AverageWait { get; set; }
    public int MaxQueueLength { get; set; }
    public DateTime RunAt { get; set; }
}