using System;
using System.ComponentModel;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG_28;

public class Battle
{
    public void BattelField(Player player, List<Monster> monsters, GameManeger gm)      // ������ �ʵ�
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine("����\n");
        Console.ResetColor();

        gm.MonsterSetting();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n[�� ����]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine($"MP {player.Mp} / {player.MaxMp}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("1. ����\n2. ��ų\n0. ������ ���ư���");
        Console.ResetColor();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");
        Console.Write(">> ");
    }

    public void AttackField(Player player, GameManeger gm)      // ���� �� �ʵ�
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("����\n");
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
        Console.WriteLine("\n[�� ����]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine($"MP {player.Mp} / {player.MaxMp}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("0. ���ư���\n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("����� �������ּ���\n>> ");
    }
}

