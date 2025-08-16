using System;

public class CurrencySource
{
    public string Name { get; private set; }
    public string SourceType { get; private set; } // 예: "Gambling", "Labor", "Corporate"

    public CurrencySource(string name, string type)
    {
        Name = name;
        SourceType = type;
    }

    public int GetMoney()
    {
        // 획득처의 종류에 따라 다른 금액을 반환하는 로직 (예시)
        switch (SourceType)
        {
            case "Gambling":
                // 도박은 랜덤한 금액을 반환
                Random rnd = new Random();
                return rnd.Next(-200, 500); // 잃거나 딸 수 있음
            case "Labor":
                return 100; // 정해진 금액
            case "Corporate":
                return 250; // 더 큰 금액
            default:
                return 0;
        }
    }
}