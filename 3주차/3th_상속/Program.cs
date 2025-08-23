using System.ComponentModel.DataAnnotations.Schema;

namespace _3th_상속
{
    class Program
    {
        static void Main(string[] args)
        {
            // 게임에 등장할 클래스를 만들어 봅니다.

            //아이템 클래스 여러분들이 생성해보세요.
            // AI를 사용하여서, 아이템 이름, 가격, 아이템의 타입을 분류를 해보세요.
            // 어떤 분류인가? 포션, 장착 가능한 것, 연금 재료.....)
            // 열거형 enum 사용하여서 Item 클래스를 생성하면 됩니다.

            // 이 클래스를 재사용하는 방법을 배워봅니다.

            /* Potion bluePotion = new Potion("블루포션", 100, ItemType.POTION);
             Potion redPotion = new Potion("레드포션", 100, ItemType.POTION);
             Equippable sword = new Equippable("칼", 300, ItemType.EQUIPPABLE);
             Equippable spear = new Equippable("창", 300, ItemType.EQUIPPABLE);
             Equippable Amor = new Equippable("갑옷", 150, ItemType.EQUIPPABLE);
             Equippable pants = new Equippable("바지", 75, ItemType.EQUIPPABLE);
             AlchemyMaterial Iron = new AlchemyMaterial("철", 30, ItemType.ALCHEMYMATERIAL);
             Job warrior = new Job("전사", 1500, ItemType.JOB);
             QuestItem scroll = new QuestItem("주문서", 1500, ItemType.QUESTITEM);

             List<Item> inventory = new List<Item>();
             inventory.Add(bluePotion);
             inventory.Add(redPotion);
             inventory.Add(sword);
             inventory.Add(spear);
             inventory.Add(Amor);
             inventory.Add(pants);
             inventory.Remove(sword);
             */
            // 위의 Item 직접생성한 아이템 데이터입니다. 게임에서 사용할 수 있는 클래스를 만들어봅시다.

            // ItemManager, Player UseItem

            // Item타입을 List 자료형으로 추가해서 player가 리스트 안에 있는 모든 아이템을 실행하는 코드를 작성해줘

            // 클래스의 다형성
            /*Player player = new Player();
           
            foreach(var item in inventory)
            {
                player.UseItem(item);
            }
            */

            /* player.UseItem(warrior);
             player.UseItem(sword);
             player.UseItem(bluePotion);
             player.UseItem(Iron);
             player.UseItem(scroll);
         */


            Console.WriteLine("오크족과의 전투 게임 시작");
        
            // 플레이어 생성 (직업 지정)

            Job work = new Job("전사", 1000, ItemType.JOB);

            Player player = new Player(work);

            // 아이템 획득
            player.AddItem(new Potion("체력 포션", 50, ItemType.POTION));
            player.AddItem(new Equippable("낡은 검", 250, ItemType.EQUIPPABLE));
            player.AddItem(new AlchemyMaterial("오크 가죽", 10, ItemType.ALCHEMYMATERIAL));
            player.AddItem(new QuestItem("낡은 열쇠", 0, ItemType.QUESTITEM));
            player.AddItem(new Misc("낡은 지도", 20, ItemType.MISC));
            player.AddItem(new Potion("마나 포션", 75, ItemType.POTION));


            List<Monster> monsters = new List<Monster>
        {
            new Monster("고블린", 30, 5),
            new Monster("오크 전사", 80, 15),
            new Monster("오크 킹", 150, 25)
        };

            // 몬스터 생성
            Monster goblin = new Monster("고블린", 30, 5);
            Monster orc = new Monster("오크 전사", 80, 15);
            Monster orcKing = new Monster("오크 킹", 150, 25);

            // 전투 시작
            Console.WriteLine("\n--- 전투 시작! ---");
           


            Console.WriteLine("\n=== 게임 종료 ===");
        }
       public class Player
        {
            public List<Item> Inventory { get; private set; }
            public Job PlayerJob { get; private set; } // 직업 속성 추가

            public Player(Job job)
            {
                Inventory = new List<Item>();
                PlayerJob = job;
                Console.WriteLine($"플레이어가 {PlayerJob} 직업으로 생성되었습니다.");
            }

            public void AddItem(Item item)
            {
                Inventory.Add(item);
                Console.WriteLine($"[획득] {item.Name}을(를) 인벤토리에 추가했습니다.");
            }

            public void UseAllItems()
            {
                Console.WriteLine("\n--- 인벤토리 아이템 모두 사용하기 ---");
                foreach (var item in Inventory)
                {
                    item.Use();
                }
            }

     
        }

   
    }


}
