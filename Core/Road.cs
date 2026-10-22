using DhakaTrafficSim.Models;

namespace DhakaTrafficSim.Core;

public class Road
{
    private readonly Queue<Vehicle> queue = new();

    public string Name { get; }
    public int QueueLength => queue.Count;

    public Road(string name)
    {
        Name = name;
    }

    public void Enqueue(Vehicle vehicle) => queue.Enqueue(vehicle);

    public List<Vehicle> Release(int capacity)
    {
        var released = new List<Vehicle>();

        while (queue.Count > 0 && queue.Peek().Size <= capacity)
        {
            var vehicle = queue.Dequeue();

            capacity -= vehicle.Size;
            released.Add(vehicle);
        }
        return released;
    }
}