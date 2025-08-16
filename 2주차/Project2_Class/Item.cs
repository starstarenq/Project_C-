using System;

public class Item
{
    public string Name { get; private set; }
    public string ItemType { get; private set; } // 예: "Weapon", "Potion"
    public int BaseValue { get; private set; }

    public Item(string name, string type, int baseValue)
    {
        Name = name;
        ItemType = type;
        BaseValue = baseValue;
    }
}
