using System;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG_28
{
    public class GameManeger
    {
        Player player;
        List<Monster> monsters;
        public List<Monster> currentMonsters = new List<Monster>();
        Battle battle = new Battle();
        Attack attack = new Attack();
        Result result = new Result();
        
        public void MonsterSetting()
        {
            monsters = new List<Monster>
            {
                new Monster(2, "미니언", 15, 5, false),
                new Monster(3, "공허충", 10, 9, false),
                new Monster(5, "대포미니언", 25, 100, false)
            };

            Random random = new Random();
            int number = random.Next(1, 4);
            currentMonsters.Clear();

            for (int i = 0; i < number; i++)
            {
                int stageMonster = random.Next(0, monsters.Count);
                Monster newMonster = new Monster(monsters[stageMonster].Level, monsters[stageMonster].Name, monsters[stageMonster].Hp, monsters[stageMonster].Attack, false);
                Console.WriteLine($"Lv.{newMonster.Level}  {newMonster.Name}  HP {newMonster.Hp}");
                currentMonsters.Add(newMonster);
            }
        }

        public void IntroScene()            // 이름 입력 화면
        {
            Console.Clear();

            Select.ColorWrite("스파르타 마을에 오신 여러분 환영합니다.", ConsoleColor.Green);
            Select.ColorWrite("원하시는 이름을 설정해주세요.", ConsoleColor.Green);
            Console.WriteLine();
            Console.Write(">> ");
            string name = Console.ReadLine();

            player = new Player(name);

            Console.WriteLine();
            Console.WriteLine($"입력하신 이름은 '{player.Name}' 입니다.");
            Console.WriteLine();
            Select.ColorWrite("1. 결정 하기", ConsoleColor.DarkCyan);
            Select.ColorWrite("2. 다시 입력", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

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
            Select.Loading();

            Console.Clear();
            Select.ColorWrite("직업을 선택해주세요.", ConsoleColor.Green);
            Console.WriteLine();
            Select.ColorWrite("1. 전사    :   체력과 방어력이 높고 밸런스가 좋습니다.", ConsoleColor.DarkCyan);
            Select.ColorWrite("2. 도적    :   공격력이 높고 기초 자금이 많지만 낮은 체력, 방어력을 가지고 있습니다.", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

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
            Select.ColorWrite("직업을 선택해주세요.", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine($"선택하신 직업은 '{player.Job}' 입니다.");
            Console.WriteLine();
            Select.ColorWrite("1. 결정 하기", ConsoleColor.DarkCyan);
            Select.ColorWrite("2. 다시 선택", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

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
            Select.Loading();

            Console.Clear();
            Select.ColorWrite("스파르타 던전에 오신 여러분 환영합니다 .", ConsoleColor.Green);
            Select.ColorWrite("이제 전투를 시작할 수 있습니다.", ConsoleColor.Green);
            Console.WriteLine();
            Select.ColorWrite("1. 상태 보기", ConsoleColor.DarkCyan);
            Select.ColorWrite("2. 전투 시작", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int startNum = Select.Input(1, 3);

            switch (startNum)
            {
                case 1:
                    StatsScene();
                    break;
                case 2:
                    BattleScene();
                    break;
                case 3:
                    RestScene();
                    break;
            }
        }

        public void StatsScene ()           // 상태 보기 화면
        {
            Select.Loading();

            player.PlayerStats();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            Select.Input(0, 0);
            StartScene();
        }

        public void RestScene()
        {
            Select.Loading();
        }

        public void BattleScene()           // 전투 화면
        {
            Select.Loading();

            battle.BattelField(player, monsters, this);

            int yourChoice = Select.Input(0, 1);

            switch (yourChoice)
            {
                case 0:
                    StartScene();
                    break;
                case 1:
                    AttackScene(currentMonsters.Count);
                    break;
            }
        }

        public void AttackScene(int count)
        {
            while (player.isDead == false)
            {
                battle.AttackField(player, this);
                int monsterDeadCount = count;
                bool isMonsterDead = true;

                while (isMonsterDead)
                {
                    int yourChoice = Select.Input(0, count);

                    switch (yourChoice)
                    {
                        case 0:
                            StartScene();
                            break;
                        default:
                            isMonsterDead = attack.PlayerAttack(player, currentMonsters, yourChoice, isMonsterDead);
                            break;
                    }
                }
                Select.Input(0, 0);
                monsterDeadCount = attack.MonsterAttack(player, currentMonsters, count);

                if (monsterDeadCount <= 0 || player.isDead == true)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");
                    Select.Input(0, 0);
                    ResultScene();
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");
                    Select.Input(0, 0);
                }
            }
        }

        public void ResultScene()
        {
            Select.Loading();

            result.ShowBattleResult(player, currentMonsters);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("0. 마을로 돌아가기.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            Select.Input(0, 0);
            StartScene();
        }
    }
}