using System.Text.RegularExpressions;

public static class Markdown
{
    private static string WrapTag(string text, string tag) => $"<{tag}>{text}</{tag}>";
    private static string ParseInlineFormatting(string markdown)
    {
        markdown = Regex.Replace(markdown, @"__(.+?)__", m => WrapTag(m.Groups[1].Value, "strong"));
        markdown = Regex.Replace(markdown, @"_(.+?)_", m => WrapTag(m.Groups[1].Value, "em"));
    
        return markdown;
    }
    public static string Parse(string markdown)
    {
        var lines = markdown.Split('\n');
        var result = new System.Text.StringBuilder();
        var isInList = false;
        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (IsHeader(trimmedLine, out int headerLevel))
            {
                if (isInList)
                {
                    result.Append("</ul>");
                    isInList = false;
                }
    
                result.Append(WrapTag(ParseInlineFormatting(trimmedLine.Substring(headerLevel).Trim()), $"h{headerLevel}"));
                continue;
            }
            if (IsListItem(trimmedLine))
            {
                if (!isInList)
                {
                    result.Append("<ul>");
                    isInList = true;
                }
                result.Append(WrapTag(
                    ParseInlineFormatting(trimmedLine.Substring(1).Trim()),
                    "li"
                ));
                continue;
            }
            if (!string.IsNullOrWhiteSpace(trimmedLine))
            {
                if (isInList)
                {
                    result.Append("</ul>");
                    isInList = false;
                }
                result.Append(WrapTag(ParseInlineFormatting(trimmedLine), "p"));
            }
        }
        if (isInList)
        {
            result.Append("</ul>");
        }
        return result.ToString();
    }
    private static bool IsHeader(string line, out int headerLevel)
    {
        headerLevel = 0;
    
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '#')
                headerLevel++;
            else
                break;
        }
        return headerLevel > 0 && headerLevel <= 6;
    }
    private static bool IsListItem(string line) => line.TrimStart().StartsWith("*");
}