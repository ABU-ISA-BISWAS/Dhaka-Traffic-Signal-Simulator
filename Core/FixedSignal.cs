namespace DhakaTrafficSim.Core;

public class FixedSignal : ISignalPolicy
{
    private readonly int cycleLength;

    public FixedSignal(int _cycleLength = 10)
    {
        cycleLength = _cycleLength;
    }

    public string Name => $"Fixed({cycleLength})";

    public Phase GetGreenPhase(int tick, Road northSouth, Road eastWest)
    {
        return (tick / cycleLength) % 2 == 0 ? Phase.NorthSouth : Phase.EastWest;
    }
}