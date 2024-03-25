namespace APBD_ContainersApp;

public class Program{
    public static void Main(string[] args)
    {
        
        // liquid container tests
        var liquidContainer = new LiquidContainer();
        var milk = new LiquidCargo("Milk", false);
        var fuel = new LiquidCargo("Fuel", true);
        var gas = new GasCargo("O2");
        // liquidContainer.Load(gas, 5000); // Exception is thrown as expected
        // liquidContainer.Load(milk, 9000); // Exception is thrown as expected
        // liquidContainer.Load(fuel, 6000); // Exception is thrown as expected
        liquidContainer.Load(milk,7000);
        liquidContainer.Empty();
        liquidContainer.Load(fuel, 4000);
        Console.WriteLine(liquidContainer);
        liquidContainer.Empty();
        
        //gas container tests
        var gasContainer = new GasContainer();
        // gasContainer.Load(gas, 12000); // Exception is thrown as expected
        gasContainer.Load(gas, 8000);
        gasContainer.Empty();
        Console.WriteLine(gasContainer);
        
        //Refrigerated container tests
        var refrigeratedContainer = new RefrigeratedContainer();
        var banana = new RefrigeratedCargo("Bananas", 13);
        // refrigeratedContainer.Temperature = 5;
        // refrigeratedContainer.Load(banana, 5000); // Exception is thrown as expected
        refrigeratedContainer.Load(banana, 5000);
        Console.WriteLine(refrigeratedContainer);
        refrigeratedContainer.Empty();
        
        //Ship tests
        var bigShip = new ContainerShip("Big");
        var smallShip = new ContainerShip("Small",20, 1, 5);
        gasContainer.Load(gas, 5000);
        // smallShip.Load(gasContainer); // Exception is thrown as expected
        gasContainer.Empty(); 
        smallShip.Load(gasContainer);
        // smallShip.Load(liquidContainer); // Exception is thrown as expected
        liquidContainer.Load(fuel, 4000);
        refrigeratedContainer.Load(banana, 8000);
        var containers = new List<AbstractContainer>(){liquidContainer, refrigeratedContainer };
        bigShip.Load(containers);
        Console.WriteLine(bigShip);
        bigShip.Remove(refrigeratedContainer);
        Console.WriteLine(bigShip);
        bigShip.Replace(1, refrigeratedContainer);
        smallShip.Transfer(gasContainer, bigShip);
    }
}