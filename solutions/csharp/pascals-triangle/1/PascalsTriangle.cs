using System;
using System.Collections.Generic;
public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var triangle = new List<List<int>>();
        if (rows <= 0){
            return triangle;
        }

        for (int i = 0; i < rows; i++){
            var currentRow = new List<int>();
            for (int j = 0; j <= i; j++){
                if (j == 0 || j == i){
                    currentRow.Add(1);
                }
                else {
                    int leftValue = triangle[i - 1][j - 1];
                    int rightValue = triangle[i - 1][j];
                    currentRow.Add(leftValue + rightValue);
                }
            }
            triangle.Add(currentRow);
        }
        return triangle;
    }

}