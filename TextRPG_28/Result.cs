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
                Console.WriteLine("  .oooooo.                              .o8  .o. ");
                Console.WriteLine(" d8P'  `Y8b                             888  888 ");
                Console.WriteLine("888            .ooooo.   .ooooo.   .oooo888  888 ");
                Console.WriteLine("888           d88' `88b d88' `88b d88' `888  Y8P ");
                Console.WriteLine("888     ooooo 888   888 888   888 888   888  `8' ");
                Console.WriteLine("`88.    .88'  888   888 888   888 888   888  .o. ");
                Console.WriteLine(" `Y8bood8P'   `Y8bod8P' `Y8bod8P' `Y8bod88P  Y8P ");
                Console.WriteLine("");
                Console.WriteLine("\n");

                int plusGold = monsters.Count * 300;
                player.Gold += plusGold;

                for (int i = 0; i < monsters.Count; i++) 
                {
                    player.AddExp(monsters[i].Level);
                }

                Console.WriteLine();
                Console.WriteLine($"{player.Exp} 경험치를 획득하였습니다.");
                Console.WriteLine($"{plusGold} gold를 획득하였습니다.");
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nLv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"남은 체력 : {Math.Max(0, player.Hp)}");
            Console.WriteLine($"소지금 : {player.Gold} gold");
            Console.ResetColor ();
        }
    }
}
