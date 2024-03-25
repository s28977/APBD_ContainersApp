namespace APBD_ContainersApp;

public class Program{
    public static void Main(string[] args)
    {
        var ship = new ContainerShip(20, 10, 1000);
        var liquidCargo = new LiquidCargo("Milk", false);
        var gasContainer = new GasContainer();
        var liquidContainer = new LiquidContainer();
        var refrigeratedContainer = new RefrigeratedContainer();
        ship.Load(gasContainer);
        Console.WriteLine(ship);
    }
}