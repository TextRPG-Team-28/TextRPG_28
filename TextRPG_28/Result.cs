using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    public class Result
    {
        public void  ShowBattleResult(Player player, List<Monster> monsters)    // 결과 화면
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("결과 보기\n");

            if (player.isDead == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Die\n");
                Console.ResetColor();
                Console.WriteLine($"마을로 돌아가 체력을 회복 하세요.");
                Console.WriteLine($"(회복 하기 전까지 전투 불가능)\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Victory\n");
                Console.ResetColor();
                Console.WriteLine($"던전에서 {monsters.Count}마리의 몬스터를 잡았습니다.\n");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⡟⠏⠇⠇⠇⠫⡛⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣮⠐⠌⢌⠢⠳⢶⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⠡⠡⠡⠡⠡⠡⡑⢹⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⡿⣛⢙⢛⠡⠡⡹⣥⢡⣡⡑⡸⡿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⡬⠨⣴⣌⡂⢂⠪⢟⠯⠇⣤⣷⢸⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⢇⢇⣧⣇⡕⢼⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣸⣪⡯⢗⣛⣾⣿⣿⣿⣿⣿⣿");
                Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n");
                int plusGold = monsters.Count * 300;
                player.Gold += plusGold;

                Console.WriteLine($"{plusGold} gold를 획득하였습니다.");
            }
            Console.WriteLine($"\nLv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"남은 체력 : {Math.Max(0, player.Hp)}");
            Console.ResetColor ();
        }
    }
}
