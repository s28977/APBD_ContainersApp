namespace APBD_ContainersApp;

public abstract class AbstractCargo
{
    public string Name { get; }

    public AbstractCargo(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"Name: {Name}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        if (obj.GetType() != GetType())
            return false;
        var cargo = (AbstractCargo) obj;
        return Name == cargo.Name;
    }
}