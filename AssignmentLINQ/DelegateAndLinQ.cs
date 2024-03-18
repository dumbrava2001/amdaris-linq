namespace AssignmentLINQ;

public class DelegateAndLinQ
{
    public delegate bool CompareLaptop(Laptop laptop);

    public IEnumerable<Laptop> FindLaptopByCriteriaUsingDelegate(List<Laptop> laptopList, CompareLaptop compare)
    {
        var foundResults = new List<Laptop>();
        foreach (var laptop in laptopList)
        {
            if (compare(laptop))
            {
                foundResults.Add(laptop);
            }
        }

        return foundResults;
    }

    public IEnumerable<Laptop> FindLaptopByCriteriaUsingFunc(List<Laptop> laptops, Func<Laptop, bool> compare)
    {
        var foundResults = new List<Laptop>();
        foreach (var laptop in laptops)
        {
            if (compare(laptop))
            {
                foundResults.Add(laptop);
            }
        }

        return foundResults;
    }
}