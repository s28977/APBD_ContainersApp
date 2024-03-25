namespace APBD_ContainersApp;

public class LiquidCargo : AbstractCargo
{
    public bool IsHazardous { get; }
    public LiquidCargo(string name, bool isHazardous) : base(name)
    {
        IsHazardous = isHazardous;
    }
}