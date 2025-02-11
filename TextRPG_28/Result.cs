using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRPG_28
{
    public class Result

    {
        
        public void  ShowBattleResult(Player player, List<Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine("Battle!! - Result\n\n");

            if (player.isDead == true)
            {
                Console.WriteLine("You Lose\n");
            }
            else
            {
                int Monsterscount = monsters.Count(monster => monster.isDead);
                Console.WriteLine($"던전에서 {Monsterscount}마리의 몬스터를 처치했습니다.");

                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⡟⠏⠇⠇⠇⠫⡛⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣮⠐⠌⢌⠢⠳⢶⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⠡⠡⠡⠡⠡⠡⡑⢹⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⡿⣛⢙⢛⠡⠡⡹⣥⢡⣡⡑⡸⡿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⡬⠨⣴⣌⡂⢂⠪⢟⠯⠇⣤⣷⢸⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⢇⢇⣧⣇⡕⢼⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣸⣪⡯⢗⣛⣾⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                    Console.WriteLine($"{monster.Name} 처치! {monster.Level} 경험치를 획득!");
                }

                player.AddExp(totalExp); // 경험치 추가



            }
            Console.WriteLine($"\nLv.{player.Level} {player.Name}");
            Console.WriteLine($"HP {Math.Max(0, player.Hp)}");
        }

        public bool CheckBattleEnd(Player player, List<Monster> monsters)
        {
            return player.Hp <= 0 || monsters.Count == 0;
        }
    }
}
