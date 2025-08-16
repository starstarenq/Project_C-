using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mygame_rpg
{
    public class Day
    {



        private player _player;
        private int _dayNumber;

        public Day(player player, int dayNumber)
        {
            _player = player;
            _dayNumber = dayNumber;
        }

        public void StartNight()
        {
            Console.WriteLine($"\n--- {_dayNumber}일차 밤이 되었습니다. ---");

            if (_dayNumber == 2)
            {
                StartBossBattle();
            }
            else
            {
                StartNormalBattles();
            }
        }

        private void StartNormalBattles()
        {
            Random rand = new Random();
            int battleCount = 0;
            while (_player.IsAlive && battleCount < 3) // 하루에 3번의 전투
            {
                var demons = SpawnDemons(rand.Next(1, 4));
                Battle(demons);
                if (!_player.IsAlive) return;
                battleCount++;
            }
        }

        private void StartBossBattle()
        {
            var boss = new BossDemon("대악마", 300, 40, 500);
            Console.WriteLine("💥 보스전! 대악마가 나타났습니다! 💥");
            Battle(new List<Demon> { boss });
        }

        private List<Demon> SpawnDemons(int count)
        {
            List<Demon> demons = new List<Demon>();
            Random rand = new Random();
            List<Tuple<string, int, int, int>> demonTypes = new List<Tuple<string, int, int, int>>
        {
            Tuple.Create("원혼", 20, 5, 20),
            Tuple.Create("폴터가이스트", 35, 10, 35),
            Tuple.Create("서큐버스", 50, 15, 50),
            Tuple.Create("좀비", 15, 3, 15),
            Tuple.Create("그렘린", 25, 8, 25)
        };

            for (int i = 0; i < count; i++)
            {
                var demonInfo = demonTypes[rand.Next(demonTypes.Count)];
                demons.Add(new NormalDemon(demonInfo.Item1, demonInfo.Item2, demonInfo.Item3, demonInfo.Item4));
            }
            Console.WriteLine($"\n{count}마리의 악령이 나타났습니다!");
            return demons;
        }

        private void Battle(List<Demon> enemies)
        {
            while (_player.IsAlive && enemies.Any(d => d.IsAlive))
            {
                Console.WriteLine("\n--- 전투 시작 ---");
                Console.WriteLine("공격할 기술을 선택하세요:");
                for (int i = 0; i < _player.Skills.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_player.Skills[i].Name}");
                }
                int choice = int.Parse(Console.ReadLine()) - 1;
                Skill selectedSkill = _player.Skills[choice];

                Demon target = enemies.First(d => d.IsAlive);
                _player.Attack(target, selectedSkill);

                foreach (var demon in enemies.Where(d => d.IsAlive))
                {
                    demon.AttackPlayer(_player);
                }

                if (!enemies.Any(d => d.IsAlive))
                {
                    int totalExp = enemies.Sum(d => d.ExperienceReward);
                    _player.GainExperience(totalExp);
                }
            }
        }



    }
}
