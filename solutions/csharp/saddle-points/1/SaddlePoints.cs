public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var result = new List<(int, int)>();
        
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                var row = Enumerable.Range(0, matrix.GetLength(1))
                                    .Select(col => matrix[r, col]);
                int rowMax = row.Max();

                int colMin = Enumerable.Range(0, matrix.GetLength(0))
                                       .Select(row => matrix[row, c])
                                       .Min();
                if (matrix[r, c] == rowMax && matrix[r, c] == colMin)
                {
                    result.Add((r+1, c+1));
                }
            }
        }
        return result;
    }
}
