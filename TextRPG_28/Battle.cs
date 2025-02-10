using System;
using System.ComponentModel;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG_28;

public class Battle
{
    public void BattelField(Player player, List<Monster> monsters, GameManeger gm)
    {
        Console.Clear();
        Console.WriteLine("Battle!!\n\n");

        gm.MonsterSetting();

        Console.WriteLine("\n\n\n[�� ����]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1. ����\n0. ������ ���ư���");
        Console.WriteLine();
        Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");
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

        Console.WriteLine("\n\n[�� ����]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("0. ����ġ��\n\n");
        Console.Write("����� �������ּ���\n>> ");
    }
}

