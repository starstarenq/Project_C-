using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mygame_rpg
{
    public abstract class Demon
    {




        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int AttackPower { get; protected set; }
        public int ExperienceReward { get; protected set; }

        public bool IsAlive => Health > 0;

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name}이(가) {damage}의 피해를 입었습니다. 남은 체력: {Health}");
        }

        public virtual void AttackPlayer(player player)
        {
            player.TakeDamage(AttackPower);
        }
    }

    public class NormalDemon : Demon
    {
        public NormalDemon(string name, int health, int attackPower, int exp)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            ExperienceReward = exp;
        }
    }

    public class BossDemon : Demon
    {
        public BossDemon(string name, int health, int attackPower, int exp)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            ExperienceReward = exp;
        }

        public override void AttackPlayer(player player)
        {
            Console.WriteLine($"💥 보스 악령의 강력한 공격! 💥");
            player.TakeDamage(AttackPower);
        }


    }
}