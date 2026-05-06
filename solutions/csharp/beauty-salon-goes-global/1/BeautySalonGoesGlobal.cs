using System;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => TimeZoneInfo.ConvertTime(dtUtc, TimeZoneInfo.Utc, TimeZoneInfo.Local);

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime appDateTimeLocal = DateTime.Parse(appointmentDateDescription);

        return TimeZoneInfo.ConvertTimeToUtc(appDateTimeLocal, TimeZoneInfo.FindSystemTimeZoneById(GetLocationTimeZoneInfoName(location)));
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) => appointment - GetTimeSpanFromAlertLevel(alertLevel);

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        DateTime dtUtc = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.FindSystemTimeZoneById(GetLocationTimeZoneInfoName(location)), TimeZoneInfo.Utc);

        DateTime winterSpecialDay = new DateTime(dtUtc.Year, 12, 22, 0, 0, 0, DateTimeKind.Utc);

        return dtUtc <= winterSpecialDay.AddDays(-7);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        try
        {
            return Convert.ToDateTime(dtStr, CultureInfo.GetCultureInfo(GetCultureCode(location)));
        }
        catch
        {
            return new DateTime(1, 1, 1);
        }
    }

    public static string GetLocationTimeZoneInfoName(Location location)
    {
        return location switch
        {
            Location.NewYork => "Eastern Standard Time",
            Location.London => "GMT Standard Time",
            Location.Paris => "W. Europe Standard Time",
            _ => string.Empty,
        };
    }

    public static string GetCultureCode(Location location)
    {
        return location switch
        {
            Location.NewYork => "en-US",
            Location.London => "en-GB",
            Location.Paris => "fr-FR",
            _ => string.Empty,
        };
    }

    public static TimeSpan GetTimeSpanFromAlertLevel(AlertLevel level)
    {
        return level switch
        {
            AlertLevel.Early => new TimeSpan(1, 0, 0, 0, 0),
            AlertLevel.Standard => new TimeSpan(1, 45, 0),
            AlertLevel.Late => new TimeSpan(0, 30, 0),
            _ => new TimeSpan()
        };
    }
}