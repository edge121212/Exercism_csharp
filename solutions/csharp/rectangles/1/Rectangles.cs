public static class Rectangles
{
    public static int Count(string[] rows)
    {
        if (rows == null || rows.Length == 0 || string.IsNullOrEmpty(rows[0])) {
            return 0;
        }
            
        int count = 0;
        int rowCount = rows.Length;
        int colCount = rows[0].Length;

        for (int r1 = 0; r1 < rowCount; r1++) {
            for (int c1 = 0; c1 < colCount; c1++) {
                if (rows[r1][c1] != '+') continue;
                    for (int c2 = c1 + 1; c2 < colCount; c2++) {
                        if (rows[r1][c2] != '+') {
                            if (rows[r1][c2] != '-' && rows[r1][c2] != '+') break;
                            continue;
                        }
                        for (int r2 = r1 + 1; r2 < rowCount; r2++) {
                            if (rows[r2][c1] != '|' && rows[r2][c1] != '+') break;
                            if (rows[r2][c2] != '|' && rows[r2][c2] != '+') break;
                            if (rows[r2][c1] == '+' && rows[r2][c2] == '+') {
                                bool isValidBottom = true;
                                for (int c = c1 + 1; c < c2; c++) {
                                    if (rows[r2][c] != '-' && rows[r2][c] != '+') {
                                        isValidBottom = false;
                                        break;
                                    }
                                }
                                if (isValidBottom) count++;
                            }
                        }
                    }
            }
        }
        return count;
    }
}