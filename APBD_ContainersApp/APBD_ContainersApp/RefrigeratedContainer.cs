namespace APBD_ContainersApp;

public class RefrigeratedContainer : AbstractContainer
{
    public override string Type => "R";
    private int _temperature;

    public int Temperature
    {
        get => _temperature;
        set
        {
            if (Cargo == null || value >= ((RefrigeratedCargo)Cargo).MinTemperature)
            {
                _temperature = value;
            } 
            else {
                Console.WriteLine("The temperature of the container cannot be lower then the minimal temperature " +
                                $"required by the cargo = {((RefrigeratedCargo)Cargo).MinTemperature}.");
                
            }
        }
    }

    public RefrigeratedContainer(int height, int tareWeight, int depth, int maxPayload) : base(height, tareWeight, depth, maxPayload)
    {
        _temperature = 20;
    }

    public RefrigeratedContainer()
    {
        _temperature = 20;
    }

    public override void Load(int mass, AbstractCargo cargo)
    {
        if (cargo.GetType() != typeof(RefrigeratedCargo))
        {
            throw new ArgumentException("Refrigerated container can only load refrigerated cargo!");
        }
        if (_temperature < ((RefrigeratedCargo)cargo).MinTemperature)
        {
            Console.WriteLine("The current temperature of the container is lower then the minimal temperature " +
                              $"required by the cargo = {((RefrigeratedCargo)cargo).MinTemperature}.");
            Console.WriteLine("Set higher container temperature before loading.");
        }
        else
        {
            base.Load(mass, cargo);
        }
    }

    public override string ToString()
    {
        return base.ToString() + $", temperature: {_temperature} \u00B0C";
    }
}