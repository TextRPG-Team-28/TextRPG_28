using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_28.Character;

namespace TextRPG_28
{
    internal class GameStart
    {
        public void StartScene(Player player, List<Character.Monster> monsterList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("원하시는 행동을 입력해주세요 \n>>");
            Console.ResetColor();

            while (true)
            {
                string Choice = Console.ReadLine();

                if (!int.TryParse(Choice, out int yourChoice) || (yourChoice > 3 || yourChoice < 1))
                {

                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    switch (yourChoice)
                    {
                        case 1:
                            ShowStatus(player);
                            break;
                        case 2:
                            BattleStart battleStart = new BattleStart();
                            battleStart.Battle(player, monsterList);
                            break;                        
                    }
                    break;
                }                
            }            
        }

        public void ShowStatus(Character.Player player)
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine("--상태 보기--");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ( 전사 )");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"공격력: {player.Attack}");
            Console.WriteLine($"방어력: {player.Defend}");
            Console.WriteLine($"체력: {player.Health}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Gold: {player.Gold} G\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요 \n>>");
            Console.ResetColor();

            while (true)
            {
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int yourInput) || yourInput != 0)
                {
                    Console.WriteLine("0을 누르세요.");
                }
                else if (yourInput == 0)
                {
                    StartScene(player, new List<Character.Monster>());
                    break;
                }
            }
        }
    }   
}
