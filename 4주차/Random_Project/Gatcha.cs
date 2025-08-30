using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Project
{
    internal class Gatcha
    {
        // 랜덤이란 임의의 숫자를 반환하는 개념.
        // 0 ~ 10 사이의 숫자를 전달해서그 숫자하나를 출력하는 코드.

        // seed 개념.
        // 랜덤 최초의 값에 따라서 그 다음 결과가 결정이 되어진다.
        // 수도 랜덤 (Pseudo Random) - 알고리즘에 의해서 결과가 정해진 랜덤이다.

        /* 
         * 랜덤 - 실행할 때 마다 다른 값을 생성하고 싶다.
         * - 실행할 때 동일한 결과를 생성할 수 있는 기능을 제공한다.
         * - 랜덤을 생성할 때 동일한 seed를 실행하면 같은 결과가 나타난다.
         * - 게임에서 사용되는 랜덤이 제대로 작동하는지 테스트를 하기 위해서.           
         */

        int seed = Environment.TickCount;

        Random random = new Random();

        List<Item> gatchaTable = new List<Item>();

        float[] probabilityByRank = { 50, 25, 15, 5, 3, 1.5f, 0.5f };  // 다음 확률로 아이템을 뽑는 코드를 C#함수로 작성해줘. 
        float[] sumProbability;
        List<Item>[] itemRanks = new List<Item>[7];
        List<Item> cRank;
        List<Item> bRank;
        List<Item> aRank;
        List<Item> sRank;
        List<Item> ssRank;
        List<Item> urRank;
        List<Item> lrRank;

        public void GenerateProbability()
        {

            float totalPro = probabilityByRank.Sum();

            sumProbability = new float[probabilityByRank.Length];

            float cumValue = 0;

            for(int i=0; i<probabilityByRank.Length; i++)
            {
                cumValue += probabilityByRank[i];
                sumProbability[i] = cumValue;
            }

        }


        public void GenerateSeed()
        {
            seed = Environment.TickCount;
            Console.WriteLine("Seed 값 : " + seed);
        }

        public void GenerateRandom()
        {
            random = new Random(2871156);
        }
        

        // 가챠를 뽑을 확률. 만들어서 특정 확률의 아이템을 뽑았을 때 그 아이템이 뽑히게 하고 싶다.
        // 7개의 등급에 확률 7개. 100% (50%, 25%, 15%, 5%, 3%, 1.5%, 0.5%)  


        public void SetTable()
        {
            gatchaTable.Add(new Persona(ItemRank.SS, "조커", "아르센"));
            gatchaTable.Add(new Persona(ItemRank.S, "스컬", "캡틴 키드"));
            gatchaTable.Add(new Item(ItemRank.S, "바이올렛"));
            gatchaTable.Add(new Persona(ItemRank.A, "퀸", "요한나"));
            gatchaTable.Add(new Item(ItemRank.B, "폭스"));
            gatchaTable.Add(new Item(ItemRank.C, "캣"));
            gatchaTable.Add(new Item(ItemRank.UR, "로키"));
            gatchaTable.Add(new Persona(ItemRank.LR, "타나토스", "water"));
            gatchaTable.Add(new Item(ItemRank.LR, "황룡"));

          itemRanks[0] = gatchaTable.Where(i => i.Rank == ItemRank.C).ToList();
          itemRanks[1] = gatchaTable.Where(i => i.Rank == ItemRank.B).ToList();
          itemRanks[2] = gatchaTable.Where(i => i.Rank == ItemRank.A).ToList();
          itemRanks[3] = gatchaTable.Where(i => i.Rank == ItemRank.S).ToList();
          itemRanks[4] = gatchaTable.Where(i => i.Rank == ItemRank.SS).ToList();
          itemRanks[5] = gatchaTable.Where(i => i.Rank == ItemRank.UR).ToList();
          itemRanks[6] = gatchaTable.Where(i => i.Rank == ItemRank.LR).ToList();


        }

        public List<Item> PickRank()
        {

            float rand = (float)random.NextDouble() * 100f;

            for(int i = 0; i< sumProbability.Length; i++)
            {
                if (rand < sumProbability[i])
                {
                    return itemRanks[i];
                }
            }
            return itemRanks[sumProbability.Length - 1];
            
        }
        public void Pick()
        {
            // 내가 뽑은 가챠의 등급을 먼저 뽑는다.

            List<Item> pickeditem = PickRank();

            int rand = random.Next(0, pickeditem.Count);        // 0 <= 랜덤수 < 최대 수
           
            // Console.WriteLine("랜덤 값" + rand);
            if(pickeditem[rand] is Persona)
            {
                Console.WriteLine(" 랭크 :  " + pickeditem[rand].Rank + " / 이름 :  " + pickeditem[rand].Name + " / 페르소나 : " + (pickeditem[rand] as Persona).Prsonaname);
            }
            else
            {
                Console.WriteLine(" 랭크 :  " + pickeditem[rand].Rank + " / 이름 :  " + pickeditem[rand].Name);
            }
        
        }

        public void Pick10Time()
        {
        
        for(int i=0; i<10; i++)
            {
                Pick();
            }
        
        }
        public int DrawItemByRank()
        {
            float totalProbability = probabilityByRank.Sum();
            float randomNumber = (float)new Random().NextDouble() * totalProbability;

            float cumulativeProbability = 0;
            for (int i = 0; i < probabilityByRank.Length; i++)
            {
                cumulativeProbability += probabilityByRank[i];
                if (randomNumber < cumulativeProbability)
                {
                    return i + 1; // Return the rank (1-indexed)
                }
            }

            // Fallback in case of rounding errors, should not be reached with proper probabilities
            return probabilityByRank.Length;
        }
    }
}
