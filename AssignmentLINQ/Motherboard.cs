namespace AssignmentLINQ;

public class Motherboard
{
    public string Brand { get; init; }
    public string CPU { get; init; }
    public double RamCount { get; init; }
    public double SsdSize { get; init; }

    public Motherboard(string brand, string cpu, double ramCount, double ssdSize)
    {
        Brand = brand;
        CPU = cpu;
        RamCount = ramCount;
        SsdSize = ssdSize;
    }
}