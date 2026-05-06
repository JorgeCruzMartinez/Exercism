static class LogLine
{
    public static string Message(string logLine)
    {           
        int pos = logLine.IndexOf(":");        
        return logLine.Substring(pos + 1).Trim();
    }

    public static string LogLevel(string logLine)
    {        
        int inicio = logLine.IndexOf('[') + 1;
        int fin = logLine.IndexOf(']');
        string message = logLine.Substring(inicio, fin - inicio);
        return message.ToLower();
    }

    public static string Reformat(string logLine)
    {    
        int pos = logLine.IndexOf(":");        
        string message = logLine.Substring(pos + 1).Trim();
        int inicio = logLine.IndexOf('[') + 1;
        int fin = logLine.IndexOf(']');
        string level = logLine.Substring(inicio, fin - inicio);        
        return $"{message} ({level.ToLower()})";
    }
}
