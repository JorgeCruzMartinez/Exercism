public static class Say
{
    private static Dictionary<long, string> DigitNames = new()
    {
        {0,"zero"},
        {1,"one"},
        {2,"two"},
        {3,"three"},
        {4,"four"},
        {5,"five"},
        {6,"six"},
        {7,"seven"},
        {8,"eight"},
        {9,"nine"}
    };

    private static Dictionary<long, string> UpToTwentyNames = new()
    {
        {0, "ten"},
        {1, "eleven"},
        {2, "twelve"},
        {3, "thirteen"},
        {4, "fourteen"},
        {5, "fifteen"},
        {6, "sixteen"},
        {7, "seventeen"},
        {8, "eighteen"},
        {9, "nineteen"}
    };

    private static Dictionary<long, string> TensNames = new()
    {
        {1, "ten" },
        {2, "twenty" },
        {3, "thirty" },
        {4, "forty" },
        {5, "fifty" },
        {6, "sixty" },
        {7, "seventy" },
        {8, "eighty" },
        {9, "ninety" },
        {10, "hundred"}
    };

    private const long Tens = 10;
    private const long Hundreds = Tens * 10;
    private const long Thousands = Hundreds * Tens;
    private const long Millions = Thousands * Hundreds * Tens;
    private const long Billions = Millions * Hundreds * Tens;

    public static string InEnglish(long number)
    {
        if (number < 0 || number > 999999999999)
            throw new ArgumentOutOfRangeException();

        if (number < Tens)
            return GetDigit(number);

        if (number < Hundreds)
            return GetTens(number);

        if (number < Thousands)
            return GetRecurse(number, Hundreds, " hundred");

        if (number < Millions)
            return GetRecurse(number, Thousands, " thousand");

        if (number < Billions)
            return GetRecurse(number, Millions, " million");

        if (number <= 999999999999)
            return GetRecurse(number, Billions, " billion");

        throw new ArgumentOutOfRangeException();
    }

    private static string GetRecurse(long ths, long divider, string marker)
    {
        var hund = ths / divider;
        var remainder = ths % divider;
        var dec = InEnglish(hund) + marker;
        if (remainder > 0)
            dec += " " + InEnglish(remainder);

        return dec;
    }

    private static string GetTens(long ten)
    {
        var hund = ten / Tens;
        var remainder = ten % Tens;
        if (hund == 1)
            return UpToTwentyNames[remainder];

        var dec = TensNames[hund];
        if (remainder > 0)
            dec += "-" + GetDigit(remainder);

        return dec;
    }

    private static string GetDigit(long ten)
    {
        return DigitNames[ten];
    }
}