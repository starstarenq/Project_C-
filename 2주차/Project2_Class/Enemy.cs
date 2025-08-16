using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Class
{
    class Enemy
    {
        public string name;
        public int health;

        public char skill;
        public float stamina;

        

        public Enemy(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        public Enemy(char skill, float stamina)
        {
            this.skill = skill;
            this.stamina = stamina;
        }

        public Enemy(string name, int health, char skill, float stamina)
        {
            this.name = name;
            this.health = health;
            this.skill = skill;
            this.stamina = stamina;
        }

        public void SetName(string 적)
        {

            name = 적;
        }




    }


}
