using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Project
{
    internal class Persona : Item
    {
        string personaname;
        public string Prsonaname => personaname;

        public Persona(ItemRank rank, string name, string personaname) : base(rank, name)
        {
            this.personaname = personaname;
        }
    }
}
