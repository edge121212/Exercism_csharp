public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var box = new List<T>();
        foreach (T element in collection) 
        {
            if (predicate(element))
            {
                box.Add(element);
            }
        }
        return box;
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var box = new List<T>();
        foreach (T element in collection) 
        {
            if (!predicate(element))
            {
                box.Add(element);
            }
        }
        return box;
    }
}