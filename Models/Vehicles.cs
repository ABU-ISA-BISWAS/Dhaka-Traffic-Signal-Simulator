namespace DhakaTrafficSim.Models;

public class Rickshaw : Vehicle
{
    public Rickshaw(int arrivalTick) : base(arrivalTick) { }

    public override string TypeName => "Rickshaw";
    public override int Size => 1;
}




public class Cng : Vehicle
{
    public Cng(int arrivalTick) : base(arrivalTick) { }

    public override string TypeName => "CNG";
    public override int Size => 2;
}

public class Car : Vehicle
{
    public Car(int arrivalTick) : base(arrivalTick) { }


    public override string TypeName => "Car";
    public override int Size => 3;
}

public class Bus : Vehicle
{
    public Bus(int arrivalTick) : base(arrivalTick) { }


    public override string TypeName => "Bus";

    public override int Size => 5;
}