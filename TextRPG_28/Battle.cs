using System;
using System.ComponentModel;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG_28;

public class Battle
{
    public void BattelField(Player player, List<Monster> monsters, GameManeger gm)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine("Battle!!\n");
        Console.ResetColor();

        gm.MonsterSetting();

        Console.WriteLine("\n[�� ����]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("1. ����\n0. ������ ���ư���");
        Console.ResetColor();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");
        Console.Write(">> ");
    }

    public void AttackField(Player player, GameManeger gm)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Battle!!\n");
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
        Console.ResetColor();
        Console.WriteLine("\n[�� ����]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("0. ����ġ��\n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("����� �������ּ���\n>> ");
    }
}

