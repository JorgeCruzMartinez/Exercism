public class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        switch (balance)
        {
            case < 0:
                return 3.213f;
            case < 1000:
                return 0.5f;
            case < 5000:
                return 1.621f;
            default:
                return 2.475f;
        }
        
    }

    // Calculate the interest for the given balance
    public static decimal Interest(decimal balance)
    {
        float rate = InterestRate(balance);
        return balance * (decimal)(rate / 100);
    }

    // When calculating the annual balance update, we can use methods we have defined in previous steps.
    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        decimal interest = Interest(balance);
        return balance + interest;
    }

    // To calculate the years one can keep looping until the desired balance is reached and there's a special operator to increment values by 1.        
    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            years++;
        }
        return years;
    }
}
