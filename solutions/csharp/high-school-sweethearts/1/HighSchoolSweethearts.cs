using System.Globalization;

public static class HighSchoolSweethearts
{    
     public static string DisplaySingleLine(string         studentA, string studentB)
        {
            string first = studentA.PadLeft(29, ' ');
            string second = studentB.PadRight(29, ' ');
            return $"{first} ♡ {second}";
        }
        
        public static string DisplayBanner(string studentA, string studentB) =>
    @$"     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA.Trim()}  +  {studentB.Trim()}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";

        public static string DisplayAmericanExchangeStudents(string studentA, string studentB, DateTime start, float hours) =>
            string.Format(new CultureInfo("en-US"), "{0} and {1} have been dating since {2:d} - that's {3:N2} hours", studentA, studentB, start, hours);

        public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours) =>
            string.Format(new CultureInfo("de-DE"), "{0} and {1} have been dating since {2:d} - that's {3:N2} hours", studentA, studentB, start, hours);
}
