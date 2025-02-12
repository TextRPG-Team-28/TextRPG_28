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
            int plusGold = 0;
            int plusEXP = 0;

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

                for (int i = 0; i < monsters.Count; i++)
                {
                    plusGold = monsters[i].Level * 100;
                }

                player.Gold += plusGold;

                for (int i = 0; i < monsters.Count; i++) 
                {
                    plusEXP += monsters[i].Level;
                    player.AddExp(monsters[i].Level);
                }

                player.Hp += 10;

                if (player.Hp >= player.MaxHp)
                {
                    player.Hp = player.MaxHp ;
                }

                player.Mp += 10;

                if (player.Mp >= player.MaxMp)
                {
                    player.Mp = player.MaxMp;
                }

                Console.WriteLine($"{player.Exp} 경험치를 획득하였습니다.");
                Console.WriteLine($"{plusGold} gold를 획득하였습니다.");
                Console.WriteLine($"Hp를 10 회복하였습니다.");
                Console.WriteLine($"Mp를 10 회복하였습니다.");
                Random random = new Random();

                if (random.Next(0, 100) < 90)
                {
                    Item droppedItem = GameManeger.dropItems[random.Next(GameManeger.dropItems.Count)];

                    // 그대로 inventory에 추가 가능

                    GameManeger.inventory.Add(droppedItem);

                    Console.WriteLine($"{droppedItem.Name}을(를) 획득했습니다!");
                }

            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nLv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"경험치 : {player.Exp}/{player.ExpLevelUp[player.Level]} (+{plusEXP})");
            Console.WriteLine($"남은 체력 : {Math.Max(0, player.Hp)} (+10)");
            Console.WriteLine($"남은 마나 : {Math.Max(0, player.Mp)} (+10)");
            Console.WriteLine($"소지금 : {player.Gold} gold (+{plusGold})");
            Console.ResetColor ();
        }
    }
}
