using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3th_상속
{
    public enum WORK
    {
        Warrior,
        Mage,
        Archer,
        Thief,
        Healer
    }
    public class Player
    {
        public string Name { get; private set; }
        public int HP { get; private set; }
        public int AttackPower { get; private set; }
        public List<Item> Inventory { get; private set; }
        public Job PlayerJob { get; private set; } // 직업 속성 추가

        public Player(string name, Job job)
        {
            Name = name;
            PlayerJob = job;
            HP = 100; // 기본 체력
            AttackPower = 10; // 기본 공격력
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
    
     // 무기 강화 메서드
    public void EnhanceWeapon()
        {
            // 인벤토리에서 연금 재료와 무기(Equippable)를 찾음
            var alchemyMaterial = Inventory.FirstOrDefault(item => item.Type == ItemType.ALCHEMYMATERIAL);
            var weapon = Inventory.FirstOrDefault(item => item.Type == ItemType.EQUIPPABLE);

            if (alchemyMaterial == null)
            {
                Console.WriteLine("강화에 필요한 연금 재료가 없습니다.");
                return;
            }

            if (weapon == null)
            {
                Console.WriteLine("강화할 무기가 없습니다.");
                return;
            }

            // 재료를 사용하여 무기 강화
            Inventory.Remove(alchemyMaterial);
            AttackPower += 5; // 공격력 증가
            Console.WriteLine($"\n** {weapon.Name}을(를) {alchemyMaterial.Name}로 강화했습니다! **");
            Console.WriteLine($"현재 공격력: {AttackPower}");
        }

        // 몬스터 공격 메서드
        public void Attack(Monster monster)
        {
            int damage = AttackPower;
            monster.TakeDamage(damage);
            Console.WriteLine($"{Name}이(가) {monster.Name}에게 {damage}의 피해를 입혔습니다!");
        }

        // 피해 받는 메서드
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0) HP = 0;
            Console.WriteLine($"{Name}이(가) {damage}의 피해를 입고, 남은 체력: {HP}");
        }
    }

}
