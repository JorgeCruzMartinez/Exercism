public static class ReverseString
{
    public static string Reverse(string input)
    {
        char[] s = input.ToCharArray();
        Array.Reverse(s);
        return new string(s);
    }
}