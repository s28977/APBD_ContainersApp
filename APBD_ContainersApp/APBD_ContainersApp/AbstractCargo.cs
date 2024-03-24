namespace APBD_ContainersApp;

public abstract class AbstractCargo
{
    public string Name { get; }

    public AbstractCargo(string name)
    {
        Name = name;
    }
}