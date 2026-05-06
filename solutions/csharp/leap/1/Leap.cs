using System;


public static class Leap
{
    public static bool IsLeapYear(double year)
    {
        if (year % 4 != 0)
        {
            Console.WriteLine("Passed 1st");
            return false;
        }

        if (year % 4 == 0 && year % 100 == 0 && year % 400 == 0)
        {
            Console.WriteLine("Passed 3rd");
            return true;
        }

        if (year % 4 == 0 && year % 100 == 0)
        {
            Console.WriteLine("Passed 2nd");
            return false;
        }

        return true;
    }
}
