using System;
using System.Linq;
using System.Text;

public static class Transpose
{
    public static string String(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";

        string[] lines = input.Split('\n');
        int maxLen = lines.Max(l => l.Length);
        StringBuilder result = new StringBuilder();

        for (int c = 0; c < maxLen; c++)
        {
            StringBuilder currentRow = new StringBuilder();
            for (int r = 0; r < lines.Length; r++)
            {
                // 如果目前的行長度足以提供第 c 個字元
                if (c < lines[r].Length)
                {
                    currentRow.Append(lines[r][c]);
                }
                else
                {
                    // 關鍵判斷：如果下方的任何一行(r之後)長度大於 c
                    // 代表這格必須補空格來維持後續字元的對齊
                    if (lines.Skip(r).Any(l => l.Length > c))
                    {
                        currentRow.Append(' ');
                    }
                }
            }
            
            result.Append(currentRow.ToString());
            if (c < maxLen - 1) result.Append('\n');
        }

        return result.ToString();
    }
}