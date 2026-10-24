namespace DhakaTrafficSim.Core;

public interface ISignalPolicy
{
    string Name { get; }

    Phase GetGreenPhase(int tick, Road northSouth, Road eastWest);
}