using System.Text.RegularExpressions;

public static class Grep
{
    private class Line(int lineNumber, string text, Match match)
    {
        public readonly bool Matches = match.Success;
        public readonly string Text = text;
        public readonly int LineNumber = lineNumber;
    }
    
    [Flags]
    private enum Flags
    {
        Default = 0,
        PrependLineNumber = 1, // -n
        OnlyFilenames = 2, // -l
        CaseInsensitive = 4, // -i
        Invert = 8, // -v
        EntireLineMatch = 16, // -x
    }
    
    private static Flags ToFlag(string flag) =>
        flag switch
        {
            "-n" => Flags.PrependLineNumber,
            "-l" => Flags.OnlyFilenames,
            "-i" => Flags.CaseInsensitive,
            "-x" => Flags.EntireLineMatch,
            "-v" => Flags.Invert,
            _ => Flags.Default
        };
    
    public static string Match(string searchQuery, string flags, string[] files)
    {
        var result = new List<string>();
        var parsedFlag = flags.Split(' ').Select(ToFlag).Aggregate((a, b) => a | b);
        foreach (var file in files)
        {
            var content = File.ReadLines(file).ToArray();
            var regexPattern = GetSearchRegex();
            var matchingLines = content.Select((line, index) => new Line(index + 1, line, regexPattern.Match(line)))
                .Where(x => x.Matches != parsedFlag.HasFlag(Flags.Invert))
                .ToList();
    
            result.AddRange(matchingLines.Select(matchingLine => !parsedFlag.HasFlag(Flags.OnlyFilenames)
                ? OutputLine(matchingLine, file, lineNumber: (parsedFlag.HasFlag(Flags.PrependLineNumber)))
                : file).Distinct());
        }
        return string.Join(Environment.NewLine, result);
    
        string OutputLine(Line line, string file, bool lineNumber = false)
        {
            return ((files.Length, lineNumber)) switch
            {
                (1, false) => line.Text,
                (1, true) => $"{line.LineNumber}:{line.Text}",
                (_, false) => $"{file}:{line.Text}",
                (_, true) => $"{file}:{line.LineNumber}:{line.Text}",
            };
        }
    
        Regex GetSearchRegex()
        {
            var pattern = parsedFlag.HasFlag(Flags.EntireLineMatch) ? $"^{searchQuery}$" : $"{searchQuery}";
            var regexPattern = new Regex(pattern,
                parsedFlag.HasFlag(Flags.CaseInsensitive)
                    ? RegexOptions.CultureInvariant | RegexOptions.IgnoreCase
                    : RegexOptions.CultureInvariant);
    
            return regexPattern;
        }
    }
}