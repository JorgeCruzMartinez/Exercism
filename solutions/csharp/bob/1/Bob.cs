public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement.Trim();
        if (statement.Length == 0)
            return "Fine. Be that way!";

        bool isQuestion = statement.EndsWith('?');
        bool isYelling = statement.Any(char.IsLetter) && 
		statement.Where(char.IsLetter).All(char.IsUpper);

        if (isQuestion && isYelling) return "Calm down, I know what I'm doing!";
        if (isQuestion) return "Sure.";
        if (isYelling) return "Whoa, chill out!";
		
        return "Whatever.";
    }
}