public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        if (size < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size cannot be negative.");
        }
        if (size == 0)
        {
            return new int[,] { }; // Return an empty array for size 0
        }

        int[,] matrix = new int[size, size];
        int value = 1;

        int topRow = 0;
        int bottomRow = size - 1;
        int leftCol = 0;
        int rightCol = size - 1;

        while (value <= size * size)
        {
            // Traverse Right
            for (int col = leftCol; col <= rightCol; col++)
            {
                matrix[topRow, col] = value++;
            }
            topRow++;

            // Traverse Down
            for (int row = topRow; row <= bottomRow; row++)
            {
                matrix[row, rightCol] = value++;
            }
            rightCol--;

            // Traverse Left
            if (topRow <= bottomRow) // Check to avoid filling twice in single-row/column cases
            {
                for (int col = rightCol; col >= leftCol; col--)
                {
                    matrix[bottomRow, col] = value++;
                }
                bottomRow--;
            }

            // Traverse Up
            if (leftCol <= rightCol) // Check to avoid filling twice in single-row/column cases
            {
                for (int row = bottomRow; row >= topRow; row--)
                {
                    matrix[row, leftCol] = value++;
                }
                leftCol++;
            }
        }

        return matrix;
    }
}