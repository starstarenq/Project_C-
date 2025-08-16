public class Player
{
    public int Money { get; private set; }
    public int DebtRepaymentDaysLeft { get; private set; }
    public List<Consumer> MetConsumers { get; private set; }

    public Player(int startingMoney, int repaymentDays)
    {
        Money = startingMoney;
        DebtRepaymentDaysLeft = repaymentDays;
        MetConsumers = new List<Consumer>();
    }

    public void AddMoney(int amount)
    {
        if (amount > 0)
        {
            Money += amount;
        }
    }

    // 이 메서드를 추가하여 오류를 해결합니다.
    public void SetRepaymentDays(int days)
    {
        if (days >= 0)
        {
            DebtRepaymentDaysLeft = days;
        }
    }

    public void DecreaseDaysLeft()
    {
        if (DebtRepaymentDaysLeft > 0)
        {
            DebtRepaymentDaysLeft--;
        }
    }

    public void AddMetConsumer(Consumer consumer)
    {
        if (!MetConsumers.Contains(consumer))
        {
            MetConsumers.Add(consumer);
        }
    }

    public override string ToString()
    {
        return $"Player: Money = ${Money}, Days Left = {DebtRepaymentDaysLeft}";
    }
}