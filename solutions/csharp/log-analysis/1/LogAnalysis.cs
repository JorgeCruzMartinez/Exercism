public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delimitation) => str.Split(delimitation)[1];

    public static string SubstringBetween(this string str, string firstDelimitation, string secondDelimitation) => str.Split(firstDelimitation)[1].Split(secondDelimitation)[0];
    
    public static string Message(this string str) => str.SubstringAfter(": ");
    
    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}