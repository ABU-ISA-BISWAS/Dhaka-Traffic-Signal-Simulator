using DhakaTrafficSim.Models;

namespace DhakaTrafficSim.Core;

public static class VehicleFactory
{
    public static Vehicle CreateRandom(Random random, int tick)
    {
        int roll = random.Next(100);
        if (roll < 25) return new Rickshaw(tick);
        if (roll < 55) return new Motorcycle(tick);
        if (roll < 75) return new Cng(tick);
        if (roll < 92) return new Car(tick);
        return new Bus(tick);
    }
}