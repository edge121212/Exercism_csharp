using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var item in input)
        {
            if (item == null) 
            {
                continue;
            }
            if (item is IEnumerable nestedArray && !(item is string))
            {
                foreach (var subItem in Flatten(nestedArray))
                {
                    yield return subItem;
                }
            }
            else
            {
                yield return item;
            }
        }
    }
}