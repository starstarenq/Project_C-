namespace Project2_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1. 게임을 ai로 만들기 (복습)
            // 아무 ai 사이트에 들어가서 만들고 싶은 게임을 검색하는 방법
            // C#으로 만들어라. 구체적인 정보를 전달해야 ai 원하는 결과물을 도출할 수 있다.
            //테트리스 게임, 블록4개, .. 조건 만들어줘. + 함수, 변수

            // 게임을 만들어 달라고 질문했을 때의 단점
            // - 게임에 추가하고 싶은 콘텐츠를 스스로 추가하기가 어렵다.
            // 남이 만들어 놓은 규칙에서 추가해야 되기 때문에 ( 작성된 코드를 이해를 하지 못한 경우 )
            // 프로그래밍 언어 문법이 존재, 이 문법 이해못하고 사용하면 에러가 발생한다. ( 네이밍 문제 )

            // 2. 게임의 구성 요소를 ai에게 작성해달라고 요청해보기.
            // 게임을 작은 구성 요소를 나누어야 할 필요성을 느꼈다면..
            // 어떻게 나눌 것인가? -> Class 객체 지향 프로그래밍
            // Class를 생성하는 것. 클래스의 관계를 설계하는 것.
            // 객체들 : 플레이어 ( player ) , 목적, 방해 요소(enemy, trab, 환경)

            // 플레이어가 처음에 소지금을 가지고 게임을 시작합니다. 이 플레이어는 특정 기간마다 빚을 변제해야 합니다.
            // 플레이어는 아이템을 특정한 소비자에게 판매할 수 있습니다. 소비자는 아이템의 선호도가 존재해서, 소비자마다 판매할수 있는 금액이 다릅니다. (정보)
            // 위의 내용으로 게임을 만든다고 가정했을 때, 이 게임에 필요한 클래스를 아래에 정의를 해보세요.
            // 객체 : 플레이어 ( 소지금, 남은 빚 변제 기간, 만난 고객 정보)
            // 빚 ( 수치, 이벤트)
            // 고객 ( 등급, 소지금 )
            // 아이템(고객마다 원하는 종류가 다양하다)
            // 재화 ( 획득 경로 : 도박장, 공사장, 회사)
            // 기간 ( 빚이 클수록 빚을 갚는 기간이 길어지고 작을수록 빚을 갚는 기간이 짧아진다)

            // 3. 게임에 등장할 요소(클래스) 어느 정도 구현하였으면, 게임에 등장시켜야 합니다.
            // 어디에 그 코드를 작성하는가? main함수에서 코드가 실행된다. 만들어 놓은 클래스를 이 함수에서 다시 호출한다.
            // 6가지 클래스를 사용해서 게임을 메인함수에 플레이가 되도록 만들어줘


            // 1. 게임 초기화
            Console.WriteLine("Welcome to the Debt Repayment Simulator!");

            // 빚의 크기에 따라 기간이 결정됩니다.
            int initialDebt = 7000;

            var player = new Player(100, 0);
            var debt = new Debt(initialDebt, 0.05);
            var time = new Time(initialDebt);

            // Time 클래스에 따라 플레이어의 남은 기간을 초기화합니다.
            player.SetRepaymentDays(time.DaysLeft);

            // 아이템과 고객 생성
            var sword = new Item("Sword", "Weapon", 150);
            var potion = new Item("Potion", "Consumable", 40);
            var customers = new List<Consumer>
        {
            new Consumer("Alice", "Common", 200, new Dictionary<string, double> { { "Potion", 1.2 } }),
            new Consumer("Bob", "Rich", 1000, new Dictionary<string, double> { { "Sword", 1.8 } })
        };

            // 플레이어에게 아이템 지급 (게임 시작 아이템)
            var playerItems = new List<Item> { sword, potion };

            // 재화 획득처 생성
            var casino = new CurrencySource("Casino", "Gambling");
            var constructionSite = new CurrencySource("Construction Site", "Labor");

            // 2. 게임 루프 시작
            while (player.DebtRepaymentDaysLeft > 0 && debt.Amount > 0)
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"Day {time.DaysLeft} Left!");
                Console.WriteLine($"Current Status: {player}");
                Console.WriteLine($"Current Debt: ${debt.Amount}");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("What will you do today?");
                Console.WriteLine("1. Sell an item to a customer");
                Console.WriteLine("2. Earn money at a currency source");
                Console.WriteLine("3. Pay a portion of the debt");
                Console.WriteLine("4. Do nothing and pass the day");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // 아이템 판매 로직
                        if (playerItems.Count == 0)
                        {
                            Console.WriteLine("You have no items to sell.");
                            break;
                        }
                        Console.WriteLine("Select an item to sell:");
                        for (int i = 0; i < playerItems.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {playerItems[i].Name} (Base Value: ${playerItems[i].BaseValue})");
                        }
                        int itemIndex = int.Parse(Console.ReadLine()) - 1;

                        Console.WriteLine("Select a customer:");
                        for (int i = 0; i < customers.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {customers[i].Name} (Tier: {customers[i].Tier})");
                        }
                        int customerIndex = int.Parse(Console.ReadLine()) - 1;

                        Item itemToSell = playerItems[itemIndex];
                        Consumer selectedConsumer = customers[customerIndex];
                        int price = selectedConsumer.GetPriceFor(itemToSell);

                        if (selectedConsumer.CanAfford(price))
                        {
                            player.AddMoney(price);
                            playerItems.RemoveAt(itemIndex);
                            player.AddMetConsumer(selectedConsumer);
                            Console.WriteLine($"You sold {itemToSell.Name} to {selectedConsumer.Name} for ${price}.");
                        }
                        else
                        {
                            Console.WriteLine($"{selectedConsumer.Name} cannot afford that item.");
                        }
                        break;

                    case "2":
                        // 재화 획득 로직
                        Console.WriteLine("Select a place to earn money:");
                        Console.WriteLine("1. Casino");
                        Console.WriteLine("2. Construction Site");
                        int sourceChoice = int.Parse(Console.ReadLine());

                        CurrencySource selectedSource = sourceChoice == 1 ? casino : constructionSite;
                        int earnedMoney = selectedSource.GetMoney();
                        player.AddMoney(earnedMoney);
                        Console.WriteLine($"You earned ${earnedMoney} from the {selectedSource.Name}.");
                        break;

                    case "3":
                        // 빚 변제 로직
                        Console.Write("Enter amount to pay: ");
                        if (int.TryParse(Console.ReadLine(), out int payAmount) && payAmount > 0)
                        {
                            if (player.Money >= payAmount)
                            {
                                player.AddMoney(-payAmount); // 소지금에서 차감
                                debt.Pay(payAmount);
                                Console.WriteLine($"You successfully paid ${payAmount} of your debt.");
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough money.");
                            }
                        }
                        break;

                    case "4":
                        Console.WriteLine("You decided to rest for the day.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Skipping to next day.");
                        break;
                }

                // 하루가 지나면 시간이 줄어들고 빚에 이자가 붙습니다.
                time.PassDay();
                player.DecreaseDaysLeft();
                debt.ApplyInterest();
                debt.TriggerEvent();
            }

            // 3. 게임 종료
            Console.WriteLine("\n--- Game Over ---");
            if (debt.Amount <= 0)
            {
                Console.WriteLine("Congratulations! You have successfully paid off all your debt.");
            }
            else
            {
                Console.WriteLine("Time is up! You failed to pay off your debt.");
            }
            Console.WriteLine($"Final Status: {player}");
            Console.WriteLine($"Remaining Debt: ${debt.Amount}");
        
    }
    }
}
