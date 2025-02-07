using static TextRPG_28.Character;

namespace TextRPG_28
{
    public class GameManager()
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();
            {
                warrior.Name = "Chad"; // 나중에 사용자 입력으로 바꾸기~
                warrior.Attack = 10;
                warrior.Health = 100;
                warrior.Defend = 5;
                warrior.Gold = 1500;
                warrior.Level = 1;
            }
         

            List<Monster> list = new List<Monster>();
            {
                new Monster("미니언", 2, 5, 15);
                new Monster("공허충", 3, 9, 10);
                new Monster("대포 미니언", 5, 8, 25);
            }
            GameStart gameStart = new GameStart();
            gameStart.StartScene(warrior);


        }
    }
}
