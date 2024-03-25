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

    public override void Load(AbstractCargo cargo, int mass)
    {
        if (cargo.GetType() != typeof(RefrigeratedCargo))
        {
            throw new ArgumentException("Refrigerated container can only load refrigerated cargo!");
        }
        if (_temperature < ((RefrigeratedCargo)cargo).MinTemperature)
        {
            throw new ArgumentException("The current temperature of the container is lower then the minimal temperature " +
                                        $"required by the cargo = {((RefrigeratedCargo)cargo).MinTemperature} \u00B0C.");
        }
        base.Load(cargo, mass);
    }

    public override string ToString()
    {
        return base.ToString() + $", temperature: {_temperature} \u00B0C";
    }
}