using System;
using System.Collections.Generic;

public class Consumer
{
    public string Name { get; private set; }
    public string Tier { get; private set; } // 예: "Common", "Rich", "Expert"
    public int Money { get; private set; }
    public Dictionary<string, double> ItemPreferences { get; private set; }

    public Consumer(string name, string tier, int money, Dictionary<string, double> preferences)
    {
        Name = name;
        Tier = tier;
        Money = money;
        ItemPreferences = preferences;
    }

    public int GetPriceFor(Item item)
    {
        if (ItemPreferences.TryGetValue(item.Name, out double preferenceFactor))
        {
            // 등급에 따른 추가 보정치 적용 (예시)
            double tierBonus = Tier == "Rich" ? 1.5 : 1.0;
            return (int)(item.BaseValue * preferenceFactor * tierBonus);
        }
        return item.BaseValue;
    }

    public bool CanAfford(int price)
    {
        return Money >= price;
    }
}