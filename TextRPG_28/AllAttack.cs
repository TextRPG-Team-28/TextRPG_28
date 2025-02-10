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
            int damage = WarriorAttack(targetMonster, player);

            if(targetMonster.Health - damage <= 0)
            {
                monsters.Remove(targetMonster); //Remove가 아니라 다른 걸로 바꿔야,, 리스트를 하나 만들까?
            }

            string deadMark = targetMonster.Health - damage <= 0 ? "Dead" : $"{targetMonster.Health - damage}";

            Console.WriteLine($"Lv.{targetMonster.Level} {targetMonster.Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
            Console.WriteLine("\n");
            Console.WriteLine($"Lv. {targetMonster.Level} {targetMonster.Name}");
            Console.WriteLine($"HP {targetMonster.Health}  -> {deadMark}");
        }

        public int WarriorAttack(Character.Monster monster, Character.Player player)
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

        public void Monsterattack(Character.Monster monster, Character.Player player)
        {
                Console.Clear();
                Console.WriteLine("Battle!!\n\n");
                Console.WriteLine($"{player.Name} 의 공격!");

               
                int damage = MonsterDamge(monster, player);

                if(player.Health - damage <= 0)
                {
                   // 패배 화면
                }
                Console.WriteLine($"Lv.{monster.Name} 이 {player.Name}  을(를) 맞췄습니다. [데미지 : {damage}]");
                Console.WriteLine("\n");
                Console.WriteLine($"Lv. {player.Level} {player.Name}");
                Console.WriteLine($"HP {player.Health}"); // 최대 hp 현재 hp가 나오게 
        }
        public int MonsterDamge(Character.Monster monster, Character.Player player)
        {
            int max;
            int min;
            float x = monster.Attack * 0.9f - player.Defend *0.1f;
            float y = monster.Attack * 1.1f - player.Defend *0.1f;

            min = (int)(x + 0.5f);
            max = (int)(y + 0.5f);

            Random random = new Random();
            int currentAttack = random.Next(min, max+1);
            return currentAttack;
        }
    }
    
}
