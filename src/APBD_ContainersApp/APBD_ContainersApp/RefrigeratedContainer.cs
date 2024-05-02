namespace APBD_ContainersApp;

public class RefrigeratedContainer : AbstractContainer
{
    public override string Type => "R";
    private double _temperature;

    public double Temperature
    {
        get => _temperature;
        set
        {
            if (Cargo == null || value >= ((RefrigeratedCargo)Cargo).MinTemperature)
            {
                _temperature = value;
            } 
            else {
                throw new ArgumentException("The temperature of the container cannot be lower then the minimal temperature " +
                                            $"required by the cargo = {((RefrigeratedCargo)Cargo).MinTemperature} \u00B0C.");
                
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

    public override bool Load(AbstractCargo cargo, int mass)
    {
        if (cargo.GetType() != typeof(RefrigeratedCargo))
        {
            throw new ArgumentException("Refrigerated container can only load refrigerated cargo!");
        }
        if(!IsEmpty && !cargo.Equals(Cargo))
            throw new ArgumentException("Container already has some other type of cargo inside.");
        if (_temperature < ((RefrigeratedCargo)cargo).MinTemperature)
        {
            throw new ArgumentException("The current temperature of the container is lower then the minimal temperature " +
                                        $"required by the cargo = {((RefrigeratedCargo)cargo).MinTemperature} \u00B0C.");
        }
        if (mass + CargoMass > MaxPayload)
        {
            throw new OverfillException($"Cargo mass cannot be greater then maximum payload of the container = {MaxPayload}");
        }
        CargoMass += mass;
        Cargo = cargo;
        IsEmpty = false;
        Console.WriteLine($"Loaded {mass} kg of {cargo.Name} into container {Id}");
        return true;
    }

    public override string ToString()
    {
        return base.ToString() + $", temperature: {_temperature} \u00B0C";
    }
}