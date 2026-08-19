public class Matrix
{
    private readonly int[][] _matrix;
    public Matrix(string input)
    {
        string[] rows = input.Split('\n');
        _matrix = new int[rows.Length][];
        
        for (int i = 0; i < rows.Length; i++) {
            string[] numberAsText = rows[i].Split(' ');
            _matrix[i] = new int[numberAsText.Length];
            for (int j = 0; j < numberAsText.Length; j++) {
                _matrix[i][j] = int.Parse(numberAsText[j]);
            }
        }
    }

    public int[] Row(int row)
    {
        return _matrix[row - 1];
    }

    public int[] Column(int col)
    {
        int[] result = new int[_matrix.Length];
        for (int i = 0; i < _matrix.Length; i++) {
            result[i] = _matrix[i][col - 1];
        }
        return result;
    }
}