public static class Darts
{
    public static int Score(double x, double y)
    {
        double distance = Math.Sqrt(x * x + y * y);

        return distance switch
        {
            <= 1.0 => 10, // Bullseye
            <= 5.0 => 5,  // Inner ring
            <= 10.0 => 1, // Outer ring
            _ => 0         // Missed the board
        };
    }
}
