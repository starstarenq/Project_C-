using System.Numerics;

namespace Mygame_rpg
{
    internal class Program
    {
        static void Main(string[] args)
        {



            // 플레이어가 처음에 성경책 한권을 들고 폐허가 된 집에 들어갑니다. 이 플레이어는 폐허가 된 집에서 나오는 악령들을 물리치며 3일을 버텨야 합니다.
            // 플레이어는 악령을 퇴치하며 경험치를 쌓고 경험치가 일정량 채워질때마다 새로운 기술을 배우며 체력을 회복하고 공격력과 체력이 증가합니다.
            // 악령의 종류는 10가지로 각각 쓰러뜨릴 때마다 주는 경험치의 양이 다릅니다.
            // 전투 한번에 악령은 최대 3마리까지 나오며 2일차에는 보스 악령이 한마리 나옵니다.

            // 플레이어 ( 기술, 체력, 공격력 )
            // 악령 ( 보스 악령, 일반 악령 )
            // 기술 ( 물리, 마법 )
            // 기간 ( 1일차 밤, 2일차 밤, 3일차 밤 )
            // 경험치 ( 레벨증가 )
            // 

            Console.WriteLine("나 : 이 집은 도대체 뭐지...?" +
                "");

            Console.WriteLine("나 : 들어가봐야겠다......");

            Console.WriteLine("폐허가 된 집에서 3일을 버텨야 합니다.");
            player player = new player();

            for (int i = 1; i <= 3; i++)
            {
                Day currentDay = new Day(player, i);
                currentDay.StartNight();
                if (!player.IsAlive)
                {
                    Console.WriteLine("나 : 큭... 이런곳에서 죽다니......");
                    Console.WriteLine("\n게임 오버. 당신은 3일을 버티지 못했습니다.");
                    return;
                }
            }

            Console.WriteLine("\n🎉 축하합니다! 당신은 3일간의 시련을 이겨냈습니다!");
        }


    }
    }
