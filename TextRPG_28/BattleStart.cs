using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_28.Character;

namespace TextRPG_28
{
    internal class BattleStart 
    {
        List<Monster> currentMonsters = new List<Monster>();
        public void Battle(Warrior warrior)
        {       
            Console.Clear();
            Console.WriteLine("Battle!!\n\n");

            NumberOfMonsters(4);
            
            Console.WriteLine("\n\n\n[내 정보]");
            Console.WriteLine($"Lv.{warrior.Level}   {warrior.Name} (전사)");
            Console.WriteLine($"HP {warrior.Health} / {warrior.Health}"); // 현재 체력 / 원래 체력 전투할 때 나눠줘야 함. 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. 공격\n\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");
            while (true)
            {
                string Choice = Console.ReadLine();

                if (!int.TryParse(Choice, out int yourChoice) || (yourChoice != 1))
                {

                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    Attack(warrior);
                    break;
                }
            }
        }
        public void NumberOfMonsters(int count)
        {
            Monster[] monsterArray = new Monster[3];
            monsterArray[0] = new Monster("미니언", 2, 5, 15);
            monsterArray[1] = new Monster("공허충", 3, 9, 10);
            monsterArray[2] = new Monster("대포 미니언", 5, 8, 25);

            Random ramdom1 = new Random();
            int number = ramdom1.Next(1, count);
            

            for (int i = 0; i < number; i++)
            {
                Random ramdon = new Random();
                int stageMonster = ramdon.Next(0, 3);
                Console.WriteLine($"Lv.{monsterArray[stageMonster].Level}  {monsterArray[stageMonster].Name}  HP {monsterArray[stageMonster].Health}");
                currentMonsters.Add(monsterArray[stageMonster]);
            }

            

        }

        public void Attack(Warrior warrior)
        {
            Console.Clear();

            Console.WriteLine("Battle!!\n\n");
            for (int i = 0;i < currentMonsters.Count;i++)
            {
                Console.WriteLine($"{i+1}  Lv.{currentMonsters[i].Level} {currentMonsters[i].Name}  HP {currentMonsters[i].Health} ");
            }

            Console.WriteLine("\n\n\n[내 정보]");
            Console.WriteLine($"Lv.{warrior.Level}   {warrior.Name} (전사)");
            Console.WriteLine($"HP {warrior.Health} / {warrior.Health}");  
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("0. 취소\n\n");
            Console.WriteLine("대상을 선택해주세요\n>>");

            while (true)
            {
                string Choice = Console.ReadLine();

                if (!int.TryParse(Choice, out int yourChoice) || (yourChoice < 0 || yourChoice > currentMonsters.Count))
                {

                    Console.WriteLine("잘못된 입력입니다.");
                }
                else if (yourChoice == 0)
                {
                    GameStart gameStart = new GameStart();
                    gameStart.StartScene(warrior);
                    break;
                }
            }
        }


    }

 
    
}
