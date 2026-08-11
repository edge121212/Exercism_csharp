public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        return Enumerable.Range(1, max - 1)
                         .Where(x => multiples.Any(m => m != 0 && x % m == 0))
                         .Sum();
    }
}