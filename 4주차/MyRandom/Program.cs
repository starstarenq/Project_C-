namespace MyRandom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gatcha gatcha = new Gatcha();
            
            gatcha.GenerateRandom();
            gatcha.Pick();
            gatcha.SetTable();
            List<Item> gatchaTable = new List<Item>();
            gatchaTable.Add(new Item(ItemRank.일반, "광부"));
            gatchaTable.Add(new Item(ItemRank.희귀, "기사"));
            gatchaTable.Add(new Item(ItemRank.드문, "성기사"));
            gatchaTable.Add(new Item(ItemRank.신화, "흑기사"));
            gatchaTable.Add(new Item(ItemRank.전설, "용기사"));
            gatchaTable.Add(new Item(ItemRank.역사, "검의 군주"));
            Random rand = new Random();
            int randomIndex = rand.Next(gatchaTable.Count);

            Item selectedItem = gatchaTable[randomIndex];

            Console.WriteLine("등급 : " + selectedItem.Name "직업 : " )
        }
    }
}
