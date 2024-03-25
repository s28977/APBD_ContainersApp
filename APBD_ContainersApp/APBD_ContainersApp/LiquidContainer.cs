namespace APBD_ContainersApp;

public class LiquidContainer : AbstractContainer, IHazardNotifier
{
    public override string Type => "L";

    public LiquidContainer(int height, int tareWeight, int depth, int maxPayload) : base(height, tareWeight, depth, maxPayload) {}
    public LiquidContainer() {}

    public override void Load(AbstractCargo cargo, int mass)
    {
        if (cargo.GetType() != typeof(LiquidCargo))
        {
            throw new ArgumentException("Liquid container can only load liquid cargo!");
        }
        var liquidCargo = (LiquidCargo)cargo;
        if (!liquidCargo.IsHazardous && mass > 0.9*MaxPayload)
        {
            SendHazardNotification($"Load unsuccessful. Liquid cargo exceeds 90% of container capacity = {MaxPayload}");
            throw new HazardException();
        }

        if (liquidCargo.IsHazardous && mass > 0.5 * MaxPayload)
        {
            SendHazardNotification($"Load unsuccessful. Hazardous liquid cargo exceeds 50% of container capacity = {MaxPayload}");
            throw new HazardException();
        }
        base.Load(cargo, mass);
    }
    
    public void SendHazardNotification(string msg)
    {
        Console.WriteLine($"Hazardous situation detected in liquid container {Id}");
        Console.WriteLine(msg);
    }

}