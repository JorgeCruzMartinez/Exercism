public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be a positive integer.");            

        int steps = 0;
        long currentNumber = number; // Use long to prevent potential overflow for large inputs

        while (currentNumber != 1)
        {
            if (currentNumber % 2 == 0)                
                currentNumber /= 2;                
            else                
                currentNumber = currentNumber * 3 + 1;
            
            steps++;
        }
        return steps;
    }
}