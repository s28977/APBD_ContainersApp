namespace APBD_ContainersApp;

public class LiquidContainer : AbstractContainer<LiquidCargo>, IHazardNotifier
{
    public override string Type => "L";

    public LiquidContainer(int height, int tareWeight, int depth, int maxPayload) : base(height, tareWeight, depth, maxPayload) {}
    public LiquidContainer() {}

    public override void Load(int mass, LiquidCargo cargo)
    {
        if (mass > 0.9*MaxPayload || (cargo.IsHazardous && mass>0.5*MaxPayload))
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