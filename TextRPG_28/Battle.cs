using System;
using System.ComponentModel;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG_28;

public class Battle
{
    public void BattelField(Player player, List<Monster> monsters, GameManeger gm)      // 던전의 필드
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine("던전\n");
        Console.ResetColor();

        gm.MonsterSetting();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n[내 정보]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine($"MP {player.Mp} / {player.MaxMp}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("1. 공격\n2. 스킬\n0. 마을로 돌아가기");
        Console.ResetColor();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.Write(">> ");
    }

    public void AttackField(Player player, GameManeger gm)      // 공격 시 필드
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("던전\n");
        for (int i = 0; i < gm.currentMonsters.Count; i++)
        {
            if (gm.currentMonsters[i].isDead == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"{i + 1}.  Lv.{gm.currentMonsters[i].Level} {gm.currentMonsters[i].Name}  HP {gm.currentMonsters[i].Hp} ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}.  Lv.{gm.currentMonsters[i].Level} {gm.currentMonsters[i].Name}  Dead ");
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n[내 정보]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine($"MP {player.Mp} / {player.MaxMp}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("0. 돌아가기\n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("대상을 선택해주세요\n>> ");
    }

    public void SkillField(Player player, GameManeger gm)      // 공격 시 필드
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("던전\n");
        for (int i = 0; i < gm.currentMonsters.Count; i++)
        {
            if (gm.currentMonsters[i].isDead == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Lv.{gm.currentMonsters[i].Level} {gm.currentMonsters[i].Name}  HP {gm.currentMonsters[i].Hp} ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Lv.{gm.currentMonsters[i].Level} {gm.currentMonsters[i].Name}  Dead ");
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n[내 정보]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine($"MP {player.Mp} / {player.MaxMp}");
        Console.WriteLine("\n");
        Console.WriteLine("1. 알파 스트라이크 - MP 10");
        Console.WriteLine(" -> 공격력 * 2 로 하나의 적을 공격합니다.");
        Console.WriteLine("2. 더블 스트라이크 - MP 15");
        Console.WriteLine(" -> 공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다.");
        Console.WriteLine("3. 아마겟돈 - MP 20");
        Console.WriteLine(" -> 공격력 * 1.2로 모든 적을 공격합니다.\n\n");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("0. 돌아가기\n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("원하시는 행동을 입력해주세요.\n>> ");
    }


}

