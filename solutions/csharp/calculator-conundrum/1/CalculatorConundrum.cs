public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if (operation == null)
        {
            throw new ArgumentNullException();
        }
        return operation switch
        {
            "+" => $"{operand1} + {operand2} = {(operand1 + operand2)}",
            "*" => $"{operand1} * {operand2} = {(operand1 * operand2)}",
            "/" => operand2 == 0 ? "Division by zero is not allowed."
                : $"{operand1} / {operand2} = {(operand1 / operand2)}",
            "" => throw new ArgumentException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}