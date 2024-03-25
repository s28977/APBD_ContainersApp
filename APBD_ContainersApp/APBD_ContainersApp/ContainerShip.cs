using System.Text;

namespace APBD_ContainersApp;

public class ContainerShip
{
    public string Name { get; }
    private Dictionary<int, AbstractContainer> _containers;
    private int _weight;
    public int MaxSpeed { get; }
    public int MaxContainers { get; }
    public int MaxWeight { get; }

    public ContainerShip(string name, int maxSpeed, int maxContainers, int maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        _containers = new Dictionary<int, AbstractContainer>();
        _weight = 0;
    }

    public ContainerShip(string name) : this(name, 20, 10, 90){}

    public void Load(AbstractContainer container)
    {
        if (_weight + container.CargoMass + container.TareWeight > MaxWeight*1000)
        {
            throw new ArgumentException($"Cannot load the container. Weight of the ship would exceed maximum weight = {MaxWeight}.");
        }

        if (_containers.Count == MaxContainers)
        {
            throw new ArgumentException("Cannot load the container. There is no space left on the ship.");
        }
        _containers.Add(container.Id, container);
        Console.WriteLine($"Loaded container {container.Id} on {Name}");
    }
    public void Load(List<AbstractContainer> containers)
    {
        var containersMass = 0;
        foreach (var container in containers)
        {
            containersMass += container.CargoMass + container.TareWeight;
        }
        if (_weight + containersMass > MaxWeight*1000)
        {
            throw new ArgumentException($"Cannot load containers. Weight of the ship would exceed maximum weight = {MaxWeight}.");
        }
        if (_containers.Count + containers.Count > MaxContainers)
        {
            throw new ArgumentException("Cannot load containers. There is too little space left on the ship.");
        }
        foreach (var container in containers)
        {
            _containers.Add(container.Id, container);
        }

        StringBuilder stringBuilder = new StringBuilder();
        foreach (var container in containers)
        {
            stringBuilder.Append($"{container.Id}, ");
        }
        stringBuilder.Length--;
        stringBuilder.Length--;
        Console.WriteLine($"Loaded the containers {stringBuilder} on {Name}");
    }

    public void Remove(AbstractContainer container)
    {
        _containers.Remove(container.Id);
        Console.WriteLine($"Removed container {container.Id} from {Name}");
    }

    public void Replace(int id, AbstractContainer container)
    {
        Remove(_containers[id]);
        Load(container);
    }

    public void Transfer(AbstractContainer container, ContainerShip ship)
    {
        Remove(container);
        ship.Load(container);
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"Ship name: {Name}, maximum speed: {MaxSpeed} knots, maximum number of containers: {MaxContainers}," +
                             $" maximum weight of containers: {MaxWeight} tons")
            .AppendLine()
            .Append("Containers on the ship:")
            .AppendLine();
        foreach (var container in _containers)
        {
            stringBuilder.Append(container.Value).AppendLine();
        }
        
        return stringBuilder.ToString();
    }
}