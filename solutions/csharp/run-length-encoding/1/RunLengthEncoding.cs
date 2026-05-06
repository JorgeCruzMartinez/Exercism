using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }
    
        StringBuilder encoded = new StringBuilder();
        int count = 1;
        char currentChar = input[0];
    
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == currentChar)
            {
                count++;
            }
            else
            {
                encoded.Append(count > 1 ? count.ToString() : "");
                encoded.Append(currentChar);
                currentChar = input[i];
                count = 1;
            }
        }
        encoded.Append(count > 1 ? count.ToString() : "");
        encoded.Append(currentChar);
    
        return encoded.ToString();
    }
    
    public static string Decode(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }
    
        StringBuilder decoded = new StringBuilder();
        StringBuilder countBuffer = new StringBuilder();
    
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                countBuffer.Append(c);
            }
            else
            {
                int count = countBuffer.Length == 0 ? 1 : int.Parse(countBuffer.ToString());
                decoded.Append(c, count);
                countBuffer.Clear();
            }
        }
    
        return decoded.ToString();
    }
}    

