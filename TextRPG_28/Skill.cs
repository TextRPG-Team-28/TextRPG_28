using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    internal class Skill
    {
        public void PlayerSkill(Player player, List<Monster> monsters, int monsterNumber)      // 대상을 선택하는 1번 스킬만 해당되는 동작.
        {
            Monster targetMonster = monsters[monsterNumber - 1];

            if (targetMonster.isDead == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("던전\n");
                Console.ResetColor();
                Console.WriteLine($"{player.Name} 의 스킬공격!");

                int damage = isSkill(targetMonster, player);
                int maxHp = targetMonster.Hp;
                string deadMark = targetMonster.Hp - damage <= 0 ? "Dead" : $"{targetMonster.Hp - damage}";

                monsters[monsterNumber - 1].Hp = targetMonster.Hp - damage;
                

                if (monsters[monsterNumber - 1].Hp <= 0)
                {
                    monsters[monsterNumber - 1].isDead = true;
                }

                    Console.WriteLine($"Lv.{targetMonster.Level} {targetMonster.Name} 에게 알파 스파이크 스킬을 사용했습니다!! [데미지 : {damage}]");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Lv. {targetMonster.Level} {targetMonster.Name}");
                    Console.WriteLine($"HP {maxHp}  -> {deadMark}");
                    Console.WriteLine($"현재 {player.Name}의 MP :{player.Mp}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("0. 다음");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("이미 죽은 몬스터 입니다.");
                Console.WriteLine("다시 선택해주세요.");
                Console.Write(">> ");
            }
            
        }

        public void AllSkill()
        {
            void skill_1()
            {


            }
        }

        public int isSkill(Monster monster, Player player)
        {
            int damage = player.Attack * 2;
            player.Mp -= 10;

            return damage;
        }
    }
}
