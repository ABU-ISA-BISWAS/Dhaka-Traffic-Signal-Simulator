namespace DhakaTrafficSim.Core;

public class AdaptiveSignal : ISignalPolicy
{
    private readonly int _minGreen;
    private Phase _current = Phase.NorthSouth;
    private int _ticksInPhase = 0;

    public AdaptiveSignal(int minGreen = 5)
    {
        _minGreen = minGreen;
    }

    public string Name => $"Adaptive(minGreen={_minGreen})";

    public Phase GetGreenPhase(int tick, Road northSouth, Road eastWest)
    {
        var currentRoad = _current == Phase.NorthSouth ? northSouth : eastWest;
        var otherRoad = _current == Phase.NorthSouth ? eastWest : northSouth;

        if (_ticksInPhase >= _minGreen && otherRoad.QueueLength > currentRoad.QueueLength)
        {
            _current = _current == Phase.NorthSouth ? Phase.EastWest : Phase.NorthSouth;
            _ticksInPhase = 0;
        }

        _ticksInPhase++;
        return _current;
    }
}