using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        var result = new StringBuilder();
    
        if (number % 3 == 0)            
            result.Append("Pling");
        
        if (number % 5 == 0)            
            result.Append("Plang");
        
        if (number % 7 == 0)            
            result.Append("Plong");
        
    
        // If no sounds were appended, return the number as a string
        if (result.Length == 0)            
            return number.ToString();            
        else
            return result.ToString();
    }
}