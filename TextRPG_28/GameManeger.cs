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
        public static List<Item> inventory = new List<Item>();

        Battle battle = new Battle();
        Attack attack = new Attack();
        Result result = new Result();
        Skill skill = new Skill();

        public int stageLevel = 1; // 추가 스테이지 레벨
        
        public void MonsterSetting(int stageLevel)    // 몬스터 세팅 및 랜덤하게 생성 // 추가한 부분!!! 스
        {
            monsters = new List<Monster>
            {
                new Monster(1, "고블린", 15, 5, false),
                new Monster(2, "홉 고블린", 20, 8, false),
                new Monster(3, "오크", 25, 12, false),
                new Monster(4, "오우거", 40, 30, false)
            };

            Random random = new Random();
            float x = (stageLevel + 3) * 1.2f;
            
            int numberOfMonsters = (int)x;
            int maxstageLevel = (numberOfMonsters > 10) ? 10 : numberOfMonsters;

            int number = random.Next(maxstageLevel - 3, maxstageLevel);
            

            if (currentMonsters.Count < 1)
            {
                if(stageLevel <= 3)
                {
                    for (int i = 0; i < number; i++)
                    {
                        int stageMonster = random.Next(0, monsters.Count - 1);
                        Monster newMonster = new Monster(monsters[stageMonster].Level, monsters[stageMonster].Name, monsters[stageMonster].Hp, monsters[stageMonster].Attack, false);
                        Console.WriteLine($"Lv.{newMonster.Level}  {newMonster.Name}  HP {newMonster.Hp}");
                        currentMonsters.Add(newMonster);
                    }
                }
                else
                {
                    for (int i = 0; i < number; i++)
                    {
                        int stageMonster = random.Next(1, monsters.Count);
                        Monster newMonster = new Monster(monsters[stageMonster].Level, monsters[stageMonster].Name, monsters[stageMonster].Hp, monsters[stageMonster].Attack, false);
                        Console.WriteLine($"Lv.{newMonster.Level}  {newMonster.Name}  HP {newMonster.Hp}");
                        currentMonsters.Add(newMonster);
                    }
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

        static public List<Item> dropItems = new List<Item>     // 던전 드랍 아이템 세팅
        {
            new Item("더러운 누더기", ItemType.Amor, 3, "냄새가 나고 보잘것 없어보이지만 없는 것보다는 좋다.", 0),
            new Item("판금 갑옷", ItemType.Amor, 12, "겉보기엔 평범한 갑옷이지만 내구성이 뛰어나다.", 0),
            new Item("태양 불꽃 방패", ItemType.Amor, 20,"전설의 대장장이가 만든 방패다.", 0),
            new Item("부러진 단검", ItemType.Weapon, 4, "부러져있지만, 칼날은 아직 살아있어 사용하는데 문제는 없다.", 0),
            new Item("기사의 대검", ItemType.Weapon, 15, "어느 무명 기사가 사용하던 강력한 대검이다.", 0),
            new Item("무한의 대검", ItemType.Weapon,30,"전설의 대장장이가 만든 검이다.", 0),
            
        };

        public void ItemSetting()   // 아이템 세팅
        {
            itemList = new List<Item>
            {
                new Item("가죽 갑옷", ItemType.Amor, 5, "뻣뻣하지만 그래도 튼튼한 갑옷이다.", 1000),
                new Item("쇠사슬 갑옷", ItemType.Amor, 10, "무겁고 튼튼하다.혼자 입기도 힘들지만 그래도 목숨 값으로는 충분하다.", 2000),
                new Item("미지의 갑옷", ItemType.Amor, 15, "어느 미지의 생물체의 갑각으로 만든 갑옷이다.징그럽다.", 3000),
                new Item("롱소드", ItemType.Weapon, 5, "쉽게 보이지만 어려운 것이 검술이다.", 1000),
                new Item("나무꾼의 도끼", ItemType.Weapon, 10, "중고품이지만 단순하며 강력하다.", 3000),
                new Item("할버드", ItemType.Weapon, 20, "보병으로 기병을 쓰러뜨리기 위해서는 이것이 제격이다.", 5000),
            };
        }

        public void IntroScene()    // 이름 입력 화면
        {
            Console.Clear();
            Utility.ColorWrite("  _   _                      \r\n | \\ | |                     \r\n |  \\| | __ _ _ __ ___   ___ \r\n | . ` |/ _` | '_ ` _ \\ / _ \\\r\n | |\\  | (_| | | | | | |  __/\r\n |_| \\_|\\__,_|_| |_| |_|\\___|\r\n                             \r\n                             ", ConsoleColor.Green);
            Utility.ColorWrite("원하시는 이름을 설정해주세요.", ConsoleColor.Green);
            Console.WriteLine();
            Console.Write(">> ");
            string name = Console.ReadLine();

            player = new Player(name);

            Console.Clear();
            Utility.ColorWrite("  _   _                      \r\n | \\ | |                     \r\n |  \\| | __ _ _ __ ___   ___ \r\n | . ` |/ _` | '_ ` _ \\ / _ \\\r\n | |\\  | (_| | | | | | |  __/\r\n |_| \\_|\\__,_|_| |_| |_|\\___|\r\n                             \r\n                             ", ConsoleColor.Green);
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
            Utility.Loading("종족 목록 생성 중");

            Console.Clear();
            Utility.ColorWrite("  _____                     \r\n |  __ \\                    \r\n | |__) |__ _  ___ ___  ___ \r\n |  _  // _` |/ __/ _ \\/ __|\r\n | | \\ \\ (_| | (_|  __/\\__ \\\r\n |_|  \\_\\__,_|\\___\\___||___/\r\n                            \r\n                            ", ConsoleColor.Green);
            Utility.ColorWrite("종족을 선택해주세요.", ConsoleColor.Green);
            Console.WriteLine();
            Utility.ColorWrite("1. 인간  :  전체적으로 밸런스가 좋습니다.", ConsoleColor.DarkCyan);
            Utility.ColorWrite("2. 드워프  :  기초 자금이 많고 기본 마나가 적지만 높은 체력가지고 있습니다.", ConsoleColor.DarkCyan);
            Utility.ColorWrite("3. 엘프  :  공격력이 높고 기본 마나가 높지만 낮은 체력을 가지고 있습니다.", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int jobNum = Utility.Input(1, 3);

            switch (jobNum)
            {
                case 1:
                    player = new Player(1, player.Name, "인간", 12, 10, 150, 40, 600, false, 0);
                    break;
                case 2:
                    player = new Player(1, player.Name, "드워프", 10, 15, 200, 20, 1200, false, 0);
                    break;
                case 3:
                    player = new Player(1, player.Name, "엘프", 15, 5, 100, 60, 600, false, 0);
                    break;
            }

            Console.Clear();
            Utility.ColorWrite("  _____                     \r\n |  __ \\                    \r\n | |__) |__ _  ___ ___  ___ \r\n |  _  // _` |/ __/ _ \\/ __|\r\n | | \\ \\ (_| | (_|  __/\\__ \\\r\n |_|  \\_\\__,_|\\___\\___||___/\r\n                            \r\n                            ", ConsoleColor.Green);
            Utility.ColorWrite("종족 선택", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine($"선택하신 종족은 '{player.Job}' 입니다.");
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
            Utility.ColorWrite("        _ _ _                  \r\n       (_) | |                 \r\n __   ___| | | __ _  __ _  ___ \r\n \\ \\ / / | | |/ _` |/ _` |/ _ \\\r\n  \\ V /| | | | (_| | (_| |  __/\r\n   \\_/ |_|_|_|\\__,_|\\__, |\\___|\r\n                     __/ |     \r\n                    |___/      ", ConsoleColor.Green);
            Console.WriteLine();
            Utility.ColorWrite("1. 상태 보기", ConsoleColor.DarkCyan);
            Utility.ColorWrite("2. 인벤토리", ConsoleColor.DarkCyan);
            Utility.ColorWrite("3. 상점", ConsoleColor.DarkCyan);
            Utility.ColorWrite("4. 휴식 하기", ConsoleColor.DarkCyan);
            Utility.ColorWrite($"5. 던전 입장  (현재 진행 : {stageLevel} 층) ",ConsoleColor.DarkCyan); // 수정
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
            Utility.ColorWrite("  _____                      _                   \r\n |_   _|                    | |                  \r\n   | |  _ ____   _____ _ __ | |_ ___  _ __ _   _ \r\n   | | | '_ \\ \\ / / _ \\ '_ \\| __/ _ \\| '__| | | |\r\n  _| |_| | | \\ V /  __/ | | | || (_) | |  | |_| |\r\n |_____|_| |_|\\_/ \\___|_| |_|\\__\\___/|_|   \\__, |\r\n                                            __/ |\r\n                                           |___/ ", ConsoleColor.Green);
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
            Utility.ColorWrite("  ______            _                      _ \r\n |  ____|          (_)                    | |\r\n | |__   __ _ _   _ _ _ __  _ __   ___  __| |\r\n |  __| / _` | | | | | '_ \\| '_ \\ / _ \\/ _` |\r\n | |___| (_| | |_| | | |_) | |_) |  __/ (_| |\r\n |______\\__, |\\__,_|_| .__/| .__/ \\___|\\__,_|\r\n           | |       | |   | |               \r\n           |_|       |_|   |_|               ", ConsoleColor.Green);
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
            Utility.ColorWrite("   _____ _                 \r\n  / ____| |                \r\n | (___ | |_ ___  _ __ ___ \r\n  \\___ \\| __/ _ \\| '__/ _ \\\r\n  ____) | || (_) | | |  __/\r\n |_____/ \\__\\___/|_|  \\___|\r\n                           \r\n                           ", ConsoleColor.Green);
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
            Utility.ColorWrite("  _____                _                    \r\n |  __ \\              | |                   \r\n | |__) |   _ _ __ ___| |__   __ _ ___  ___ \r\n |  ___/ | | | '__/ __| '_ \\ / _` / __|/ _ \\\r\n | |   | |_| | | | (__| | | | (_| \\__ \\  __/\r\n |_|    \\__,_|_|  \\___|_| |_|\\__,_|___/\\___|\r\n                                            \r\n                                            ", ConsoleColor.Green);
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
            Utility.ColorWrite("  _____           _   \r\n |  __ \\         | |  \r\n | |__) |___  ___| |_ \r\n |  _  // _ \\/ __| __|\r\n | | \\ \\  __/\\__ \\ |_ \r\n |_|  \\_\\___||___/\\__|\r\n                      \r\n                      ", ConsoleColor.Green);
            Console.WriteLine("이곳에서 휴식을 취해 체력을 회복할 수 있습니다.");
            Console.WriteLine();
            Utility.ColorWrite("1. 짧은 휴식 하기 ( 300 gold 소모, 체력 30, 마나 20 회복 )", ConsoleColor.DarkCyan);
            Utility.ColorWrite("2. 충분한 휴식 하기 ( 600 gold 소모, 체력 60, 마나 40 회복 )", ConsoleColor.DarkCyan);
            Console.WriteLine();
            Utility.ColorWrite($"현재 체력 : {player.Hp}", ConsoleColor.DarkYellow);
            Utility.ColorWrite($"현재 마나 : {player.Mp}", ConsoleColor.DarkYellow);
            Utility.ColorWrite($"소지금 : {player.Gold}", ConsoleColor.DarkYellow);
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
            if (player.Gold >= 300 * price)
            {
                int currentHp = player.Hp;
                int currentMp = player.Mp;
                int currentGold = player.Gold;

                player.isDead = false;
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
                Utility.ColorWrite("   _____                      _      _       \r\n  / ____|                    | |    | |      \r\n | |     ___  _ __ ___  _ __ | | ___| |_ ___ \r\n | |    / _ \\| '_ ` _ \\| '_ \\| |/ _ \\ __/ _ \\\r\n | |___| (_) | | | | | | |_) | |  __/ ||  __/\r\n  \\_____\\___/|_| |_| |_| .__/|_|\\___|\\__\\___|\r\n                       | |                   \r\n                       |_|                   ", ConsoleColor.Green);
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
                Utility.ColorWrite("  _____                               _ _     _      \r\n |_   _|                             (_) |   | |     \r\n   | |  _ __ ___  _ __   ___  ___ ___ _| |__ | | ___ \r\n   | | | '_ ` _ \\| '_ \\ / _ \\/ __/ __| | '_ \\| |/ _ \\\r\n  _| |_| | | | | | |_) | (_) \\__ \\__ \\ | |_) | |  __/\r\n |_____|_| |_| |_| .__/ \\___/|___/___/_|_.__/|_|\\___|\r\n                 | |                                 \r\n                 |_|                                 ", ConsoleColor.Red);
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
                Utility.ColorWrite("  _____                               _ _     _      \r\n |_   _|                             (_) |   | |     \r\n   | |  _ __ ___  _ __   ___  ___ ___ _| |__ | | ___ \r\n   | | | '_ ` _ \\| '_ \\ / _ \\/ __/ __| | '_ \\| |/ _ \\\r\n  _| |_| | | | | | |_) | (_) \\__ \\__ \\ | |_) | |  __/\r\n |_____|_| |_| |_| .__/ \\___/|___/___/_|_.__/|_|\\___|\r\n                 | |                                 \r\n                 |_|                                 ", ConsoleColor.Red);
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
            
            if(player.Hp > 0)
            {
                battle.BattelField(player, monsters, this, stageLevel);

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
                Utility.ColorWrite("  _____                               _ _     _      \r\n |_   _|                             (_) |   | |     \r\n   | |  _ __ ___  _ __   ___  ___ ___ _| |__ | | ___ \r\n   | | | '_ ` _ \\| '_ \\ / _ \\/ __/ __| | '_ \\| |/ _ \\\r\n  _| |_| | | | | | |_) | (_) \\__ \\__ \\ | |_) | |  __/\r\n |_____|_| |_| |_| .__/ \\___/|___/___/_|_.__/|_|\\___|\r\n                 | |                                 \r\n                 |_|                                 ", ConsoleColor.Red);
                Console.WriteLine();
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
                else if (skillNumber == 3 && player.Mp >= 20)
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
                    Utility.ColorWrite("  _____                               _ _     _      \r\n |_   _|                             (_) |   | |     \r\n   | |  _ __ ___  _ __   ___  ___ ___ _| |__ | | ___ \r\n   | | | '_ ` _ \\| '_ \\ / _ \\/ __/ __| | '_ \\| |/ _ \\\r\n  _| |_| | | | | | |_) | (_) \\__ \\__ \\ | |_) | |  __/\r\n |_____|_| |_| |_| .__/ \\___/|___/___/_|_.__/|_|\\___|\r\n                 | |                                 \r\n                 |_|                                 ", ConsoleColor.Red);
                    Utility.ColorWrite($"스킬 사용 불가", ConsoleColor.Red);
                    Console.WriteLine();
                    Console.WriteLine($"스킬 사용에 필요한 {player.Name} 님의 마나가 부족합니다.");
                    Console.WriteLine($"{player.Name} 님의 턴이 스킵됩니다.");
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
            Console.Clear();

            result.ShowBattleResult(player, currentMonsters, this);

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