namespace APBD_ContainersApp;

public class GasContainer : AbstractContainer, IHazardNotifier
{
    public int Pressure { get; set; }
    public override string Type => "G";
    public GasContainer(int height, int tareWeight, int depth, int maxPayload) : base(height, tareWeight, depth, maxPayload)
    {
        Pressure = 1;
    }

    public GasContainer()
    {
        Pressure = 1;
    }

    public override void Empty()
    {
        CargoMass = (int)(CargoMass * 0.05);
    }

    public override void Load(int mass, AbstractCargo cargo)
    {
        if (cargo.GetType() != typeof(GasCargo))
        {
            throw new ArgumentException("Gas container can only load gas cargo!");
        }
        base.Load(mass, cargo);
    }

    public void SendHazardNotification()
    {
        Console.WriteLine($"Hazardous situation detected in gas container {Id}");
    }

    public override string ToString()
    {
        return base.ToString() + $", pressure: {Pressure} atm";
    }
}