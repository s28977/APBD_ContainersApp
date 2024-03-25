namespace APBD_ContainersApp;

public class RefrigeratedCargo : AbstractCargo
{
    public double MinTemperature { get; }
    public RefrigeratedCargo(string name, double minTemperature) : base(name)
    {
        MinTemperature = minTemperature;
    }

    public override string ToString()
    {
        return base.ToString() + $", minimal temperature: {MinTemperature} \u00B0C";
    }
}