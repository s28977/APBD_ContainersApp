namespace APBD_ContainersApp;

public class RefrigeratedCargo : AbstractCargo
{
    public double MinTemperature { get; }
    public RefrigeratedCargo(string name, double minTemperature) : base(name)
    {
        MinTemperature = minTemperature;
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj))
            return false;
        var cargo = (RefrigeratedCargo)obj;
        return MinTemperature == cargo.MinTemperature;
    }

    public override string ToString()
    {
        return base.ToString() + $", minimal temperature: {MinTemperature} \u00B0C";
    }
    
    
}