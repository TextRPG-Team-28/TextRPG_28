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
    internal class AllAttack : BattleStart
    {
        public void SceneAttack(Warrior warrior, List<Monster> monsters, int monsterNumber)
        {

            for ( int i = 0; i < monsters.Count; i++ )
            {
                Console.WriteLine($"");
            }
            Console.Clear();
            Console.WriteLine("Battle!!\n\n");
            Console.WriteLine($"{warrior.Name} 의 공격!");
            Console.WriteLine($"Lv.{monsters[monsterNumber -1].Level} {monsters[monsterNumber -1].Name} 을(를) 맞췄습니다. [데미지 : {warrior.Attack}]");
            Console.WriteLine("\n");
            Console.WriteLine($"Lv. {monsters[monsterNumber - 1].Level} {monsters[monsterNumber - 1].Name}");
            Console.WriteLine($"HP {monsters[monsterNumber - 1].Health}  ->  ");

            

            

            
        }
    }
}
