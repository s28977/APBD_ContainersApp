namespace APBD_ContainersApp;

public abstract class AbstractContainer
{
    private static int _id = 1;
    public int Id { get;  }
    public int Height { get; }
    public int TareWeight { get; }
    public int Depth { get; }
    public int MaxPayload { get; }
    public abstract string Type { get; }
    private int _cargoMass;

    public int CargoMass
    {
        get => _cargoMass;
        protected set => _cargoMass = value; 
    }

    private AbstractCargo? _cargo;

    public AbstractCargo? Cargo
    {
        get => _cargo;
        protected set => _cargo = value;
    }
    public string Serial => $"KON-{Type}-{Id}";

    public AbstractContainer(int height, int tareWeight, int depth, int maxPayload)
    {
        _cargoMass = 0;
        Id = _id++;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;
    }

    public AbstractContainer() : this(200, 1000, 500, 10000){}
    
    
    public virtual void Empty()
    {
        _cargoMass = 0;
        _cargo = null;
    }

   public virtual void Load(int mass, AbstractCargo cargo) 
   {
       if (mass > MaxPayload)
       {
           throw new OverfillException($"Cargo mass cannot be greater then maximum payload = {MaxPayload}");
       }
       _cargoMass = mass;
       _cargo = cargo;
   }

   public override string ToString()
   {
       return $"Serial: {Serial}, height: {Height} cm, depth: {Depth} cm, tare weight: {TareWeight} kg, max payload: {MaxPayload} kg, " +
              $"cargo: ({_cargo}), cargo mass: {_cargoMass} kg";
   }
}