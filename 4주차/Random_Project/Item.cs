using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Project
{

    public enum ItemRank
    {
        C, B, A, S, SS, UR, LR, Underfined
    }
    internal class Item
    {
        // 뽑기를 한다고 무엇을 뽑았는가?
        // 실제 게임정보 구글에서 확인

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
