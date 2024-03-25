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
        
        //container loading different products tests
        refrigeratedContainer.Load(banana, 3000);
        // refrigeratedContainer.Load(banana, 3000); // Exception is thrown as expected
        // refrigeratedContainer.Load(new RefrigeratedCargo("Apples", 15), 1000); // Exception is thrown as expected
        refrigeratedContainer.Empty();
        
        //Ship tests
        Console.WriteLine(string.Join("\n", ContainersRepository.Containers));
        var bigShip = new ContainerShip("Big");
        var smallShip = new ContainerShip("Small",20, 1, 5);
        gasContainer.Load(gas, 5000);
        // smallShip.Load(2); // Exception is thrown as expected
        gasContainer.Empty(); 
        smallShip.Load(2);
        // smallShip.Load(1); // Exception is thrown as expected
        liquidContainer.Load(fuel, 4000);
        refrigeratedContainer.Load(banana, 8000);
        var containers = new List<int>(){1, 3};
        bigShip.Load(containers);
        Console.WriteLine(bigShip);
        bigShip.Remove(3);
        Console.WriteLine(bigShip);
        bigShip.Replace(1, 3);
        smallShip.Transfer(2, bigShip);
    }
}