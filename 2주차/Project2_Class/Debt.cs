using System;

public class Debt
{
    public int Amount { get; private set; }
    public double CurrentInterestRate { get; private set; }

    public Debt(int initialAmount, double initialInterestRate)
    {
        Amount = initialAmount;
        CurrentInterestRate = initialInterestRate;
    }

    public void Pay(int amount)
    {
        if (amount > 0)
        {
            Amount -= amount;
            if (Amount < 0)
            {
                Amount = 0;
            }
        }
    }

    public void ApplyInterest()
    {
        Amount = (int)(Amount * (1 + CurrentInterestRate));
        Console.WriteLine($"Debt increased by interest. Current debt: ${Amount}");
    }

    public void TriggerEvent()
    {
        // 빚 수치에 따라 특별 이벤트 발생
        if (Amount > 5000)
        {
            Console.WriteLine("Warning! Your debt is getting out of control.");
        }
    }
}