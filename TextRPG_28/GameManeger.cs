using System;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace TextRPG_28
{
    public class GameManeger
    {
        Player player;
        List<Monster> monsters;
        Random random = new Random();
        Battle battle = new Battle();
        
        public void MonsterSetting()
        {
            monsters = new List<Monster>
            {
                new Monster(2, "미니언", 15, 5, false),
                new Monster(3, "공허충", 10, 9, false),
                new Monster(5, "대포미니언", 25, 8, false)
            };
        }

        public void IntroScene()            // 이름 입력 화면
        {
            Console.Clear();


            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.WriteLine();
            Console.Write(">> ");
            string name = Console.ReadLine();

            player = new Player(name);

            Console.WriteLine();
            Console.WriteLine($"입력하신 이름은 '{player.Name}' 입니다.");
            Console.WriteLine();
            Console.WriteLine("1. 결정 하기");
            Console.WriteLine("2. 다시 입력");

            int nameNum = Select.Input(1, 2);

            switch (nameNum)
            {
                case 1:
                    SelectJobScene();
                    break;
                case 2:
                    IntroScene();
                    break;
            }
        }

        public void SelectJobScene()            // 직업 선택 화면
        {
            Console.Clear();
            Console.WriteLine("직업을 선택해주세요.");
            Console.WriteLine();
            Console.WriteLine("1. 전사   ->   공격력  10   방어력  10   체력  150   기초자금  1000 gold");
            Console.WriteLine("2. 도적   ->   공격력  15   방어력  05   체력  100   기초자금  1500 gold");

            int jobNum = Select.Input(1, 2);

            switch (jobNum)
            {
                case 1:
                    player = new Player(1, player.Name, "전사", 10, 10, 150, 1000, false);
                    break;
                case 2:
                    player = new Player(1, player.Name, "도적", 15, 5, 100, 1500, false);
                    break;
            }

            Console.Clear();
            Console.WriteLine($"선택하신 직업은 '{player.Job}' 입니다.");
            Console.WriteLine();
            Console.WriteLine("1. 결정 하기");
            Console.WriteLine("2. 다시 선택");

            int selectNum = Select.Input(1, 2);

            switch (selectNum)
            {
                case 1:
                    StartScene();
                    break;
                case 2:
                    SelectJobScene();
                    break;
            }
        }

        public void StartScene()            // 처음 시작 화면
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다 .");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");

            int startNum = Select.Input(1, 2);

            switch (startNum)
            {
                case 1:
                    StatsScene();
                    break;
                case 2:
                    BattleScene();
                    break;
            }
        }

        public void StatsScene ()           // 상태 보기 화면
        {
            player.PlayerStats();

            Select.Input(0, 0);
            StartScene();
        }

        public void BattleScene()           // 전투 화면
        {
            MonsterSetting();

            bool b = false;

            if (b == false)
            {
                bool s = battle.BattelInfo(player, monsters, b);

                if (s == true)
                {
                    StartScene();
                }
            } 
        }

        public void ResultScene()
        {

        }
    }
}