namespace BookExampleImproved.Models;

public class Publisher
{
    public string Name { get; private set; }

    public Publisher(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        this.Name = name;
    }
}