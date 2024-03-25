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
        var mass = (int)(CargoMass * 0.05);
        var cargo = Cargo;
        base.Empty();
        CargoMass = mass;
        Cargo = cargo;

    }

    public override void Load(AbstractCargo cargo, int mass)
    {
        if (cargo.GetType() != typeof(GasCargo))
        {
            throw new ArgumentException("Gas container can only load gas cargo!");
        }
        base.Load(cargo, mass);
    }

    public void SendHazardNotification(string msg)
    {
        Console.WriteLine($"Hazardous situation detected in gas container {Id}");
        Console.WriteLine(msg);
    }

    public override string ToString()
    {
        return base.ToString() + $", pressure: {Pressure} atm";
    }
}