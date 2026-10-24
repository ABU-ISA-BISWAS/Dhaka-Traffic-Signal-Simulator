namespace DhakaTrafficSim.Core;

public record SimulationResult(
    string PolicyName,
    int TotalTicks,
    int VehiclesArrived,
    int VehiclesPassed,
    double AverageWait,
    int MaxQueueLength);