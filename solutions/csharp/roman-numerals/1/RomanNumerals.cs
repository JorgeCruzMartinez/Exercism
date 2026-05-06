using System.Text;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int number)
    {
        if (number < 1 || number > 3999)
            throw new ArgumentOutOfRangeException("El rango de números romanos validos va del 1 al 3999.");
        var romanNumerals = new[]
        {
            new { Value = 1000, Numeral = "M" },
            new { Value = 900, Numeral = "CM" },
            new { Value = 500, Numeral = "D" },
            new { Value = 400, Numeral = "CD" },
            new { Value = 100, Numeral = "C" },
            new { Value = 90, Numeral = "XC" },
            new { Value = 50, Numeral = "L" },
            new { Value = 40, Numeral = "XL" },
            new { Value = 10, Numeral = "X" },
            new { Value = 9, Numeral = "IX" },
            new { Value = 5, Numeral = "V" },
            new { Value = 4, Numeral = "IV" },
            new { Value = 1, Numeral = "I" }
        };
    
        var result = new StringBuilder();
        foreach (var item in romanNumerals)
        {
            while (number >= item.Value)
            {
                result.Append(item.Numeral);
                number -= item.Value;
            }
        }
        return result.ToString();
    }
}