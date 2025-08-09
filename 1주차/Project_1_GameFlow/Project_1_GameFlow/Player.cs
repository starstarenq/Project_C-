using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1_GameFlow
{
    class Player
    {
        // 캐릭터의 상태를 나타내는 속성
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AttackPower { get; set; }

        public Player(string name, int maxHealth, int attackPower)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth; // 시작 체력은 최대 체력과 같게 설정
            AttackPower = attackPower;
        }
        public Player(float initialHP, float initialATK)
        {
            HP = initialHP;
            ATK = initialATK;
        }

        public void DisplayStatus()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0); // 화면 좌측 상단에 UI 표시

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"| {Name,-10} |"); // 이름을 왼쪽 정렬하여 출력
            Console.WriteLine("----------------------------------------");

            // 체력바(HP Bar)를 텍스트로 표현
            Console.Write("| Health : ");
            // 체력 상태에 따라 색상 변경
            if (Health > MaxHealth * 0.7)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (Health > MaxHealth * 0.3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            // 현재 체력 비율에 따라 '#' 기호로 체력바 그리기
            int healthBarLength = 20;
            int filledLength = (int)((double)Health / MaxHealth * healthBarLength);
            string healthBar = new string('#', filledLength) + new string('-', healthBarLength - filledLength);

            Console.Write($"[{healthBar}] {Health}/{MaxHealth}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(); // 줄바꿈

            // 공격력 정보 표시
            Console.WriteLine($"| Attack : {AttackPower,-4} |");
            Console.WriteLine("----------------------------------------");
        }
        // 캐릭터의 체력(Health Point)
        public float HP { get; set; }

        // 캐릭터의 공격력(Attack)
        public float ATK { get; set; }

        /// <summary>
        /// Player 클래스의 생성자
        /// </summary>
        /// <param name="initialHP">초기 체력 값</param>
        /// <param name="initialATK">초기 공격력 값</param>
      
    }
}
