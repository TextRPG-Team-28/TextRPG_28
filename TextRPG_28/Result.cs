using System;
using System.Collections.Generic;
using System.Linq;

namespace TextRPG_28
{
    internal class Result
    {
        public static void ShowBattleResult(Player player, List<Monster> monsters) //플레이어 몬스터 받아오기
        {
            Console.Clear();
            Console.WriteLine("Battle!! - Result\n");

            if (player.Hp <= 0) // hp가 0 이면 
            {
                Console.WriteLine("짐...");
                Console.WriteLine("당신은 던전에서 패배했습니다.");
                Console.WriteLine("\n0. 게임 종료\n>>");
                Console.ReadLine(); // 사용자가 종료하도록 대기
                Environment.Exit(0); // 프로그램 종료
            }
            else
            {
                Console.WriteLine("이김!!"); //승리
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

                Console.WriteLine($"\nLv.{player.Level} {player.Name}");
                Console.WriteLine($"HP {Math.Max(0, player.Hp)}\n");
                Console.WriteLine("0. 다음\n>>");
                Console.ReadLine(); // 사용자가 다음으로 진행하도록 대기
            }
        }

        public static bool CheckBattleEnd(Player player, List<Monster> monsters)
        {
            if (player.Hp <= 0 || monsters.All(m => m.isDead))
            {
                ShowBattleResult(player, monsters); // 전투 종료 후 결과 화면 호출
                return true;
            }
            return false;
        }
    }
}
