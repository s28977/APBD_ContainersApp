namespace APBD_ContainersApp;

public class RefrigeratedCargo : AbstractCargo
{
    public int MinTemperature { get; }
    public RefrigeratedCargo(string name, int minTemperature) : base(name)
    {
        MinTemperature = minTemperature;
    }

    public override string ToString()
    {
        return base.ToString() + $", minimal temperature: {MinTemperature} \u00B0C";
    }
}