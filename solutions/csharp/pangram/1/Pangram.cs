using System;
using System.Collections.Generic;
using System.Linq; // For using ToLower() and Where() if desired


public static class Pangram
{
    public static bool IsPangram(string input)
    {
        // Convert the input to lowercase for case-insensitivity
        string lowerInput = input.ToLower();

        // Use a HashSet to store unique letters encountered
        HashSet<char> uniqueLetters = new HashSet<char>();

        // Iterate through each character in the lowercase input
        foreach (char c in lowerInput)
        {
            // Check if the character is an English letter
            if (char.IsLetter(c))
            {
                uniqueLetters.Add(c); // Add to the set if it's a letter
            }
        }

        // A pangram has 26 unique English letters
        return uniqueLetters.Count == 26;
    }
}