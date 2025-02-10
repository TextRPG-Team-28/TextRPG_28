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
