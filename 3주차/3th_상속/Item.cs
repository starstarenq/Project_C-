using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3th_상속
{
    public enum ItemType
    {
        POTION, EQUIPPABLE, ALCHEMYMATERIAL, QUESTITEM, CONSUMABLE, MISC, JOB            
    }
    public class Item
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public ItemType Type { get; private set; }
        public Item(string name, int price, ItemType type)
        {
            Name = name;
            Price = price;
            Type = type;
        }
        public void DisplayItemInfo()
        {
            Console.WriteLine($"이름: {Name}, 가격: {Price:C}, 타입: {Type}");
        }
        public virtual void Use()
        {

            Console.WriteLine($" {Name} -  가격 : {Price} - 아이템 분류 : {Type}");
        }
    }
    // 포션 클래스는 Item의 기능을 상속받겠다. (상속, inheritance)
    class Potion : Item
    {
        public Potion(string name, int price, ItemType type) : base(name, price, type)
        {

        }

        public override void Use() // 재정의하다.
        {
            // 부모에 있는 Use함수의 원본을 실행한다.
            base.Use();
            Console.WriteLine("포션을 사용했습니다.");
        }

    }
    class Equippable : Item
    {
     
public Equippable(string name, int price, ItemType type) : base(name, price, type)
        {       
        }
        public override void Use()
        {
            base.Use();
            Console.WriteLine("장비를 장착했습니다.");
        }


    }
    class AlchemyMaterial : Item
    {
        public AlchemyMaterial(string name, int price, ItemType type) : base(name, price, type)
        {
        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("재료를 사용했습니다.");
        }
    }
    public class Job : Item
    {
        public Job(string name, int price, ItemType type) : base(name, price, type)
        {
        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("전직을 완료했습니다.");
        }
    }
    class QuestItem : Item
    {
        public QuestItem(string name, int price, ItemType type) : base(name, price, type)
        {
        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("퀘스트를 완료했습니다.");
        }
    }
    class Misc : Item
    {
        public Misc(string name, int price, ItemType type) : base(name, price, type)
        {
        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine($"'{Name}' 아이템을 사용했습니다. 특별한 효과는 없습니다.");
        }
    }
}

