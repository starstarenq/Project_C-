using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRandom
{
    internal class Gatcha
    {

        int seed = Environment.TickCount;
        Random random = new Random();
        List<Item> gatchaTable = new List<Item>();
        public void Generateseed()
        {
            seed = Environment.TickCount;
            Console.WriteLine(" Seed값 : " + seed);
     
      }
        public void SetTable()
        {
            gatchaTable.Add(new Item(ItemRank.일반, "광부"));
            gatchaTable.Add(new Item(ItemRank.희귀, "기사"));
            gatchaTable.Add(new Item(ItemRank.드문, "성기사"));
            gatchaTable.Add(new Item(ItemRank.신화, "흑기사"));
            gatchaTable.Add(new Item(ItemRank.전설, "용기사"));
            gatchaTable.Add(new Item(ItemRank.역사, "검의 군주"));
        }
        
        public void GenerateRandom()
        {
            random = new Random(10974281);
        }
        public void Pick()
        {
            int rand = random.Next(0, 11);
            Console.WriteLine("랜덤 값 : " + rand);
        }
    }


}
