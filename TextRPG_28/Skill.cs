using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    internal class Skill
    {
        public int SelectSkill(int skillNumber)
        {
            return skillNumber;
        }
        public bool SkillAttack(Player player, List<Monster> monsters, int monsterNumber, int skillNumber, bool b)      // 플레이어의 공격
        {
            Monster targetMonster = monsters[monsterNumber - 1];

            if (skillNumber == 2) 
            {
                Random random = new Random();
                int randomNumber = random.Next(0, monsters.Count);
            }
            else if (skillNumber == 3)
            {
               
            }

            if (targetMonster.isDead == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("던전\n");
                Console.ResetColor();
                Console.WriteLine($"{player.Name} 의 스킬!");

                int damage =  isSkill(player, skillNumber);
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

                    string criticalMark = damage > 15 ? "- 스킬 공격!!" : "";

                    Console.WriteLine($"Lv.{targetMonster.Level} {targetMonster.Name} 을(를) 맞췄습니다. [데미지 : {damage}] {criticalMark}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Lv. {targetMonster.Level} {targetMonster.Name}");
                    Console.WriteLine($"HP {maxHp}  -> {deadMark}");
                    Console.WriteLine();

                    Console.WriteLine($"MP {player.MaxMp}  -> {player.Mp}");
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

        public int isSkill( Player player, int skillNumber)     // 공격 관리
        {
            float skillDamage = 0;

            if (skillNumber == 1)
            {
                skillDamage = player.Attack * 2f;
                player.Mp -= 10;
            }
            else if (skillNumber == 2)
            {
                skillDamage = player.Attack * 1.5f;
            }
            else if (skillNumber == 3)
            {
                skillDamage = player.Attack * 1.2f;
            }

            return (int)skillDamage;
        }
    }
}
