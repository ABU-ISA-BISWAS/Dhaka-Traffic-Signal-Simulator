using DhakaTrafficSim.Models;

namespace DhakaTrafficSim.Core;

public class Simulator
{
    private readonly ISignalPolicy _policy;
    private readonly Road _northSouth = new("NorthSouth");
    private readonly Road _eastWest = new("EastWest");
    private readonly Random _random;
    private readonly int _greenCapacity;
    private readonly double _nsArrivalChance;
    private readonly double _ewArrivalChance;

    public Simulator(ISignalPolicy policy, int seed, int greenCapacity = 5,
                     double nsArrivalChance = 0.6, double ewArrivalChance = 0.2)
    {
        _policy = policy;
        _random = new Random(seed);
        _greenCapacity = greenCapacity;
        _nsArrivalChance = nsArrivalChance;
        _ewArrivalChance = ewArrivalChance;
    }

    public SimulationResult Run(int totalTicks)
    {
        int arrived = 0, passed = 0, maxQueue = 0;
        long totalWait = 0;

        for (int tick = 0; tick < totalTicks; tick++)
        {

            if (_random.NextDouble() < _nsArrivalChance)
            {
                _northSouth.Enqueue(VehicleFactory.CreateRandom(_random, tick));
                arrived++;
            }
            if (_random.NextDouble() < _ewArrivalChance)
            {
                _eastWest.Enqueue(VehicleFactory.CreateRandom(_random, tick));
                arrived++;
            }


            var green = _policy.GetGreenPhase(tick, _northSouth, _eastWest);
            var greenRoad = green == Phase.NorthSouth ? _northSouth : _eastWest;

            foreach (var vehicle in greenRoad.Release(_greenCapacity))
            {
                totalWait += tick - vehicle.ArrivalTick;
                passed++;
            }

            maxQueue = Math.Max(maxQueue, Math.Max(_northSouth.QueueLength, _eastWest.QueueLength));
        }

        double avgWait = passed == 0 ? 0 : (double)totalWait / passed;
        return new SimulationResult(_policy.Name, totalTicks, arrived, passed, avgWait, maxQueue);
    }
}