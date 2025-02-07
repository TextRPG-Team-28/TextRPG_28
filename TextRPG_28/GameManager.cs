using static TextRPG_28.Character;

namespace TextRPG_28
{
    public class GameManager()
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();
            {
                warrior.Attack = 10;
                warrior.Health = 100;
                warrior.Defend = 5;
                warrior.Gold = 1500;
                warrior.Level = 1;
            }

            GameStart gameStart = new GameStart();
            gameStart.StartScene(warrior);
        }
    }
}
