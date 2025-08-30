using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRandom
{
   public enum ItemRank
    {
        일반, 희귀, 드문, 신화, 전설, 역사
    }
    internal class Item
    {
        ItemRank rank;
        string name;

        public ItemRank Rank => rank;
        public string Name => name;

        public Item(ItemRank rank, string name)
        {
            this.rank = rank;
            this.name = name;
        }
    }
}
