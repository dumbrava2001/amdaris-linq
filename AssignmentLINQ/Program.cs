namespace AssignmentLINQ;

internal static class Program
{
    public static void Main(string[] args)
    {
        var laptopList = GetLaptopList();

        var delegateAndLinQ = new DelegateAndLinQ();

        // using delegate for passing method as object
        SearchLaptopUsingParsedDelegate(delegateAndLinQ, laptopList);

        // using anonymous method to search laptops
        Console.WriteLine("\nSearch laptops using anonymous method delegate");
        SearchLaptopUsingAnonymousMethodDelegate(delegateAndLinQ, laptopList);

        // using lambda expression
        Console.WriteLine("\nSearch laptops using lambda expression");
        SearchLaptopUsingLambdaExpression(delegateAndLinQ, laptopList);

        //using Func to pass comparator method
        Console.WriteLine("\nSearch laptops using Func");
        SearchLaptopUsingFunc(delegateAndLinQ, laptopList);

        //using extension method to get selling like title for laptop 
        Console.WriteLine("\nUsing extension method");
        Console.WriteLine(laptopList[0].GetLaptopSellingTitle());

        // using select and where on collection
        Console.WriteLine("\nSearch laptops where and select operators");
        SearchLaptopsUsingWhereAndSelectOperators(laptopList);
    }

    private static void SearchLaptopsUsingWhereAndSelectOperators(List<Laptop> laptopList)
    {
        var asusLaptopsWithMoreThan8Ram = laptopList.Where(laptop =>
                laptop.Brand.Equals("ASUS", StringComparison.OrdinalIgnoreCase) && laptop.Motherboard.RamCount > 8)
            .Select(laptop => new
            {
                laptop.Motherboard.Brand, laptop.Motherboard.CPU, laptop.Motherboard.RamCount,
                laptop.Motherboard.SsdSize
            });

        foreach (var laptop in asusLaptopsWithMoreThan8Ram)
        {
            Console.WriteLine($"{laptop.Brand}, {laptop.CPU}, Ram:{laptop.RamCount}, SSD:{laptop.SsdSize}");
        }
    }

    private static void SearchLaptopUsingFunc(DelegateAndLinQ delegateAndLinQ, List<Laptop> laptopList)
    {
        var laptopsWithLessThan16Ram = delegateAndLinQ.FindLaptopByCriteriaUsingFunc(laptopList,
            (laptop) => laptop.Motherboard.RamCount < 16);

        DisplayList(laptopsWithLessThan16Ram);
    }

    private static void SearchLaptopUsingLambdaExpression(DelegateAndLinQ delegateAndLinQ, List<Laptop> laptopList)
    {
        DelegateAndLinQ.CompareLaptop msiMotherboardFilter = laptop =>
            laptop.Motherboard.Brand.Contains("MSI", StringComparison.OrdinalIgnoreCase);
        var msiMotherboardBasedLaptops =
            delegateAndLinQ.FindLaptopByCriteriaUsingDelegate(laptopList, msiMotherboardFilter);

        DisplayList(msiMotherboardBasedLaptops);
    }

    private static void SearchLaptopUsingAnonymousMethodDelegate(DelegateAndLinQ delegateAndLinQ,
        List<Laptop> laptopList)
    {
        DelegateAndLinQ.CompareLaptop ryzenCpuFilter = delegate(Laptop laptop)
        {
            return laptop.Motherboard.CPU.Contains("Ryzen", StringComparison.OrdinalIgnoreCase);
        };
        var ryzenCpuBasedLaptops = delegateAndLinQ.FindLaptopByCriteriaUsingDelegate(laptopList, ryzenCpuFilter);

        DisplayList(ryzenCpuBasedLaptops);
    }

    private static void SearchLaptopUsingParsedDelegate(DelegateAndLinQ delegateAndLinQ, List<Laptop> laptopList)
    {
        var searchedLaptopList =
            delegateAndLinQ.FindLaptopByCriteriaUsingDelegate(laptopList, laptop => laptop.Brand.Equals("ASUS"));
        DisplayList(searchedLaptopList);
    }

    private static void DisplayList(IEnumerable<Laptop> laptopList)
    {
        foreach (var laptop in laptopList)
        {
            Console.WriteLine(
                $"Laptop:{laptop.Brand}, {laptop.DisplaySize} inch\nMotherboard:{laptop.Motherboard.Brand}, {laptop.Motherboard.CPU}, Ram:{laptop.Motherboard.RamCount}, SSD:{laptop.Motherboard.SsdSize}");
        }
    }

    private static List<Laptop> GetLaptopList()
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
        return laptopList;
    }
}