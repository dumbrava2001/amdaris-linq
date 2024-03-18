namespace AssignmentLINQ;

public class Laptop
{
    public string Brand { get; init; }
    public double DisplaySize { get; init; }
    public Motherboard Motherboard { get; init; }

    public Laptop(string brand, double displaySize, Motherboard motherboard)
    {
        Brand = brand;
        DisplaySize = displaySize;
        Motherboard = motherboard;
    }
}