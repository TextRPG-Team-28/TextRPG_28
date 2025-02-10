﻿using System.Numerics;
using static TextRPG_28.Character;

namespace TextRPG_28
{
    public class GameManager
    {
        public List<Character.Monster> monsterList = new List<Character.Monster>
        {
            new Character.Monster("미니언", 2, 5, 15),
            new Character.Monster("공허충", 3, 9, 10),
            new Character.Monster("대포 미니언", 5, 8, 25)
        };

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">> ");
            string name = Console.ReadLine();
            Player player = new Player(name, "전사", 1, 10, 5, 100, 1500);

            GameManager gameManager = new GameManager();
            GameStart gameStart = new GameStart();
            gameStart.StartScene(player, gameManager.monsterList);
        }
    }
}
