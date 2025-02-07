using System;
using System.Threading;
namespace TextRPG_28;
class Program
{
    static void Main()
    {
        GameManager game = new GameManager();
        game.StartGame();
    }
}

class GameManager
{
    private int Level = 1;
    private string Name = "플레이어";  // 기본 이름 설정
    private string Job = "전사";
    private int Attack = 10;
    private int Defense = 5;
    private int Hp = 100;
    private int Gold = 50;

    private Random random = new Random();

    public void StartGame()
    {
        Console.Clear();
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("이제 모험을 시작할 수 있습니다.");

        MainScreen();
    }

    public void MainScreen()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n[ 마을 ]");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");

            int input = Choice.Getintput(1, 2);
            switch (input)
            {
                case 1:
                    ShowStatus();
                    break;
                case 2:
                    Battle();
                    break;

            }
        }
    }

    private void ShowStatus()
    {
        Console.Clear();
        Console.WriteLine("\n【 상태 보기 】");
        Console.WriteLine($"레벨 : {Level}");
        Console.WriteLine($"이름 : {Name}");
        Console.WriteLine($"직업 : {Job}");
        Console.WriteLine($"공격력 : {Attack}");
        Console.WriteLine($"방어력 : {Defense}");
        Console.WriteLine($"체력 : {Hp}");
        Console.WriteLine($"Gold : {Gold}\n");

        Console.WriteLine("나가기 : 0");

        int input = Choice.Getintput(0, 0);
        switch (input)
        {
            case 0:
                MainScreen();
                break;

        }
    }

    private void Battle()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine(" [전투 시작] ");
        Console.WriteLine("");

        int MonsterCont = random.Next(1, 5);
        List<Monster> monsters = new List<Monster>();
    }
}
class Monster
{
    public string Name { get; }
    public int Level { get; }
    public int Hp { get; }
    public int Attack { get; }
      
    public Monster(string name, int level, int hp, int attack)
    {
        Name = name;
        Level = level;
        Hp = hp;
        Attack = attack;
    }
    
}





