enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        // Convert the logLine to uppercase for case-insensitive comparison
        string logLevel = logLine.ToUpper();
        // Use switch to map the log level abbreviation to the corresponding enum
        return logLevel switch
        {
            var level when level.Contains("TRC") => LogLevel.Trace,
            var level when level.Contains("DBG") => LogLevel.Debug,
            var level when level.Contains("INF") => LogLevel.Info,
            var level when level.Contains("WRN") => LogLevel.Warning,
            var level when level.Contains("ERR") => LogLevel.Error,
            var level when level.Contains("FTL") => LogLevel.Fatal,
            _ => LogLevel.Unknown
        };
    }
    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        int encodedLevel = (int)logLevel;
        return $"{encodedLevel}:{message}";
    }
}