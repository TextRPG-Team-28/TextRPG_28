using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    public class Attack
    {
        public bool PlayerAttack(Player player, List<Monster> monsters, int monsterNumber, bool b)
        {
            Monster targetMonster = monsters[monsterNumber - 1];
            Random random = new Random();
            int miss = random.Next(1, 100);

            if (targetMonster.isDead == false)
            {
                Console.Clear();
                Console.WriteLine("Battle!!\n\n");
                Console.WriteLine($"{player.Name} 의 공격!");

                if (miss < 10)
                {
                    Console.WriteLine($"{targetMonster.Name} 을(를) 공격 했지만 아무도 일어나지 않았습니다.");

                }
                else
                {
                    int damage = isAttack(targetMonster, player);
                    int maxHp = targetMonster.Hp;
                    string deadMark = targetMonster.Hp - damage <= 0 ? "Dead" : $"{targetMonster.Hp - damage}";

                    monsters[monsterNumber - 1].Hp = targetMonster.Hp - damage;
                    if (monsters[monsterNumber - 1].Hp <= 0)
                    {
                        monsters[monsterNumber - 1].isDead = true;
                        player.Exp += targetMonster.Exp;
                    }
                    Console.WriteLine($"Lv.{targetMonster.Level} {targetMonster.Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
                    Console.WriteLine("\n");
                    Console.WriteLine($"Lv. {targetMonster.Level} {targetMonster.Name}");
                    Console.WriteLine($"HP {maxHp}  -> {deadMark}");
                    Console.WriteLine("\n");
                }
                Console.WriteLine("0. 다음");
                Console.Write(">> ");
                b = false;
            }
            else
            {  
                Console.WriteLine("이미 죽엇음");
                Console.WriteLine("다시 선택해주세요");
                Console.Write(">> ");
            }
            return b;
        }

        public void MonsterAttack(Player player, List<Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n\n");

            int currentPlayerHP = player.Hp;

            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].Hp > 0)
                {
                    Console.WriteLine($"Lv.{monsters[i].Level} {monsters[i].Name}의 공격!");
                    Console.WriteLine($"{player.Name} 을(를) 맞췄습니다.  [데미지 : {monsters[i].Attack}]");
                    Console.WriteLine("\n");

                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    player.Hp -= monsters[i].Attack;
                    Console.WriteLine($"HP {currentPlayerHP} -> {player.Hp}");
                    Console.WriteLine("\n");
                }
            }
            Console.WriteLine("0. 다음");
        }

        public int isAttack(Monster monster, Player player)
        {
            int max;
            int min;
            float x = player.Attack * 0.9f;
            float y = player.Attack * 1.1f;

            min = (int)(x + 0.5f);
            max = (int)(y + 0.5f);

            Random random = new Random();
            int currentAttack = random.Next(min, max + 1);
            return currentAttack;
        }


    }
}
