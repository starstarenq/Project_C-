using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mygame_rpg
{
    public class Experience
    {



        public int CurrentExp { get; private set; }
        public int MaxExp { get; private set; }
        public int CurrentLevel { get; private set; }

        public Experience()
        {
            CurrentExp = 0;
            MaxExp = 100;
            CurrentLevel = 1;
        }

        public void AddExp(int amount)
        {
            CurrentExp += amount;
            Console.WriteLine($"경험치 {amount}을(를) 얻었습니다. 현재 경험치: {CurrentExp}/{MaxExp}");
        }

        public bool CheckLevelUp(int playerLevel)
        {
            if (CurrentExp >= MaxExp)
            {
                CurrentExp -= MaxExp;
                MaxExp = (int)(MaxExp * 1.5);
                CurrentLevel = playerLevel + 1;
                return true;
            }
            return false;
        }


    }
}
