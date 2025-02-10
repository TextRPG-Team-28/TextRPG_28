using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_28.Character;

namespace TextRPG_28
{
    internal class AllAttack 
    {
        public void AttackStart(Character.Player player, List<Character.Monster> monsters, int monsterNumber)
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n\n");
            Console.WriteLine($"{player.Name} 의 공격!");

            Character.Monster targetMonster = monsters[monsterNumber - 1];
            int damage = PlayerAttack(targetMonster, player);

            string deadMark = targetMonster.Health - damage <= 0 ? "Dead" : $"{targetMonster.Health - damage}";

            Console.WriteLine($"Lv.{targetMonster.Level} {targetMonster.Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
            Console.WriteLine("\n");
            Console.WriteLine($"Lv. {targetMonster.Level} {targetMonster.Name}");
            Console.WriteLine($"HP {targetMonster.Health}  -> {deadMark}");
        }

        public void EnemyPhase(Character.Player player, List<Character.Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n\n");

            int currentPlayerHP = player.Health;
            
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].Health > 0)
                {
                    Console.WriteLine($"Lv.{monsters[i].Level} {monsters[i].Name}의 공격!");
                    Console.WriteLine($"{player.Name} 을(를) 맞췄습니다.  [데미지 : {monsters[i].Attack}]");
                    Console.WriteLine("\n");

                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    player.Health -= monsters[i].Attack;
                    Console.WriteLine($"HP {currentPlayerHP} -> {player.Health}");
                    Console.WriteLine("\n");
                }   
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("0. 다음\n\n");
            Console.Write("대상을 선택해주세요. \n\n>> ");

            while (true)
            {
                string Choice = Console.ReadLine();

                if (!int.TryParse(Choice, out int yourChoice) || (yourChoice != 0))
                {

                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    BattleStart battleStart = new BattleStart();
                    battleStart.AttackScene(player);
                    break;
                }
            }

        }

        public int PlayerAttack(Character.Monster monster, Character.Player player)
        {
            int max;
            int min;
            float x = player.Attack * 0.9f;
            float y = player.Attack * 1.1f;

            min = (int)(x + 0.5f);
            max = (int)(y + 0.5f);

            Random random = new Random();
            int currentAttack = random.Next(min, max+1);
            return currentAttack;
        }

    }
}
