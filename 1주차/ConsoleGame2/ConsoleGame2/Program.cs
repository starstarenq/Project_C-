using System.Numerics;
using ConsoleGame2;
using Project_1_GameFlow;
using System;
using System.Threading;
namespace ConsoleGame2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 프로그래밍 언어의 기본 문법
            Player myPlayer = new Player(100.0f, 15.5f);

            #region 기본 문법 - 변수
            // 변수 : 특정 타입의 데이터를 메모리에 저장해서 다시 사용하는 데이터.
            // 정수, 실수(부동소수점), 문자
            // 타입뒤에 변수를 구분하기 위한 이름을 지어준다.

            // 내가 정수를 사용하고 싶다. Int
            // 내가 실수를 사용하고 싶다. float
            // 내가 문자열을 사용하고 싶다. string
            // 내가 문자를 사용하고 싶다. char

            //정수의 이름 : playerHP
            //실수의 이름 : Time 시간을 초단위로 표현
            //문자열의 이름 : title
            //문자의 이름 : myChar

            // 변수의 선언 및 초기화

            // (1) AI 만들어준 데이터를 다른 데이터로 바꾸어 보세요.
            // (2) AI 질문을 할 때 변수의 이름과 타입을 지정해서 질문하세요.
            // ex) 플레이어의 체력과 공격력의 변수의 이름은 playerHP , playerATK 타입 int, float, string, char
            int num1 = 10;
            float unmfloat = 1.1f;
            string myStrnig = "안녕!";
            char myChar = 'A';

            int playerHP = 100;
            float Time = 30.5f;
            string title = "게임 제목";
            char mychar = 'B';
            #endregion
            #region 프로그래밍 언어의 기본 문법 - 메소드(함수){

            // 기본 형태
            //접근지정자 리턴타입 함수이름(타입 변수이름)
            // public void MethodName(int num)


            // C#에서의 특징
            // 1. 메소드는 클래스 안에서 정의되어야 한다.
            // 2. 메소드의 선언과 사용 방식이 다르다.
            // 2-1 선언은 구현되지 않은 내용을 직접 정의하는 것이다. 범위로 표현을 해준다.
            // 함수 선언 이후 중괄호로 내용을 표시한다.
            // 2-2 정의된 함수를 사용하기 위해서는 함수의 이름과 소괄호를 함께 호출한다.

            //함수를 만들어줘. 접근 지정자를 public, 반환 타입을 void로 함수 이름을 pln 만들어줘. 매개 인자를 누락


            // 콘솔 환경, 언어는 c#, 특정 문자열의 색상을 다른 색상으로 변경해주는 함수를 만들어줘.
            // 접근 지정자는 public, 반환 값은 너가 정해줘, 함수의 이름 SetTextColor로, 매개 변수를 색상의 이름으로 받을 수 있도록 타입을 string 변수 이름 color로 만들어줘


            #endregion



            #endregion

            #region 게임 개발 영역
            //주석: 컴퓨터가 읽지못하는 영역입니다.
            // 내용을 정리하거나, 코드를 읽는 다른 사람을 배려해서 작성하는 영역.

            //단축키
            //ctrl + k + c 범위 주석 활성화
            //ctrl + k + u 범위 주석 비활성화
            //shift + alt +키보드 방향이 위,아래

            #region 타이틀

            //1. 타이틀
            //"C# 작성을 할 것이다. 콘솔 환경에서 타이틀을 만들어줘.
            //콘송 창의 타이틀을 설정합니다.
            //타이틀은 게임 화면에 이미지와 게임 시작 버튼으로 이루어 져있는 영역이다.





            // 콘솔 창 크기 및 색상 설정
            Console.SetWindowSize(80, 25);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();


            // 텍스트를 파란색으로 변경하여 출력
            SetTextColor("blue");
            Console.WriteLine("이 텍스트는 파란색입니다.");

            // 텍스트를 초록색으로 변경하여 출력
            SetTextColor("green");
            Console.WriteLine("이 텍스트는 초록색입니다.");

            // 텍스트를 빨간색으로 변경하여 출력
            SetTextColor("red");
            Console.WriteLine("이 텍스트는 빨간색입니다.");

            // 잘못된 색상 이름을 입력했을 때
            SetTextColor("purple"); // 지원하지 않는 색상
            Console.WriteLine("이 텍스트는 기본 색상으로 출력됩니다.");

            // 색상을 원래대로 되돌리기
            Console.ResetColor();
            Console.WriteLine("\n이 텍스트는 원래의 기본 색상으로 돌아왔습니다.");
            // 타이틀 화면 표시
            DisplayTitleScreen();

            // 게임 시작 대기
            WaitForStart();   // 콘솔 창의 타이틀을 "My Console App"으로 설정합니다.

            Console.Title = "My Console App";

            // 타이틀이 잘 설정되었는지 확인하기 위해 메시지를 출력합니다.
            Console.WriteLine("Console title has been set!");
            Console.WriteLine("Press any key to exit.");

            // 사용자의 입력을 기다립니다.
            Console.ReadKey();
            // 콘솔 창 설정
            Console.Title = "Simple Console RPG";
            Console.SetWindowSize(50, 15);
            Console.CursorVisible = false; // 커서 숨기기

            // 플레이어 캐릭터 생성 (이름, 최대 체력, 공격력)
            Player player = new Player("영웅", 100, 15);

            // UI를 계속 업데이트하는 루프
            while (true)
            {
                player.DisplayStatus();
                Thread.Sleep(500); // 0.5초마다 화면 갱신

                // 예시: 체력이 10씩 줄어들게 하여 체력바 변화 확인
                if (player.Health > 0)
                {
                    player.Health = 100;
                }
                else
                {
                    player.Health = player.MaxHealth; // 체력이 0이 되면 다시 풀피로 회복
                }
            }

            /// <summary>
            /// 게임 타이틀 화면을 그리는 함수입니다.
            /// </summary>
            static void DisplayTitleScreen()
            {  // ASCII 아트를 이용한 타이틀 로고
                string title = @"
                  ==================================================
                 _______   __   __   _______   __       __   _______
                |  _    | |  | |  | |  _    | |  |     |  | |  _    |
                | |_)   | |  | |  | | | |   | |  |     |  | | |_)   |
                |      /  |  |_|  | | | |   | |  |___  |  | |      /
                |  _  \   |       | | |_|   | |      | |  | |  _  \
                | |_)  |  |       | |       | |   _  | |  | | |_)  |
                |_______| |_______| |_______| |__|\__| |__| |_______|
                  ==================================================";

                Console.SetCursorPosition(10, 5);
                Console.WriteLine(title);

                // 게임 시작 버튼 역할의 텍스트
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(30, 18);
                Console.WriteLine("시작을 위해 'Enter'를 눌러 주십시오.");

                Console.ResetColor();
                /// <summary>
                /// 사용자의 'Enter' 키 입력을 기다리는 함수입니다.
                /// </summary>
            }
            static void WaitForStart()
            {
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                } while (key.Key != ConsoleKey.Enter);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(30, 12);
                Console.WriteLine("게임을 시작합니다...");
                Console.ResetColor();
            }
            #endregion

            #region 캐릭터

            //2. 캐릭터
            // 캐릭터는 체력, 공격력, 방어력 존재한다.
            // 게임 캐릭터의 체력과 공격력을 설정한 후 콘솔환경에서 UI로 화면에 떠오르게 만들어줘. 
            int playerHealth = 100;
            float playerAttack = 10.5f;

            // Player 클래스 인스턴스 생성
            // 초기 체력 100.0f, 초기 공격력 15.5f로 설정



            // 플레이어의 상태 출력
            myPlayer.DisplayStatus();

            // 예시: 체력과 공격력 값 변경
            Console.WriteLine("\n플레이어의 속성 변경...");
            myPlayer.HP = 85.5f;
            myPlayer.ATK = 18.0f;

            // 변경된 상태 출력
            myPlayer.DisplayStatus();
        }



        /// <summary>
        /// 플레이어의 상태를 콘솔에 UI 형태로 표시하는 함수
        /// </summary>
        #endregion

        #region 전투
        //3. 전투


        public class Monster
        {
            public string Name { get; set; }
            public float HP { get; set; }
            public float ATK { get; set; }

            public Monster(string name, float hp, float atk)
            {
                Name = name;
                HP = hp;
                ATK = atk;
            }

            public void DisplayStatus()
            {
                Console.WriteLine($"\n--- {Name}의 상태 ---");
                Console.WriteLine($"체력(HP): {HP:F1}");
                Console.WriteLine($"공격력(ATK): {ATK:F1}");
                Console.WriteLine("---------------------");
            }
        }

     
     
        #endregion
        #region 보상
        //4. 보상
        #endregion
        #region 성장
        //5. 성장
        #endregion
        #region 스토리
        //6. 스토리 
        #endregion
        #endregion

        static void SetTextColor(string color)
            {
                // 입력된 색상 이름을 소문자로 변환하여 비교
                string lowerCaseColor = color.ToLower();

                switch (lowerCaseColor)
                {
                    case "red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "green":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "blue":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "cyan":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "white":
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        // 지원하지 않는 색상일 경우 기본값으로 되돌림
                        Console.ResetColor();
                        Console.WriteLine($"Warning: The color '{color}' is not supported. Reverting to default color.");
                        break;
                }
            }
        }
    }


