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

    public void Load(int id)
    {
        var container = ContainersRepository.Containers[id];
        if (_weight + container.CargoMass + container.TareWeight > MaxWeight*1000)
        {
            throw new ArgumentException($"Cannot load the container. Weight of the ship would exceed maximum weight = {MaxWeight}.");
        }

        if (_containers.Count == MaxContainers)
        {
            throw new ArgumentException("Cannot load the container. There is no space left on the ship.");
        }
        _containers.Add(container.Id, container);
        Console.WriteLine($"Loaded container {id} on {Name}");
    }
    public void Load(List<int> ids)
    {
        var containers = new List<AbstractContainer>();
        foreach (var id in ids)
        {
            containers.Add(ContainersRepository.Containers[id]);
        }
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

        Console.WriteLine($"Loaded containers {string.Join(", ", ids)} on {Name}");
    }

    public void Remove(int id)
    {
        if (_containers.Remove(id))
        {
            Console.WriteLine($"Removed container {id} from {Name}");
        }
    }

    public void Replace(int id1, int id2)
    {
        Remove(id1);
        Load(id2);
    }

    public void Transfer(int id, ContainerShip ship)
    {
        Remove(id);
        ship.Load(id);
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