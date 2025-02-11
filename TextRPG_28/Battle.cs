using System;
using System.ComponentModel;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG_28;

public class Battle
{
    LevelUp levelUp;
    public void BattelField(Player player, List<Monster> monsters, GameManeger gm)
    {
        Console.Clear();
        Console.WriteLine("Battle!!\n\n");

        gm.MonsterSetting();

        Console.WriteLine("\n\n\n[내정보]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine($"EXP {player.Exp} / {player.MaxExp}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1. 공격\n 2.스킬 \n0. 도망치기");
        Console.WriteLine();
        Console.WriteLine("대상을 선택해주세요.");
        Console.Write(">> ");
    }

    public void AttackField(Player player, GameManeger gm)
    {
        Console.Clear();
        Console.WriteLine("Battle!!\n\n");
        for (int i = 0; i < gm.currentMonsters.Count; i++)
        {
            if (gm.currentMonsters[i].isDead == false)
            {
                Console.WriteLine($"{i + 1}  Lv.{gm.currentMonsters[i].Level} {gm.currentMonsters[i].Name}  HP {gm.currentMonsters[i].Hp} ");
            }
            else
            {
                Console.WriteLine($"{i + 1}  Lv.{gm.currentMonsters[i].Level} {gm.currentMonsters[i].Name}  Dead ");
            }
        }

        Console.WriteLine("\n\n[내정보]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("0. 도망치기\n\n");
        Console.Write("대상을 선택해 주세요  .\n>> ");
    }
}

