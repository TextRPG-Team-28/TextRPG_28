using static TextRPG_28.Character;

namespace TextRPG_28
{
    public class GameManager()
    {
        delegate void MonsterArray();

        
        static public void Main(string[] args)
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


            GameStart gameStart = new GameStart();
            gameStart.StartScene(warrior);

            BattleStart battleStart = new BattleStart();


            AllAttack allAttack = new AllAttack();

           

        }
    }
}
