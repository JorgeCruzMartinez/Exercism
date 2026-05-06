public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        // Formula for the sum of the first N natural numbers
        int sum = max * (max + 1) / 2;
        return sum * sum;
    }

    public static int CalculateSumOfSquares(int max)
    {
        // Formula for the sum of the squares of the first N natural numbers
        return max * (max + 1) * (2 * max + 1) / 6;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}