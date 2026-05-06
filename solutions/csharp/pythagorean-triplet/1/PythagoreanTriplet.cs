public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    => Enumerable.Range(1, sum / 3)
    .SelectMany(i => Enumerable.Range(i + 1, sum / 2 - i).Where(j => i * i + j * j == (sum - i - j) * (sum - i - j)), (i, j) => (i, j, sum - i - j));
}