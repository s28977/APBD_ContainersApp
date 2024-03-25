namespace APBD_ContainersApp;

public class RefrigeratedContainer : AbstractContainer<RefrigeratedCargo>
{
    public override string Type => "R";
    private int _temperature;

    public int Temperature
    {
        get => _temperature;
        set
        {
            if (Cargo == null || value >= Cargo.MinTemperature)
            {
                _temperature = value;
            } 
            else {
                Console.WriteLine("The temperature of the container cannot be lower then the minimal temperature " +
                                $"required by the cargo = {Cargo.MinTemperature}.");
                
            }
        }
    }

    public RefrigeratedContainer(int height, int tareWeight, int depth, int maxPayload) : base(height, tareWeight, depth, maxPayload)
    {
        _temperature = 20;
    }

    public override void Load(int mass, RefrigeratedCargo cargo)
    {
        if (_temperature < cargo.MinTemperature)
        {
            Console.WriteLine("The current temperature of the container is lower then the minimal temperature " +
                              $"required by the cargo = {cargo.MinTemperature}.");
            Console.WriteLine("Set higher container temperature before loading.");
        }
        else
        {
            base.Load(mass, cargo);
        }
    }
}