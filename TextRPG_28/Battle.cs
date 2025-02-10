using System;
using System.ComponentModel;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG_28;

public class Battle
{
    //public List<Monster> currentMonsters = new List<Monster>();

    public void BattelField(Player player, List<Monster> monsters, GameManeger gm)
    {
        Console.Clear();
        Console.WriteLine("Battle!!\n\n");

        //NumberOfMonsters(monsters, 4);
        gm.MonsterSetting();

        Console.WriteLine("\n\n\n[내 정보]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}"); // 현재 체력 / 원래 체력 전투할 때 나눠줘야 함. 
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1. 공격\n0. 마을로 돌아가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.Write(">> ");

        //return currentMonsters.Count;
    }

    //public void NumberOfMonsters(List<Monster> monsterList, int count)
    //{
    //    Random random = new Random();
    //    int number = random.Next(1, count + 1);

    //    currentMonsters.Clear();

    //    for (int i = 0; i < number; i++)
    //    {
    //        int stageMonster = random.Next(0, monsterList.Count);
    //        Console.WriteLine($"Lv.{monsterList[stageMonster].Level}  {monsterList[stageMonster].Name}  HP {monsterList[stageMonster].Hp}");
    //        currentMonsters.Add(monsterList[stageMonster]);
    //    }
    //}

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

        Console.WriteLine("\n\n[내 정보]");
        Console.WriteLine($"Lv.{player.Level}   {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp} / {player.MaxHp}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("0. 도망치기\n\n");
        Console.Write("대상을 선택해주세요\n>> ");
    }
}

