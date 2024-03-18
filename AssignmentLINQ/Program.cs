namespace AssignmentLINQ;

internal static class Program
{
    public static void Main(string[] args)
    {
        var laptopList = new List<Laptop>()
        {
            new("ASUS", 14, new Motherboard("ASUS", "Ryzen 7", 24, 512)),
            new("Lenovo", 15.3, new Motherboard("MSI", "Intel i7", 16, 256)),
            new("Apple", 16, new Motherboard("APPLE", "M3", 32, 1000)),
            new("Razer", 14, new Motherboard("ASUS", "Intel i9", 64, 2000)),
            new("ACER", 15.3, new Motherboard("ZOTAK", "Ryzen 5", 8, 512)),
            new("ASUS", 17, new Motherboard("ASUS", "Ryzen 5", 8, 256)),
            new("Lenovo", 15.3, new Motherboard("ZOTAK", "Ryzen 3", 8, 512)),
            new("ACER", 15, new Motherboard("MSI", "Ryzen 5", 8, 512)),
            new("Lenovo", 15.3, new Motherboard("ACER", "Ryzen 5", 16, 512)),
            new("ACER", 15.3, new Motherboard("MSI", "Ryzen 3", 8, 512)),
            new("ASUS", 13, new Motherboard("ASUS", "Intel 7", 16, 512)),
        };

        var delegateAndLinQ = new DelegateAndLinQ();

        // using delegate for passing method as object
        var searchedLaptopList =
            delegateAndLinQ.FindLaptopByCriteriaUsingDelegate(laptopList, laptop => laptop.Brand.Equals("ASUS"));

        // using anonymous method to search laptops
        DelegateAndLinQ.CompareLaptop ryzenCpuFilter = delegate(Laptop laptop)
        {
            return laptop.Motherboard.CPU.Contains("Ryzen", StringComparison.OrdinalIgnoreCase);
        };
        var ryzenCpuBasedLaptops = delegateAndLinQ.FindLaptopByCriteriaUsingDelegate(laptopList, ryzenCpuFilter);

        // using lambda expression and func
        DelegateAndLinQ.CompareLaptop msiMotherboardFilter = laptop =>
            laptop.Motherboard.Brand.Contains("MSI", StringComparison.OrdinalIgnoreCase);
        var msiMotherboardBasedLaptops =
            delegateAndLinQ.FindLaptopByCriteriaUsingDelegate(laptopList, msiMotherboardFilter);

        //using Func to pass comparator method
        var laptopsWithLessThan16Ram = delegateAndLinQ.FindLaptopByCriteriaUsingFunc(laptopList,
            (laptop) => laptop.Motherboard.RamCount < 16);

        //using extension method to get selling like title for laptop 
        Console.WriteLine(laptopList[0].GetLaptopSellingTitle());

        // using select and where on collection
        var asusLaptopsWithMoreThan8Ram = laptopList.Where(laptop =>
                laptop.Brand.Equals("ASUS", StringComparison.OrdinalIgnoreCase) && laptop.Motherboard.RamCount > 8)
            .Select(laptop => new
            {
                laptop.Motherboard.Brand, laptop.Motherboard.CPU, laptop.Motherboard.RamCount,
                laptop.Motherboard.SsdSize
            });
    }
}