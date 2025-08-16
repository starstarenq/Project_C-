using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mygame_rpg
{
    public abstract class Skill
    {
        public string Name { get; private set; }
        public int Damage { get; protected set; }

        public Skill(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public abstract void Use(player player, Demon demon);
    }

    public class PhysicalSkill : Skill
    {
        public PhysicalSkill(string name, int baseDamage) : base(name, baseDamage) { }

        public override void Use(player player, Demon demon)
        {
            int totalDamage = player.AttackPower + Damage;
            Console.WriteLine($"플레이어가 '{Name}' 기술을 사용하여 {demon.Name}에게 {totalDamage}의 물리 피해를 입혔습니다.");
            demon.TakeDamage(totalDamage);
        }
    }

    public class MagicSkill : Skill
    {
        public MagicSkill(string name, int baseDamage) : base(name, baseDamage) { }

        public override void Use(player player, Demon demon)
        {
            int totalDamage = (int)(player.AttackPower * 1.5 + Damage);
            Console.WriteLine($"플레이어가 '{Name}' 기술을 사용하여 {demon.Name}에게 {totalDamage}의 마법 피해를 입혔습니다.");
            demon.TakeDamage(totalDamage);
        }
    }
}
