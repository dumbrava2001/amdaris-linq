namespace AssignmentLINQ;

public static class LaptopExtension
{
    public static string GetLaptopSellingTitle(this Laptop laptop)
    {
        return
            $"{laptop.Brand}, {laptop.Motherboard.CPU}: RAM-{laptop.Motherboard.RamCount}GB;SSD-{laptop.Motherboard.SsdSize}GB";
    }
}