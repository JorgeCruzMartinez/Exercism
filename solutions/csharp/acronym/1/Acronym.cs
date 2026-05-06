public static class Acronym
{    
    private static readonly char[] Separators = new[] { ' ', '-', '_' };

    public static string Abbreviate(string phrase)
    { 
        string[] words = phrase.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
        var acro = new List<char>(words.Length);

        foreach (string word in words)
        {
            char letter = char.ToUpper(word[0]);
            acro.Add(letter);
        }

        return new string(acro.ToArray());
    }
}