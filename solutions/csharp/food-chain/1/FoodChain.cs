using System.Text;
using System.Collections.Generic;

public static class FoodChain
{
    private static Dictionary<int, string> AnimalsShort = new Dictionary<int, string>
    {
        {1, "fly"},
        {2, "spider"},
        {3, "bird"},
        {4, "cat"},
        {5, "dog"},
        {6, "goat"},
        {7, "cow"}
    };
    
    private static Dictionary<int, string> AnimalsLong = new Dictionary<int, string>
    {
        {1, "fly"},
        {2, "spider that wriggled and jiggled and tickled inside her"},
        {3, "bird"},
        {4, "cat"},
        {5, "dog"},
        {6, "goat"},
        {7, "cow"}
    };
    
    private static Dictionary<int, string> VerseAction = new Dictionary<int, string>()
    {
        {1, string.Empty},
        {2, "It wriggled and jiggled and tickled inside her."},
        {3, "How absurd to swallow a bird!"},
        {4, "Imagine that, to swallow a cat!"},
        {5, "What a hog, to swallow a dog!"},
        {6, "Just opened her throat and swallowed a goat!"},
        {7, "I don't know how she swallowed a cow!"},
    };
    
    public static string Recite(int verseNumber)
    {
        var sb = new StringBuilder();
        if (verseNumber == 8)
        {
            sb.Append("I know an old lady who swallowed a horse.");
            sb.Append('\n');
            sb.Append("She's dead, of course!");
            return sb.ToString();
        }
        sb.Append("I know an old lady who swallowed a ");
        sb.Append(AnimalsShort[verseNumber]);
        sb.Append('.');
        var action = VerseAction[verseNumber];
        if (action != string.Empty)
        {
            sb.Append('\n');
            sb.Append(action);
        }
        sb.AppendCatchChain(verseNumber);
        sb.Append('\n');
        sb.Append("I don't know why she swallowed the fly. Perhaps she'll die.");
        return sb.ToString();
    }
    
    private static void AppendCatchChain(this StringBuilder sb, int verseNumber)
    {
        for (var i = verseNumber; i > 1; i--)
        {
            sb.Append('\n');
            sb.Append("She swallowed the ");
            sb.Append(AnimalsShort[i]);
            sb.Append(" to catch the ");
            sb.Append(AnimalsLong[i - 1]);
            sb.Append('.');
        }
    }
    
    public static string Recite(int startVerse, int endVerse)
    {
        var sb = new StringBuilder();
        for (var verse = startVerse; verse <= endVerse; verse++)
        {
            sb.Append(Recite(verse));
            sb.Append("\n\n");
        }
        sb.Length -= 2; // Remove trailing new lines
        return sb.ToString();
    }
}