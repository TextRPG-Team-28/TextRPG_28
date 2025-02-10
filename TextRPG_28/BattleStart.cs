using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_28.Character;

namespace TextRPG_28
{
    internal class BattleStart 
    {
        public List<Character.Monster> currentMonsters = new List<Character.Monster>();
        public void Battle(Character.Player player, List<Character.Monster> monsterList)
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n\n");

            NumberOfMonsters(monsterList, 4);
            
            Console.WriteLine("\n\n\n[내 정보]");
            Console.WriteLine($"Lv.{player.Level}   {player.Name} (전사)");
            Console.WriteLine($"HP {player.Health} / {player.Health}"); // 현재 체력 / 원래 체력 전투할 때 나눠줘야 함. 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. 공격\n\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");

            while (true)
            {
                string Choice = Console.ReadLine();

                if (!int.TryParse(Choice, out int yourChoice) || (yourChoice != 1))
                {

                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    AttackScene(player);
                    break;
                }
            }
        }
        public void NumberOfMonsters(List<Monster> monsterList, int count)
        {
            Random random = new Random();
            int number = random.Next(1, count + 1);  
            
            currentMonsters.Clear();
            
            for (int i = 0; i < number; i++)
            {
                int stageMonster = random.Next(0, monsterList.Count);  
                Console.WriteLine($"Lv.{monsterList[stageMonster].Level}  {monsterList[stageMonster].Name}  HP {monsterList[stageMonster].Health}");
                currentMonsters.Add(monsterList[stageMonster]);  
            }
        }

        public void AttackScene(Character.Player player)
        {
            Console.Clear();

            Console.WriteLine("Battle!!\n\n");
            for (int i = 0;i < currentMonsters.Count;i++)
            {
                Console.WriteLine($"{i+1}  Lv.{currentMonsters[i].Level} {currentMonsters[i].Name}  HP {currentMonsters[i].Health} ");
            }

            Console.WriteLine("\n\n\n[내 정보]");
            Console.WriteLine($"Lv.{player.Level}   {player.Name} (전사)");
            Console.WriteLine($"HP {player.Health} / {player.Health}");  
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("0. 취소\n\n");
            Console.Write("대상을 선택해주세요\n>>");

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
                    gameStart.StartScene(player, new List<Character.Monster>());
                    break;
                }
                else
                {
                    AllAttack allAttack = new AllAttack();
                    allAttack.AttackStart(player, currentMonsters, yourChoice);
                }
            }
        }
    }    
}
