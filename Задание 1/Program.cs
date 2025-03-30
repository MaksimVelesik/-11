public interface IVehicle
{
    void Move();
}

public class Car : IVehicle
{
    public void Move()
    {
        Console.WriteLine("The car is driving.");
    }
}

public class Bus : IVehicle
{
    public void Move()
    {
        Console.WriteLine("The bus is moving.");
    }
}

public class Bicycle : IVehicle
{
    public void Move()
    {
        Console.WriteLine("The bicycle is being pedaled.");
    }
}

public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}

public class CarFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Car();
    }
}

public class BusFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Bus();
    }
}

public class BicycleFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Bicycle();
    }
}

class Program
{
    static void Main(string[] args)
    {
        VehicleFactory carFactory = new CarFactory();
        IVehicle car = carFactory.CreateVehicle();
        car.Move();

        VehicleFactory busFactory = new BusFactory();
        IVehicle bus = busFactory.CreateVehicle();
        bus.Move();

        VehicleFactory bicycleFactory = new BicycleFactory();
        IVehicle bicycle = bicycleFactory.CreateVehicle();
        bicycle.Move();
    }
}