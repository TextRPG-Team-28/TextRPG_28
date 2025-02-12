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
        public bool PlayerAttack(Player player, List<Monster> monsters, int monsterNumber, bool b)      // 플레이어의 공격
        {
            Monster targetMonster = monsters[monsterNumber - 1];

            if (targetMonster.isDead == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"던전 - {player.Name} 의 턴\n");
                Console.ResetColor();
                Console.WriteLine($"{player.Name} 의 공격!");

                int damage = isAttack(targetMonster, player);
                int maxHp = targetMonster.Hp;
                string deadMark = targetMonster.Hp - damage <= 0 ? "Dead" : $"{targetMonster.Hp - damage}";

                monsters[monsterNumber - 1].Hp = targetMonster.Hp - damage;

                if (monsters[monsterNumber - 1].Hp <= 0)
                {
                    monsters[monsterNumber - 1].isDead = true;
                    b = true;
                }

                if (damage > 0)
                {
                    string criticalMark = damage > 15 ? "- 치명타 공격!!" : "";
                    Console.WriteLine($"Lv.{targetMonster.Level} {targetMonster.Name} 을(를) 맞췄습니다. [데미지 : {damage}] {criticalMark}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Lv. {targetMonster.Level} {targetMonster.Name}");
                    Console.WriteLine($"HP {maxHp}  -> {deadMark}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("0. 다음");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");
                }
                else
                {
                    Console.WriteLine($"Lv.{targetMonster.Level} {targetMonster.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("0. 다음");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");
                }
                b = false;
            }
            else
            {
                b = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("이미 죽은 몬스터 입니다.");
                Console.WriteLine("다시 선택해주세요.");
                Console.Write(">> ");
            }
            return b;
        }

        public int MonsterAttack(Player player, List<Monster> monsters, int deadCount)      // 몬스터의 공격
        {  
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("던전 - 몬스터의 턴\n");
            Console.ResetColor();

            int currentPlayerHP = player.Hp;

            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].Hp > 0)
                {
                    Console.WriteLine($"Lv.{monsters[i].Level} {monsters[i].Name}의 공격!");
                    Console.WriteLine();
                    Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지 : {monsters[i].Attack}]");
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    if(player.Hp > 0)
                        player.Hp -= monsters[i].Attack;
                    else
                        player.Hp = 0;
                    Console.WriteLine($"HP {currentPlayerHP} -> {player.Hp}");
                    Console.WriteLine();
                    Console.ResetColor();
                    if (player.Hp <= 0)
                    {
                        player.isDead = true;
                        player.Hp = 0;
                    }
                }
                else
                {
                    deadCount--;
                }
            }
            if (deadCount > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("0. 다음");
            }
            else 
            {
                Console.ResetColor();
                Console.WriteLine("모든 몬스터를 죽였습니다!!!");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("0. 다음");
            }
            return deadCount;
        }

        public int isAttack(Monster monster, Player player)     // 공격 관리
        {
            int critical;
            Random criticalDamage = new Random();
            critical = criticalDamage.Next(1, 101);
            if (critical <= 15)
            {
                float criticalAttack = player.Attack * 1.6f;
                int cA = (int)criticalAttack;
                return cA;
            }
            else if (critical > 90)
            {
                return 0;
            }
            else
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
}
