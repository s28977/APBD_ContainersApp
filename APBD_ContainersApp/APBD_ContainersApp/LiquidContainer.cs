namespace APBD_ContainersApp;

public class LiquidContainer : AbstractContainer, IHazardNotifier
{
    public override string Type => "L";

    public LiquidContainer(int height, int tareWeight, int depth, int maxPayload) : base(height, tareWeight, depth, maxPayload) {}
    public LiquidContainer() {}

    public override void Load(int mass, AbstractCargo cargo)
    {
        if (cargo.GetType() != typeof(LiquidCargo))
        {
            throw new ArgumentException("Liquid container can only load liquid cargo!");
        }
        var liquidCargo = (LiquidCargo)cargo;
        if (mass > 0.9*MaxPayload || (liquidCargo.IsHazardous && mass>0.5*MaxPayload))
        {
            SendHazardNotification();
        }
        base.Load(mass, cargo);
    }
    
    public void SendHazardNotification()
    {
        Console.WriteLine($"Hazardous situation detected in liquid container {Id}");
    }

}