using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string[] arr = phoneNumber.Split("-");
        return (arr[0] == "212", arr[1] == "555", arr[2]);
    }
    
    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
    
    public static bool TryAnalyze(string? phoneNumber, out (bool IsNewYork, bool IsFake, string LocalNumber) result)
    {
        result = default;
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;
    
        var parts = phoneNumber.Split('-', StringSplitOptions.None);
        if (parts.Length != 3)
            return false;
    
        result = (parts[0] == "212", parts[1] == "555", parts[2]);
        return true;
    }
}