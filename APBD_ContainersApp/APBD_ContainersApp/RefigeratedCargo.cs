namespace APBD_ContainersApp;

public class RefrigeratedCargo : AbstractCargo
{
    public int MinTemperature { get; }
    public RefrigeratedCargo(string name, int minTemperature) : base(name)
    {
        MinTemperature = minTemperature;
    }
}