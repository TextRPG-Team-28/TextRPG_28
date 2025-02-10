using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    internal class Result
    {
        public static void  ShowBattleResult(Character.Player warrior, List<Character.Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine("Battle!! - Result\n");

            if (warrior.Health <= 0)
            {
                Console.WriteLine("You Lose\n");
            }
            else
            {
                Console.WriteLine("Victory\n");
                Console.WriteLine($"던전에서 {monsters.Count}마리의 몬스터를 잡았습니다.");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⡟⠏⠇⠇⠇⠫⡛⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣮⠐⠌⢌⠢⠳⢶⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⠡⠡⠡⠡⠡⠡⡑⢹⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⡿⣛⢙⢛⠡⠡⡹⣥⢡⣡⡑⡸⡿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⡬⠨⣴⣌⡂⢂⠪⢟⠯⠇⣤⣷⢸⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⢇⢇⣧⣇⡕⢼⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣸⣪⡯⢗⣛⣾⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            }

            Console.WriteLine($"\nLv.{warrior.Level} {warrior.Name}");
            Console.WriteLine($"HP {Math.Max(0, warrior.Health)}\n");
            Console.WriteLine("0. 다음\n>>");
            Console.ReadLine(); // 사용자가 다음으로 진행하도록 대기
        }

        static public bool CheckBattleEnd(Character.Player warrior, List<Character.Monster> monsters)
        {
            return warrior.Health <= 0 || monsters.Count == 0;
        }
    }
}
