namespace DhakaTrafficSim.Models;

public abstract class Vehicle
{
    private static int nextId = 1;
    public int Id { get; }
    public int ArrivalTick { get; }

    public abstract string TypeName { get; }
    public abstract int Size { get; }  

    protected Vehicle(int arrivalTick)
    {
        Id = nextId++;
        ArrivalTick = arrivalTick;
    }
}