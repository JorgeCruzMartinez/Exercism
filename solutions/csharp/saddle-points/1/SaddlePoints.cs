public static class SaddlePoints
{
    public static IEnumerable<(int row, int column)> Calculate(int[,] matrix)
{
    int rowCount = matrix.GetLength(0);
    int colCount = matrix.GetLength(1);
    for (int i = 0; i < rowCount; i++)
    {
        for (int j = 0; j < colCount; j++)
        {
            int currentValue = matrix[i, j];
            bool isMaxInRow = true;
            for (int k = 0; k < colCount; k++)
            {
                if (matrix[i, k] > currentValue)
                {
                    isMaxInRow = false;
                    break;
                }
            }
            bool isMinInColumn = true;
            for (int k = 0; k < rowCount; k++)
            {
                if (matrix[k, j] < currentValue)
                {
                    isMinInColumn = false;
                    break;
                }
            }
            if (isMaxInRow && isMinInColumn)
            {
                yield return (i + 1, j + 1); // Convert to 1-based index
            }
        }
    }
}
}
