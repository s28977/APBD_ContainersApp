using System.Text;

namespace APBD_ContainersApp;

public class ContainerShip
{
    private Dictionary<int, AbstractContainer> _containers;
    private int _weight;
    public int MaxSpeed { get; }
    public int MaxContainers { get; }
    public int MaxWeight { get; }

    public ContainerShip(int maxSpeed, int maxContainers, int maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        _containers = new Dictionary<int, AbstractContainer>();
        _weight = 0;
    }

    public bool Load(AbstractContainer container)
    {
        if (_weight + container.CargoMass + container.TareWeight > MaxWeight*1000)
        {
            Console.WriteLine($"Cannot load the container. Weight of the ship would exceed maximum weight = {MaxWeight}.");
            return false;
        }

        if (_containers.Count == MaxContainers)
        {
            Console.WriteLine("Cannot load the container. There is no space left on the ship.");
            return false;
        }
        _containers.Add(container.Id, container);
        return true;
    }
    public bool Load(List<AbstractContainer> containers)
    {
        var containersMass = 0;
        foreach (var container in containers)
        {
            containersMass += container.CargoMass + container.TareWeight;
        }
        if (_weight + containersMass > MaxWeight*1000)
        {
            Console.WriteLine($"Cannot load containers. Weight of the ship would exceed maximum weight = {MaxWeight}.");
            return false;
        }
        if (_containers.Count + containers.Count > MaxContainers)
        {
            Console.WriteLine("Cannot load containers. There is too little space left on the ship.");
            return false;
        }
        foreach (var container in containers)
        {
            _containers.Add(container.Id, container);
        }
        return true;
    }

    public void Remove(int id)
    {
        _containers.Remove(id);
    }

    public void Replace(int id, AbstractContainer container)
    {
        Remove(id);
        Load(container);
    }

    public void Transfer(int id, ContainerShip ship)
    {
        if (ship.Load(_containers[id]))
        {
            Remove(id);
        }
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"Maximum speed: {MaxSpeed} knots, maximum number of containers: {MaxContainers}," +
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