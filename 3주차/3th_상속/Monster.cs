using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3th_상속
{
    public class Monster
    {
        public string Name { get; private set; }
        public int HP { get; private set; }
        public int AttackPower { get; private set; }

        public Monster(string name, int hp, int attackPower)
        {
            Name = name;
            HP = hp;
            AttackPower = attackPower;
        }

        // 피해 받는 메서드
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0) HP = 0;
            Console.WriteLine($"{Name}이(가) {damage}의 피해를 입고, 남은 체력: {HP}");
        }

        // 플레이어 공격 메서드
        public void Attack(Player player)
        {
            int damage = AttackPower;
            player.TakeDamage(damage);
            Console.WriteLine($"{Name}이(가) {player.Name}에게 {damage}의 피해를 입혔습니다!");
        }
        public static void Fight(Player player, Monster monster)
        {
            // 전투 로직
            while (player.HP > 0 && monster.HP > 0)
            {
                // 몬스터와 플레이어가 번갈아 공격하는 로직
            }
        }
    }
}
