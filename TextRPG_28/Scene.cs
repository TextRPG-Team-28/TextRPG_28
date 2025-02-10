using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_28.Character;

namespace TextRPG_28
{
    internal class Scene
    {
        GameManager gameManager = new GameManager();

        public void SelectJob(Player player)
        {
            Console.Clear();
            Console.WriteLine("직업을 선택해주세요.");
            Console.WriteLine();
            Console.WriteLine("1. 전사   ->   공격력  10   방어력  10   체력  150   기초자금  1000 gold");
            Console.WriteLine("2. 도적   ->   공격력  15   방어력  05   체력  100   기초자금  1500 gold");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int yourChoice1 = Select.GetInput(1, 2);

            switch (yourChoice1)
            {
                case 1:
                    player = new Player(player.Name, "전사", 1, 10, 10, 150, 1000);
                    break;
                case 2:
                    player = new Player(player.Name, "도적", 1, 15, 5, 100, 1500);
                    break;
            }

            Console.Clear();
            Console.WriteLine($"선택하신 직업은 '{player.Job}' 입니다.");
            Console.WriteLine();
            Console.WriteLine("1. 결정 하기");
            Console.WriteLine("2. 다시 선택");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int yourChoice2 = Select.GetInput(1, 2);

            switch (yourChoice2)
            {
                case 1:
                    StartScene(player, gameManager.monsterList);
                    break;
                case 2:
                    SelectJob(player);
                    break;
            }
        }

        public void StartScene(Player player, List<Character.Monster> monsterList)
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int yourChoice = Select.GetInput(1, 2);

            switch (yourChoice)
            {
                case 1:
                    ShowStatus(player);
                    break;
                case 2:
                    BattleStart battleStart = new BattleStart();
                    battleStart.Battle(player, gameManager.monsterList);
                    break;                        
            }          
        }

        public void ShowStatus(Character.Player player)
        {
            Console.Clear();
            Console.WriteLine("--상태 보기--");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ( {player.Job} )");
            Console.WriteLine($"공격력: {player.Attack}");
            Console.WriteLine($"방어력: {player.Defend}");
            Console.WriteLine($"체력: {player.Health}");
            Console.WriteLine($"Gold: {player.Gold} G\n");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            Select.GetInput(0, 0);
            StartScene(player, new List<Character.Monster>());
        }
    }   
}
