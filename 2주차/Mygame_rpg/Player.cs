using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mygame_rpg
{
    public class player
    {


        public int Health { get; private set; }
        public int AttackPower { get; private set; }
        public int Level { get; private set; }
        public Experience PlayerExperience { get; private set; }
        public List<Skill> Skills { get; private set; }

        public bool IsAlive => Health > 0;

      public player()
        {
            Health = 150;
            AttackPower = 50;
            Level = 1;
            PlayerExperience = new Experience();
            Skills = new List<Skill> { new PhysicalSkill("성경 읽기", 30) };
        }

        public void GainExperience(int amount)
        {
            PlayerExperience.AddExp(amount);
            if (PlayerExperience.CheckLevelUp(Level))
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Level = PlayerExperience.CurrentLevel;
            Health += 90;
            AttackPower += 5;
            Console.WriteLine($"🎉 레벨업! 현재 레벨: {Level}, 체력: {Health}, 공격력: {AttackPower}");
            LearnNewSkill();
        }

        private void LearnNewSkill()
        {
            switch (Level)
            {
                case 2:
                    Skills.Add(new MagicSkill("성스러운 불꽃", 70));
                    Console.WriteLine("새로운 기술을 배웠습니다: 성스러운 불꽃");
                    break;
                case 3:
                    Skills.Add(new PhysicalSkill("성경 방패", 99));
                    Console.WriteLine("새로운 기술을 배웠습니다: 성경 방패");
                    break;
                case 4:
                    Skills.Add(new RangedAttack("물건 던지기", 75));
                    Console.WriteLine("새로운 기술을 배웠습니다: 물건 던지기");
                    break;
            }
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"플레이어가 {damage}의 피해를 입었습니다. 남은 체력: {Health}");
        }

        public void Attack(Demon demon, Skill skill)
        {
            skill.Use(this, demon);
        }




    }
}