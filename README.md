# Dhaka Traffic Signal Simulator

A C# console simulation that compares two traffic signal strategies at a busy
Dhaka intersection and stores the results in SQLite.

## The problem
A fixed timer signal wastes green time on empty roads. Does a signal that
reacts to queue length reduce waiting time?

## How it works
- Vehicles (Rickshaw, CNG, Car, Bus, Motorcycle) arrive randomly and join a road queue.
- A signal policy decides which road gets green each tick.
- Both policies run on the same random seed, so the comparison is fair.
- Results are saved with Entity Framework Core + SQLite.

## OOP concepts used
- Abstraction + Inheritance: abstract Vehicle and 4 subclasses
- Polymorphism: Size per vehicle type, ISignalPolicy implementations
- Encapsulation: private queues and state inside Road, Simulator
- Strategy pattern: swap FixedSignal / AdaptiveSignal without touching Simulator
- Factory + Repository patterns

## Tech
C#, .NET, Entity Framework Core, SQLite
