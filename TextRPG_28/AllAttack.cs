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
        public void AttackStart(Character.Warrior warrior, List<Character.Monster> monsters, int monsterNumber)
        {

            Console.Clear();
            Console.WriteLine("Battle!!\n\n");
            Console.WriteLine($"{warrior.Name} 의 공격!");

            Character.Monster targetMonster = monsters[monsterNumber - 1];
            int damage = WarriorAttack(targetMonster, warrior);
            

            Console.WriteLine($"Lv.{targetMonster.Level} {targetMonster.Name} 을(를) 맞췄습니다. [데미지 : {warrior.Attack}]");
            Console.WriteLine("\n");
            Console.WriteLine($"Lv. {targetMonster.Level} {targetMonster.Name}");
            Console.WriteLine($"HP {targetMonster.Health}  ->  ");



        }

        public int WarriorAttack(Character.Monster monster, Character.Warrior warrior)
        {
            int max;
            int min;
            float x = warrior.Attack * 0.9f;
            float y = warrior.Attack * 1.1f;

            min = (int)(x + 0.5f);
            max = (int)(y + 0.5f);

            Random random = new Random();
            int currentAttack = random.Next(min, max+1);
            return currentAttack;


        }
    }
}
