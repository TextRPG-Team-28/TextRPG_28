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

           
            Monster monster1 = new Monster();
            {
                monster1.Name = "미니언";
                monster1.Attack = 5;
                monster1.Health = 15;
                monster1.Level = 2;                              
            }

            Monster monster2 = new Monster();
            {
                monster2.Name = "공허충";
                monster2.Attack = 9;
                monster2.Health = 10;
            }

            Monster monster3 = new Monster();
            {
                monster3.Name = "대포미니언";
                monster3.Attack = 8;
                monster3.Health = 25;
            }

            GameStart gameStart = new GameStart();
            gameStart.StartScene(warrior);


        }
    }
}
