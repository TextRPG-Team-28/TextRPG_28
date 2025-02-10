using System.Numerics;
using static TextRPG_28.Character;

namespace TextRPG_28
{
    public class GameManager
    {
        public List<Character.Monster> monsterList = new List<Character.Monster>
        {
            new Character.Monster("미니언", 2, 5, 15, false),
            new Character.Monster("공허충", 3, 9, 10, false),
            new Character.Monster("대포 미니언", 5, 8, 25, false)
        };

        public static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            Scene scene = new Scene();

            while (true)
            {
                //Console.Clear();

                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("원하시는 이름을 설정해주세요.");
                Console.Write(">> ");
                string name = Console.ReadLine();
                Player player = new Player(name);

                Console.WriteLine();
                Console.WriteLine($"입력하신 이름은 '{player.Name}' 입니다.");
                Console.WriteLine();
                Console.WriteLine("1. 결정 하기");
                Console.WriteLine("2. 다시 입력");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int nameNum = Select.GetInput(1, 2);

                switch (nameNum)
                {
                    case 1:
                        scene.SelectJob(player);
                        break;
                    case 2:
                        break;
                }
            }
        }
    }
}
