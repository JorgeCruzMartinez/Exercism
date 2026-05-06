
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string chain, int shiftKey)
    {
        if (chain == null) return string.Empty;

        int normalized = ((shiftKey % 26) + 26) % 26; // asegura 0..25
        StringBuilder result = new StringBuilder(chain.Length);

        foreach (char c in chain)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                char rotatedChar = (char)((c - offset + normalized) % 26 + offset);
                result.Append(rotatedChar);
            }
            else            
                result.Append(c);
        }
        return result.ToString();
    }
}
