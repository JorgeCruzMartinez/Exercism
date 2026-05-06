public static class Triangle
{
    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        if (!IsValidTriangle(side1, side2, side3))
            return false;
        return Math.Abs(side1 - side2) < 1e-12 && Math.Abs(side2 - side3) < 1e-12;
    }
    
    public static bool IsIsosceles(double side1, double side2, double side3)
    {
        if (!IsValidTriangle(side1, side2, side3))
            return false;
        return Math.Abs(side1 - side2) < 1e-12 || Math.Abs(side2 - side3) < 1e-12 || Math.Abs(side1 - side3) < 1e-12;
    }       
    
    public static bool IsScalene(double side1, double side2, double side3)
    {
        if (!IsValidTriangle(side1, side2, side3))
            return false;
        return Math.Abs(side1 - side2) >= 1e-12 && Math.Abs(side2 - side3) >= 1e-12 && Math.Abs(side1 - side3) >= 1e-12;
    }
    
    //Helper method to check if the sides can form a valid triangle
    private static bool IsValidTriangle(double side1, double side2, double side3)
    {
        // Reject non-finite or non-positive sides and the method is used to check whether the value is out of bound or not. https://www.geeksforgeeks.org/c-sharp/double-isfinite-method-in-c-sharp/
        if (!double.IsFinite(side1) || !double.IsFinite(side2) || !double.IsFinite(side3))
            return false;
        if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            return false;
    
        // Use a tiny tolerance to account for floating-point rounding
        const double eps = 1e-12;
        return side1 + side2 > side3 - eps &&
               side1 + side3 > side2 - eps &&
               side2 + side3 > side1 - eps;
    }
}