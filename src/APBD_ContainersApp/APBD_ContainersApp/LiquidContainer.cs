namespace APBD_ContainersApp;

public class LiquidContainer : AbstractContainer, IHazardNotifier
{
    public override string Type => "L";

    public LiquidContainer(int height, int tareWeight, int depth, int maxPayload) : base(height, tareWeight, depth, maxPayload) {}
    public LiquidContainer() {}

    public override bool Load(AbstractCargo cargo, int mass)
    {
        if (cargo.GetType() != typeof(LiquidCargo))
        {
            throw new ArgumentException("Liquid container can only load liquid cargo!");
        }
        if(!IsEmpty && !cargo.Equals(Cargo))
            throw new ArgumentException("Container already has some other type of cargo inside.");
        var liquidCargo = (LiquidCargo)cargo;
        switch (liquidCargo.IsHazardous)
        {
            case false when mass + CargoMass > 0.9 * MaxPayload:
                SendHazardNotification($"Load unsuccessful. Liquid cargo exceeds 90% of container capacity = {MaxPayload}");
                throw new HazardException();
            case true when mass + CargoMass> 0.5 * MaxPayload:
                SendHazardNotification($"Load unsuccessful. Hazardous liquid cargo exceeds 50% of container capacity = {MaxPayload}");
                throw new HazardException();
        }
        CargoMass += mass;
        Cargo = cargo;
        IsEmpty = false;
        Console.WriteLine($"Loaded {mass} kg of {cargo.Name} into container {Id}");
        return true;
    }
    
    public void SendHazardNotification(string msg)
    {
        Console.WriteLine($"Hazardous situation detected in liquid container {Id}");
        Console.WriteLine(msg);
    }

}