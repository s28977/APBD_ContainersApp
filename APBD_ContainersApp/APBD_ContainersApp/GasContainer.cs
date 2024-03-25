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

    public override bool Empty()
    {
        if (IsEmpty) 
            return false;
        CargoMass = (int)(CargoMass * 0.05);
        Console.WriteLine($"Emptied container {Id}");
        IsEmpty = true;
        return true;
    }

    public override bool Load(AbstractCargo cargo, int mass)
    {
        if (cargo.GetType() != typeof(GasCargo))
        {
            throw new ArgumentException("Gas container can only load gas cargo!");
        }
        return base.Load(cargo, mass);
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