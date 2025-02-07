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
        public void StartScene(Warrior warrior)
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
                            battleStart.Battle(warrior);
                            break;
                        
                    }

                    break;
                }                
            }            
        }

        public void ShowStatus(Warrior warrior)
        {
            Console.Clear();
            Console.WriteLine("--상태 보기--");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            int pulsAttack = 0, pulsDefense = 0, pulsHealth = 0;

            //나중에 아이템 만들면 착용 장비 리스트 만들어서 추가되게 만들어줘야함.

            string pulsAttackMark = (pulsAttack > 0) ? $"(+ {pulsAttack})" : "";
            string pulsDefenseMark = (pulsDefense > 0) ? $"(+ {pulsDefense})" : "";
            string pulsHealthMark = (pulsHealth > 0) ? $"(+ {pulsHealth})" : "";

            Console.WriteLine($"Lv. {warrior.Level}");
            Console.WriteLine($"{warrior.Name} ( 전사 )");
            Console.WriteLine($"공격력: {warrior.Attack + pulsAttack}  {pulsAttackMark}");
            Console.WriteLine($"방어력: {warrior.Defend + pulsDefense}  {pulsDefenseMark}");
            Console.WriteLine($"체력: {warrior.Health + pulsHealth}  {pulsHealthMark}");
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
                    StartScene(warrior);
                    break;
                }
            }
        }
    }

    
}
