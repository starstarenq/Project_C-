using System;

public class Time
{
    public int DaysLeft { get; private set; }

    public Time(int initialDebtAmount)
    {
        // 빚의 크기에 따라 초기 기간 설정
        if (initialDebtAmount > 10000)
        {
            DaysLeft = 90; // 큰 빚
        }
        else if (initialDebtAmount > 5000)
        {
            DaysLeft = 60; // 중간 빚
        }
        else
        {
            DaysLeft = 30; // 작은 빚
        }
    }

    public void PassDay()
    {
        if (DaysLeft > 0)
        {
            DaysLeft--;
        }
    }

    public bool IsTimeUp()
    {
        return DaysLeft <= 0;
    }
}