public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        var result = new List<(int, int, int)>();
        for (int a = 1; a <= sum; a++)
        {
            int numerator = sum * sum - 2 * sum * a;
            int denominator = 2 * sum - 2 * a;

            if (denominator == 0 || numerator % denominator != 0)
                continue;
            int b = numerator / denominator;
            int c = sum - a - b;

            if (a > 0 && b > 0 && c > 0 && a < b && (a * a + b * b == c * c))
            {
                result.Add((a, b, c));
            }
        }
        return result;
    }
}