using DhakaTrafficSim.Core;
using DhakaTrafficSim.Models;

var road = new Road("Mirpur 11");

road.Enqueue(new Rickshaw(0));
road.Enqueue(new Bus(0));
road.Enqueue(new Car(1));

Console.WriteLine($"Waiting: {road.QueueLength}");

var passed = road.Release(8);

foreach (var v in passed)
    Console.WriteLine($"{v.TypeName} passed (size {v.Size})");

Console.WriteLine($" Still waiting : {road.QueueLength}");
