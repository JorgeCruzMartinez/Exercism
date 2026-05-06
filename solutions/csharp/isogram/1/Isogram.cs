using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var lowerLetters = word.ToLower().Where(Char.IsLetter).ToList();
        return lowerLetters.Distinct().Count() == lowerLetters.Count;
    }
}