using System.Linq;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        int sum = 0;
        for (int i = 1; i < max; i++)
        {
            foreach (int m in multiples)
            {
                // Handle zero multiples and check divisibility
                if (m != 0 && i % m == 0)
                {
                    sum += i;
                    break; // Move to the next 'i' to avoid double counting
                }
            }
        }
        return sum;
    }
}