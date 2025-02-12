using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG_28
{
    internal class Skill
    {
        public bool Skill_1()
        {
<<<<<<< HEAD
            Console.WriteLine("스킬 1인타겟 공격력 2배  마나 10");
            return true;
        }

        public bool Skill_2()
        {
            Console.WriteLine("스킬 2인랜덤타겟 공격력 1.5배  마나 20");
            return true;
        }

        public bool Skill_3()
        {
            Console.WriteLine("스킬 3 전체타겟 공격력 1.2배  마나 30");
            return true;
=======
            return skillNumber;
        }

        public int isSkillDamage(Player player, int skillNumber)     // 공격 관리
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
                player.Mp -= 15;
            }
            else if (skillNumber == 3)
            {
                skillDamage = player.Attack * 1.2f;
                player.Mp -= 30;
            }

            return (int)skillDamage;
        }

        public bool SkillAttack1(Player player, List<Monster> monsters, int monsterNumber, int skillNumber, bool b)      // 플레이어의 공격
        {
            if (monsters[monsterNumber - 1].isDead == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("던전\n");
                Console.ResetColor();
                Console.WriteLine($"{player.Name} 의 스킬!");

                int damage = isSkillDamage(player, skillNumber);

                int maxHp = monsters[monsterNumber - 1].Hp;
                string deadMark = monsters[monsterNumber - 1].Hp - damage <= 0 ? "Dead" : $"{monsters[monsterNumber - 1].Hp - damage}";

                monsters[monsterNumber - 1].Hp = monsters[monsterNumber - 1].Hp - damage;

                if (monsters[monsterNumber - 1].Hp <= 0)
                {
                    monsters[monsterNumber - 1].isDead = true;
                    b = true;
                }

                if (damage > 0)
                {
                    Console.WriteLine($"Lv.{monsters[monsterNumber - 1].Level} {monsters[monsterNumber - 1].Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Lv. {monsters[monsterNumber - 1].Level} {monsters[monsterNumber - 1].Name}");
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
                    Console.WriteLine($"Lv.{monsters[monsterNumber - 1].Level} {monsters[monsterNumber - 1].Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
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

        public bool SkillAttack2(Player player, List<Monster> monsters, int skillNumber, bool b)
        {
            Console.Clear();

            Random random = new Random();
            int randomNumber;
            int randomNumber1 = 0;
            int randomNumber2 = 0;
            bool isRandom = true;

            List<Monster> aliveMonsters = new List<Monster>();
            aliveMonsters.Clear();

            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].isDead == false)
                {
                    aliveMonsters.Add(monsters[i]);
                }
            }

            while (isRandom)
            {
                if (aliveMonsters.Count >= 2)
                {
                    randomNumber1 = random.Next(0, aliveMonsters.Count);
                    randomNumber2 = random.Next(0, aliveMonsters.Count);

                    int damage = isSkillDamage(player, skillNumber);

                    int maxHp1 = aliveMonsters[randomNumber1].Hp;
                    int maxHp2 = aliveMonsters[randomNumber2].Hp;

                    string deadMark1 = aliveMonsters[randomNumber1].Hp - damage <= 0 ? "Dead" : $"{aliveMonsters[randomNumber1].Hp - damage}";
                    string deadMark2 = aliveMonsters[randomNumber2].Hp - damage <= 0 ? "Dead" : $"{aliveMonsters[randomNumber2].Hp - damage}";

                    aliveMonsters[randomNumber1].Hp = aliveMonsters[randomNumber1].Hp - damage;
                    aliveMonsters[randomNumber2].Hp = aliveMonsters[randomNumber2].Hp - damage;

                    if (aliveMonsters[randomNumber1].Hp <= 0)
                    {
                        aliveMonsters[randomNumber1].isDead = true;
                        b = true;
                    }

                    if (aliveMonsters[randomNumber2].Hp <= 0)
                    {
                        aliveMonsters[randomNumber2].isDead = true;
                        b = true;
                    }

                    if (damage > 0)
                    {
                        Console.WriteLine($"Lv.{aliveMonsters[randomNumber1].Level} {aliveMonsters[randomNumber1].Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
                        Console.WriteLine();
                        Console.WriteLine($"Lv.{aliveMonsters[randomNumber2].Level} {aliveMonsters[randomNumber2].Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"Lv. {aliveMonsters[randomNumber1].Level} {aliveMonsters[randomNumber1].Name}");
                        Console.WriteLine($"HP {maxHp1}  -> {deadMark1}");
                        Console.WriteLine();
                        Console.WriteLine($"Lv. {aliveMonsters[randomNumber2].Level} {aliveMonsters[randomNumber2].Name}");
                        Console.WriteLine($"HP {maxHp2}  -> {deadMark2}");
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
                        Console.WriteLine($"Lv.{aliveMonsters[randomNumber1].Level} {aliveMonsters[randomNumber1].Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
                        Console.WriteLine($"Lv.{aliveMonsters[randomNumber2].Level} {aliveMonsters[randomNumber2].Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
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
                    randomNumber = random.Next(0, aliveMonsters.Count);

                    int damage = isSkillDamage(player, skillNumber);

                    int maxHp1 = aliveMonsters[randomNumber].Hp;

                    string deadMark1 = aliveMonsters[randomNumber].Hp - damage <= 0 ? "Dead" : $"{aliveMonsters[randomNumber].Hp - damage}";

                    aliveMonsters[randomNumber].Hp = aliveMonsters[randomNumber].Hp - damage;

                    if (aliveMonsters[randomNumber].Hp <= 0)
                    {
                        aliveMonsters[randomNumber].isDead = true;
                        b = true;
                    }

                    if (damage > 0)
                    {
                        Console.WriteLine($"Lv.{aliveMonsters[randomNumber1].Level} {aliveMonsters[randomNumber1].Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"Lv. {aliveMonsters[randomNumber].Level} {aliveMonsters[randomNumber].Name}");
                        Console.WriteLine($"HP {maxHp1}  -> {deadMark1}");
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
                        Console.WriteLine($"Lv.{aliveMonsters[randomNumber].Level} {aliveMonsters[randomNumber].Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("0. 다음");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">> ");
                    }
                    b = false;
                    break;
                }
                if (randomNumber2 != randomNumber1)
                {
                    isRandom = false;
                    break;
                }
            }
            return b;
        }

        public bool SkillAttack3(Player player, List<Monster> monsters, int skillNumber, bool b)
        {
            List<Monster> aliveMonsters = new List<Monster>();
            aliveMonsters.Clear();

            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].isDead == false)
                {
                    aliveMonsters.Add(monsters[i]);
                }
            }

            int damage = isSkillDamage(player, skillNumber);

            for (int i = 0; i < aliveMonsters.Count; i++)
            {
                int maxHp = aliveMonsters[i].Hp;
                string deadMark = aliveMonsters[i].Hp - damage <= 0 ? "Dead" : $"{aliveMonsters[i].Hp - damage}";

                aliveMonsters[i].Hp = aliveMonsters[i].Hp - damage;

                if (aliveMonsters[i].Hp <= 0)
                {
                    aliveMonsters[i].isDead = true;
                    b = true;
                }

                if (damage > 0)
                {
                    Console.WriteLine($"Lv.{aliveMonsters[i].Level} {aliveMonsters[i].Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Lv. {aliveMonsters[i].Level} {aliveMonsters[i].Name}");
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
                    Console.WriteLine($"Lv.{aliveMonsters[i].Level} {aliveMonsters[i].Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
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
            return b;
>>>>>>> ae96db6 ([Refactor] 스킬 3개 구현 완료)
        }
    }
}
