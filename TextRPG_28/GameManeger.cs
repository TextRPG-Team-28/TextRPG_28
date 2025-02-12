using System;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG_28
{
    public class GameManeger
    {
        Player player;

        List<Monster> monsters;
        public List<Monster> currentMonsters = new List<Monster>();

        List<Item> itemList;
        List<Item> inventory = new List<Item>();
        List<DungeonItem> dungeonItems;
        List<DungeonItem> currentDungeon = new List<DungeonItem>();

        Battle battle = new Battle();
        Attack attack = new Attack();
        Result result = new Result();
        Skill skill = new Skill();
        
        public void MonsterSetting()    // 몬스터 세팅 및 랜덤하게 생성
        {
            monsters = new List<Monster>
            {
                new Monster(1, "미니언", 15, 3, false),
                new Monster(2, "공허충", 10, 6, false),
                new Monster(3, "대포미니언", 25, 7, false)
            };

            Random random = new Random();
            int number = random.Next(1, 5);

            if (currentMonsters.Count < 1)
            {
                for (int i = 0; i < number; i++)
                {
                    int stageMonster = random.Next(0, monsters.Count);
                    Monster newMonster = new Monster(monsters[stageMonster].Level, monsters[stageMonster].Name, monsters[stageMonster].Hp, monsters[stageMonster].Attack, false);
                    Console.WriteLine($"Lv.{newMonster.Level}  {newMonster.Name}  HP {newMonster.Hp}");
                    currentMonsters.Add(newMonster);
                }
            }
            else
            {
                for (int i = 0; i < currentMonsters.Count; i++)
                {
                    if(currentMonsters[i].isDead == false)
                        Console.WriteLine($"Lv.{currentMonsters[i].Level}  {currentMonsters[i].Name}  HP {currentMonsters[i].Hp}");
                    else
                        Utility.ColorWrite($"Lv.{currentMonsters[i].Level}  {currentMonsters[i].Name}  Dead", ConsoleColor.DarkGray);
                }
            }
        }

        public void ItemSetting()   // 아이템 세팅
        {
            itemList = new List<Item>()
            {
                new Item("수련자의 갑옷", ItemType.Amor, 4, "수련에 도움을 주는 갑옷입니다. ", 1000),
                new Item("무쇠갑옷", ItemType.Amor, 9, "무쇠로 만들어져 튼튼한 갑옷입니다. ", 2000),
                new Item("스파르타의 갑옷", ItemType.Amor, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다. ", 3500),
                new Item("낡은 검", ItemType.Weapon, 5, "쉽게 볼 수 있는 낡은 검 입니다. ", 600),
                new Item("청동 도끼", ItemType.Weapon, 10, "어디선가 사용됐던거 같은 도끼입니다. ", 1500),
                new Item("스파르타의 창", ItemType.Weapon, 20, "스파르타의 전사들이 사용했다는 전설의 창입니다. ", 2500)
            };
        }
        public void dungeonitemSetting()// 던전아이템
        {
            dungeonItems = new List<DungeonItem>
            {
                new DungeonItem("아무렇게나버린 쓰래기 ",ItemType.MonsterItem,0,100),
                new DungeonItem("씹다뱉은 껌", ItemType.MonsterItem,0,50),
                new DungeonItem("몬스터의 정수 ",ItemType.MonsterItem,0,500),
                new DungeonItem("영웅의 칼",ItemType.Weapon,50,1500)
            };
            
            Random random = new Random();
            currentDungeon = new List<DungeonItem>();
            int number = random.Next(0, 3);
            int iemnumber = random.Next(1, 100);
            int itemnumbering = random.Next(1, 100);
            
            if (iemnumber < 90)
            {
                if (itemnumbering < 90)
                {
                    Console.WriteLine("던전 전리품");
                    for (int i = 0; i < number; i++)
                    {
                        int dungeonitem = random.Next(0, dungeonItems.Count);
                        DungeonItem newdungeon = new DungeonItem(dungeonItems[dungeonitem].Name,
                            dungeonItems[dungeonitem].Type,
                            dungeonItems[dungeonitem].Value, dungeonItems[dungeonitem].Cost);
                        newdungeon = new DungeonItem(dungeonItems[dungeonitem].Name, dungeonItems[dungeonitem].Type,
                            dungeonItems[dungeonitem].Value, dungeonItems[dungeonitem].Cost);
                        Console.WriteLine($"{newdungeon.Name}   cost {newdungeon.Cost}");
                        currentDungeon.Add(newdungeon);
                    }
                }
            }
            else
            {
                Console.WriteLine("아무것도 얻지 못하셨습니다 .....");
            }
            
        }




        public void IntroScene()    // 이름 입력 화면
        {
            Console.Clear();
            Utility.ColorWrite("원하시는 이름을 설정해주세요.", ConsoleColor.Green);
            Console.WriteLine();
            Console.Write(">> ");
            string name = Console.ReadLine();

            player = new Player(name);

            Console.Clear();
            Utility.ColorWrite("이름 설정", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine($"입력하신 이름은 '{player.Name}' 입니다.");
            Console.WriteLine();
            Utility.ColorWrite("1. 결정 하기", ConsoleColor.DarkCyan);
            Utility.ColorWrite("2. 다시 입력", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int nameNum = Utility.Input(1, 2);

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

        public void SelectJobScene()    // 직업 선택 화면
        {
            Utility.Loading("직업 목록 생성 중");

            Console.Clear();
            Utility.ColorWrite("직업을 선택해주세요.", ConsoleColor.Green);
            Console.WriteLine();
            Utility.ColorWrite("1. 전사  :  체력과 방어력이 높고 밸런스가 좋습니다.", ConsoleColor.DarkCyan);
            Utility.ColorWrite("2. 도적  :  공격력이 높고 기초 자금이 많지만 낮은 체력, 방어력을 가지고 있습니다.", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int jobNum = Utility.Input(1, 2);

            switch (jobNum)
            {
                case 1:
                    player = new Player(1, player.Name, "전사", 10, 10, 150, 50, 500, false, 0);
                    break;
                case 2:
                    player = new Player(1, player.Name, "도적", 12, 5, 100, 50, 800, false, 0);
                    break;
            }

            Console.Clear();
            Utility.ColorWrite("직업 선택", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine($"선택하신 직업은 '{player.Job}' 입니다.");
            Console.WriteLine();
            Utility.ColorWrite("1. 결정 하기", ConsoleColor.DarkCyan);
            Utility.ColorWrite("2. 다시 선택", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int selectNum = Utility.Input(1, 2);

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

        public void StartScene()    // 메인 화면
        {
            Utility.Loading("마을로 가는 중");

            Console.Clear();
            Utility.ColorWrite("마을", ConsoleColor.Green);
            Console.WriteLine();
            Utility.ColorWrite("1. 상태 보기", ConsoleColor.DarkCyan);
            Utility.ColorWrite("2. 인벤토리", ConsoleColor.DarkCyan);
            Utility.ColorWrite("3. 상점", ConsoleColor.DarkCyan);
            Utility.ColorWrite("4. 휴식 하기", ConsoleColor.DarkCyan);
            Utility.ColorWrite("5. 던전 입장", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int startNum = Utility.Input(1, 5);

            switch (startNum)
            {
                case 1:
                    StatsScene();
                    break;
                case 2:
                    InventoryScene();
                    break;
                case 3:
                    ShopScene();
                    break;
                case 4:
                    RestScene();
                    break;
                case 5:
                    currentMonsters.Clear();
                    Utility.Loading("던전 입장 중");
                    BattleScene();
                    break;
            }
        }

        public void StatsScene()    // 상태 보기 화면
        {
            Utility.Loading("상태 보기 활성화 중");

            player.PlayerStats();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            Utility.Input(0, 0);
            StartScene();
        }

        public void InventoryScene()    //인벤토리 화면
        {
            Utility.Loading("인벤토리 여는 중");

            Console.Clear();
            Utility.ColorWrite("인벤토리", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].IsEquip == true)
                    Utility.ColorWrite($"{inventory[i].ItemDisplay()}", ConsoleColor.DarkYellow);
                else
                    Console.WriteLine($"{inventory[i].ItemDisplay()}");
            }

            Console.WriteLine();
            Utility.ColorWrite("1. 장착 관리", ConsoleColor.DarkCyan);
            Utility.ColorWrite("0. 마을로 돌아가기", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = Utility.Input(0, 1);
            switch (input)
            {
                case 0:
                    StartScene();
                    break;
                case 1:
                    EquipScene();
                    break;
            }
        }

        public void EquipScene()    //장착 화면
        {
            Console.Clear();
            Utility.ColorWrite("장착 관리", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].IsEquip == true)
                    Utility.ColorWrite($"{i + 1}. {inventory[i].ItemDisplay()}", ConsoleColor.Cyan);
                else
                    Utility.ColorWrite($"{i + 1}. {inventory[i].ItemDisplay()}", ConsoleColor.DarkCyan);
            }

            Console.WriteLine();
            Utility.ColorWrite("0. 마을로 돌아가기", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = Utility.Input(0, inventory.Count);
            switch (input)
            {
                case 0:
                    StartScene();
                    break;
                default:
                    Equip(input);
                    break;
            }
        }

        public void Equip(int input)    // 장착 관리
        {
            Item select = inventory[input - 1];

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].IsEquip && (inventory[i].Type == select.Type) && (inventory[i] != select))
                    player.UnEquip(inventory[i]);
            }

            player.EquipItem(select);

            EquipScene();
        }

        public void ShopScene()     // 상점 화면 
        {
            Utility.Loading("상점 들어가는 중");

            Console.Clear();
            Utility.ColorWrite("상점", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();

            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].IsPurchase == true)
                    Utility.ColorWrite($"{itemList[i].ItemDisplay()} | {itemList[i].GetPriceString()}\n", ConsoleColor.DarkGray);
                else
                    Console.WriteLine($"{itemList[i].ItemDisplay()} | {itemList[i].GetPriceString()}\n");
            }

            Utility.ColorWrite($"소지금 : {player.Gold} gold", ConsoleColor.Yellow);
            Console.WriteLine();
            Utility.ColorWrite("1. 아이템 구매", ConsoleColor.DarkCyan);
            Utility.ColorWrite("0. 나가기", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = Utility.Input(0, 1);
            switch (input)
            {
                case 0:
                    StartScene();
                    break;
                case 1:
                    BuyScreen();
                    break;
            }
        }

        public void BuyScreen(bool needGold = false, bool hasItem = false)      // 구매 화면 
        {
            Console.Clear();
            Utility.ColorWrite("아이템 구매", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();

            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].IsPurchase == true)
                    Utility.ColorWrite($"{i + 1}. {itemList[i].ItemDisplay()} | {itemList[i].GetPriceString()}\n", ConsoleColor.DarkGray);
                else
                    Utility.ColorWrite($"{i + 1}. {itemList[i].ItemDisplay()} | {itemList[i].GetPriceString()}\n", ConsoleColor.DarkCyan);
            }

            Utility.ColorWrite($"소지금 : {player.Gold} gold", ConsoleColor.Yellow);
            Console.WriteLine();
            Utility.ColorWrite("0. 나가기", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            if (needGold)   // 소지금이 부족할때
            {
                Console.WriteLine();
                Utility.ColorWrite("골드가 부족합니다!!", ConsoleColor.DarkRed);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
            }
            else if (hasItem)   // 보유 아이템 일때
            {
                Console.WriteLine();
                Utility.ColorWrite("이미 보유한 아이템입니다!!", ConsoleColor.DarkRed);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
            }      

            int input = Utility.Input(0, itemList.Count);
            switch (input)
            {
                case 0:
                    StartScene();
                    break;
                default:
                    Item select = itemList[input - 1];

                    if (inventory.Contains(select))
                        BuyScreen(false, true);
                    else
                        Buy(select);
                    break;
            }
        }

        public void Buy(Item item)      // 아이템 구매
        {
            if (player.Gold >= item.Cost)
            {
                player.Gold -= item.Cost;
                item.IsPurchase = true;
                inventory.Add(item);
                BuyScreen();
            }
            else
            {
                BuyScreen(true, false);
            }
        }

        public void RestScene()     // 휴식 화면
        {
            Utility.Loading("휴식 하러 가는 중");

            Console.Clear();
            Utility.ColorWrite("휴식 하기", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("이곳에서 휴식을 취해 체력을 회복할 수 있습니다.");
            Console.WriteLine();
            Utility.ColorWrite("1. 짧은 휴식 하기 ( 300 gold 소모, 체력 30, 마나 20 회복 )", ConsoleColor.DarkCyan);
            Utility.ColorWrite("2. 충분한 휴식 하기 ( 600 gold 소모, 체력 60, 마나 40 회복 )", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.WriteLine($"현재 체력 : {player.Hp}");
            Console.WriteLine($"소지금 : {player.Gold}");
            Console.WriteLine();
            Utility.ColorWrite("0. 마을로 돌아가기", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int yourChoice = Utility.Input(0, 2);
            switch (yourChoice)
            {
                case 0:
                    StartScene();
                    break;
                default:
                    Rest(yourChoice);
                    break;
            }
        }

        public void Rest(int price)     // 휴식 관리
        {
            if (player.Hp != player.MaxHp && player.Gold >= 300 * price)
            {
                int currentHp = player.Hp;
                int currentMp = player.Mp;
                int currentGold = player.Gold;

                player.Hp += 30 * price;
                player.Mp += 20 * price;
                player.Gold -= 300 *price;

                if (player.Hp >= player.MaxHp)
                {
                    player.Hp = player.MaxHp;
                }
                if (player.Mp >= player.MaxMp)
                {
                    player.Mp = player.MaxMp;
                }

                for (int i = 0; i < price; i++)
                {
                    Utility.Loading("휴식하는 중");
                }

                Console.Clear();
                Utility.ColorWrite("휴식 완료!", ConsoleColor.Green);
                Console.WriteLine();
                Console.WriteLine($"{player.Name} 님의 체력이 회복 되었습니다.\n{currentHp} -> {player.Hp}");
                Console.WriteLine($"{player.Name} 님의 마나가 회복 되었습니다.\n{currentMp} -> {player.Mp}");
                Console.WriteLine();
                Utility.ColorWrite("1. 한번 더 휴식 하기", ConsoleColor.DarkCyan);
                Utility.ColorWrite("0. 마을로 돌아가기", ConsoleColor.DarkCyan);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int yourChoice = Utility.Input(0, 1);

                switch (yourChoice)
                {
                    case 0:
                        StartScene();
                        break;
                    case 1:
                        RestScene();
                        break;
                }
            }
            else if(player.Hp == player.MaxHp && player.Mp == player.MaxMp)
            {
                Console.Clear();
                Utility.ColorWrite("휴식 불가", ConsoleColor.Red);
                Console.WriteLine();
                Console.WriteLine("이미 가득 차있습니다.");
                Console.WriteLine();
                Utility.ColorWrite("0. 마을로 돌아가기", ConsoleColor.DarkCyan);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                Utility.Input(0, 0);
                StartScene();
            }
            else if(player.Gold < 300 * price)
            {
                Console.Clear();
                Utility.ColorWrite("휴식 불가", ConsoleColor.Red);
                Console.WriteLine();
                Console.WriteLine("소지금이 부족합니다.");
                Console.WriteLine();
                Utility.ColorWrite("0. 마을로 돌아가기", ConsoleColor.DarkCyan);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                Utility.Input(0, 0);
                StartScene();
            }
        }

        public void BattleScene()           // 전투 화면
        {
            
            if(player.Hp >= 20)
            {
                battle.BattelField(player, monsters, this);

                int yourChoice = Utility.Input(0, 2);

                switch (yourChoice)
                {
                    case 0:
                        StartScene();
                        break;
                    case 1:
                        AttackScene(currentMonsters.Count);
                        break;
                    case 2:
                        SkillScene(currentMonsters.Count);
                        break;
                }
            }
            else
            {
                Console.Clear();
                Utility.ColorWrite($"던전 입장 조건 : 현재 체력 20 이상", ConsoleColor.Red);
                Console.WriteLine();
                Console.WriteLine($"{player.Name}님의 체력이 부족합니다.");
                Console.WriteLine($"현재 체력 : {player.Hp}");
                Console.WriteLine();
                Console.WriteLine($"마을로 돌아가거나 휴식을 해서 체력을 채울 수 있습니다.");
                Console.WriteLine();
                Utility.ColorWrite("1. 휴식하러 가기", ConsoleColor.DarkCyan);
                Utility.ColorWrite("0. 마을로 돌아가기", ConsoleColor.DarkCyan);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int yourChoice = Utility.Input(0, 1);

                switch (yourChoice)
                {
                    case 0:
                        StartScene();
                        break;
                    case 1:
                        RestScene();
                        break;
                }
            }
        }

        public void AttackScene(int count)      // 공격 화면
        {
            player.isDead = false;

            while (player.isDead == false)
            {
                battle.AttackField(player, this);
                int monsterDeadCount = count;
                bool isMonsterLive = true;

                while (isMonsterLive)
                {
                    int yourChoice = Utility.Input(0, count);

                    switch (yourChoice)
                    {
                        case 0:
                            BattleScene();
                            break;
                        default:
                            isMonsterLive = attack.PlayerAttack(player, currentMonsters, yourChoice, isMonsterLive);
                            break;
                    }
                }
                Utility.Input(0, 0);
                monsterDeadCount = attack.MonsterAttack(player, currentMonsters, count);

                if (monsterDeadCount <= 0 || player.isDead == true)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");
                    Utility.Input(0, 0);
                    ResultScene();
                }
                else if(monsterDeadCount > 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");
                    Utility.Input(0, 0);
                    BattleScene();
                }
            }
        }
        public void SkillScene(int count)    // 스킬 화면
        {
            while (player.isDead == false) 
            {
                player.isDead = false;
                bool isMonsterLive = true;
                int monsterDeadCount = count;
                int skillNumber = 0;

                battle.SkillField(player, this);

                int skillChoice = Utility.Input(0, 3);

                switch (skillChoice)
                {
                    case 0:
                        BattleScene();
                        break;
                    default:
                        skillNumber = skill.SelectSkill(skillChoice);
                        break;
                }

                if (skillNumber == 1 && player.Mp >= 10)
                {
                    while (player.isDead == false)
                    {
                        battle.AttackField(player, this);

                        while (isMonsterLive)
                        {
                            int yourChoice = Utility.Input(0, count);

                            switch (yourChoice)
                            {
                                case 0:
                                    BattleScene();
                                    break;
                                default:
                                    isMonsterLive = skill.SkillAttack1(player, currentMonsters, yourChoice, skillNumber, isMonsterLive);
                                    break;
                            }
                        }

                        Utility.Input(0, 0);
                        monsterDeadCount = attack.MonsterAttack(player, currentMonsters, count);

                        if (monsterDeadCount <= 0 || player.isDead == true)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("원하시는 행동을 입력해주세요.");
                            Console.Write(">> ");
                            Utility.Input(0, 0);
                            ResultScene();
                            break;
                        }
                        else if (monsterDeadCount > 0)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("원하시는 행동을 입력해주세요.");
                            Console.Write(">> ");
                            Utility.Input(0, 0);
                            BattleScene();
                        }
                    }
                }
                else if (skillNumber == 2 && player.Mp >= 15)
                {
                    isMonsterLive = skill.SkillAttack2(player, currentMonsters, skillNumber, isMonsterLive);

                    Utility.Input(0, 0);
                    monsterDeadCount = attack.MonsterAttack(player, currentMonsters, count);

                    if (monsterDeadCount <= 0 || player.isDead == true)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">> ");
                        Utility.Input(0, 0);
                        ResultScene();
                        break;
                    }
                    else if (monsterDeadCount > 0)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">> ");
                        Utility.Input(0, 0);
                        BattleScene();
                    }
                }
                else if (skillNumber == 3 && player.Mp >= 30)
                {
                    isMonsterLive = skill.SkillAttack3(player, currentMonsters, skillNumber, isMonsterLive);

                    Utility.Input(0, 0);
                    monsterDeadCount = attack.MonsterAttack(player, currentMonsters, count);

                    if (monsterDeadCount <= 0 || player.isDead == true)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">> ");
                        Utility.Input(0, 0);
                        ResultScene();
                        break;
                    }
                    else if (monsterDeadCount > 0)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">> ");
                        Utility.Input(0, 0);
                        BattleScene();
                    }
                }
                else
                {
                    Console.Clear();
                    Utility.ColorWrite($"스킬 사용 불가", ConsoleColor.Red);
                    Console.WriteLine();
                    Console.WriteLine($"스킬 사용에 필요한 {player.Name} 님의 마나가 부족합니다.");
                    Console.WriteLine($"남은 마나 : {player.Mp}");
                    Console.WriteLine();
                    Utility.ColorWrite("0. 돌아가기", ConsoleColor.DarkCyan);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");

                    Utility.Input(0, 0);
                    monsterDeadCount = attack.MonsterAttack(player, currentMonsters, count);

                    if (monsterDeadCount <= 0 || player.isDead == true)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">> ");
                        Utility.Input(0, 0);
                        ResultScene();
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">> ");
                        Utility.Input(0, 0);
                    }
                }
            }   
        }

        public void ResultScene()       // 결과 화면
        {
            
            Utility.Loading("결과 화면 생성 중");

            result.ShowBattleResult(player, currentMonsters);
            dungeonitemSetting();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("0. 마을로 돌아가기.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            Utility.Input(0, 0);
            StartScene();
        }
    }
}