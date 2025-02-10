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
            Character.Warrior warrior = new Character.Warrior
            {
                Name = "Chad",
                Attack = 50,
                Health = 100,
                Defend = 5,
                Gold = 1500,
                Level = 1
            };

            GameManager gameManager = new GameManager();
            GameStart gameStart = new GameStart();
            gameStart.StartScene(warrior, gameManager.monsterList);
        }
    }
}
