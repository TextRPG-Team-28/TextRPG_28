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
        public void StartScene(Warrior warrior, List<Character.Monster> monsterList)
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요 \n>>");

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
                            ShowStatus(warrior);
                            break;
                        case 2:
                            BattleStart battleStart = new BattleStart();
                            battleStart.Battle(warrior, monsterList);
                            break;
                        
                    }

                    break;
                }                
            }            
        }

        public void ShowStatus(Character.Warrior warrior)
        {
            Console.Clear();
            Console.WriteLine("--상태 보기--");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine($"Lv. {warrior.Level}");
            Console.WriteLine($"{warrior.Name} ( 전사 )");
            Console.WriteLine($"공격력: {warrior.Attack}");
            Console.WriteLine($"방어력: {warrior.Defend}");
            Console.WriteLine($"체력: {warrior.Health}");
            Console.WriteLine($"Gold: {warrior.Gold} G\n");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요 \n>>");



            while (true)
            {
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int yourInput) || yourInput != 0)
                {
                    Console.WriteLine("0을 누르세요.");
                }
                else if (yourInput == 0)
                {
                    StartScene(warrior, new List<Character.Monster>());
                    break;
                }
            }
        }
    }

    
}
