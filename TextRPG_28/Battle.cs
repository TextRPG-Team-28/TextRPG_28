using System;
using System.ComponentModel;
using System.Numerics;

namespace TextRPG_28;

public class Battle
{
    Attack attack = new Attack();
    Random random = new Random();

    public bool BattelInfo(Player player, List<Monster> monsters, bool b)
    {
        bool Clear = false;
        int randomA = random.Next(1, 4);
        int[] randomB = new int[3];

        for (int i = 0; i < randomA; i++)
        {
            randomB[i] = random.Next(0, 3);
        }

        while (!Clear)
        {
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();

            if (player.IsAttack == false)
            {
                for (int i = 0; i < randomA; i++)
                {
                    Console.WriteLine($"Lv. {monsters[randomB[i]].Level} {monsters[randomB[i]].Name}  Hp {monsters[randomB[i]].MaxHp}");
                }

                player.PlayerAttackText();
                Console.WriteLine("1. 공격");
                Console.WriteLine("0. 마을로 돌아가기");
                Console.WriteLine();

                int atkNum = Select.Input(0, 1);

                switch (atkNum)
                {
                    case 1:
                        player.IsAttack = true;
                        break;
                    case 0:
                        Clear = true;
                        b = true;
                        break;
                }
            }
            else if (player.IsAttack == true)
            {
                for (int i = 0; i < randomA; i++)
                {
                    Console.WriteLine($"{i + 1}. Lv. {monsters[randomB[i]].Level} {monsters[randomB[i]].Name}  Hp {monsters[randomB[i]].Hp}");
                }

                player.PlayerAttackText();
                Console.WriteLine("0. 취소");
                Console.WriteLine();

                int attackNum = Select.Input(0, randomA);

                attack.PlayerAttack(player, monsters, attackNum);
            }
        }
        return b;
    }
}

