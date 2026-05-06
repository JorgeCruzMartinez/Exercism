using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
        => (!Convert.ToBoolean(year % 4) && (!Convert.ToBoolean(year % 400) || Convert.ToBoolean(year % 100)));
}