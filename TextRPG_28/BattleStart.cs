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
        Scene scene = new Scene();
        AllAttack allAttack = new AllAttack();

        public void Battle(Character.Player player, List<Character.Monster> monsterList)
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n\n");

            NumberOfMonsters(monsterList, 4);
            
            Console.WriteLine("\n\n\n[내 정보]");
            Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.Health} / {player.MaxHealth}"); // 현재 체력 / 원래 체력 전투할 때 나눠줘야 함. 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. 공격\n0. 마을로 돌아가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int yourChoice = Select.GetInput(0, 1);

            switch (yourChoice)
            {
                case 0:
                    Scene scene = new Scene();
                    scene.StartScene(player, new List<Character.Monster>());
                    break;
                case 1:
                    AttackScene(player);
                    break;
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
            Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.Health} / {player.MaxHealth}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("0. 도망치기\n\n");
            Console.Write("대상을 선택해주세요\n>> ");

            int yourChoice = Select.GetInput(0, currentMonsters.Count);

            switch (yourChoice)
            {
                case 0:
                    scene.StartScene(player, new List<Character.Monster>());
                    break;
                default:
                    allAttack.AttackStart(player, currentMonsters, yourChoice);                   
                    break;
            }

            Select.GetInput(0, 0);
            allAttack.EnemyPhase(player, currentMonsters);

            //while (true)
            //{
            //    string Choice = Console.ReadLine();

            //    if (!int.TryParse(Choice, out int yourChoice) || (yourChoice < 0 || yourChoice > currentMonsters.Count))
            //    {
            //        Console.WriteLine("잘못된 입력입니다.");
            //    }
            //    else if (yourChoice == 0)
            //    {

            //        scene.StartScene(player, new List<Character.Monster>());
            //        break;
            //    }
            //    else
            //    {
            //        AllAttack allAttack = new AllAttack();
            //        allAttack.AttackStart(player, currentMonsters, yourChoice);
            //        allAttack.EnemyPhase(player, currentMonsters);
            //    }
            //}
        }
    }    
}
