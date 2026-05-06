static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        return speed switch
        {
            0 => 0,
            >= 1 and <= 4 => 1.0,
            >= 5 and <= 8 => 0.9,
            9 => 0.8,
            10 => 0.77,
            _ => throw new ArgumentOutOfRangeException(nameof(speed), "Valor no válido")
        };
    }

    public static double ProductionRatePerHour(int speed)
    {
        double rate = speed * 221;
        switch (speed)
        {
            case 0:
                return 0;
            case 9:
                return rate * 0.8;
            case 10:
                return rate * 0.77;
            default:
                if (speed > 0 && speed < 5)
                    return rate;
                else if (speed > 4 && speed < 9)
                    return rate * 0.9;
                else
                {
                    Console.WriteLine("Velocidad fuera de rango, usando valor por defecto.");
                    return -1;
                }
        }
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        double rate = speed * 221;
        switch (speed)
        {
            case 0:
                return 0;
            case 9:
                return (int)(rate * 0.8)/60;
            case 10:
                return (int)(rate * 0.77)/60;
            default:
                if (speed > 0 && speed < 5)
                    return (int)(rate/60);
                else if (speed > 4 && speed < 9)
                    return ((int)(rate * 0.9)/60);
                else
                {
                    Console.WriteLine("Velocidad fuera de rango, usando valor por defecto.");
                    return -1;
                }
        }
    }
}
