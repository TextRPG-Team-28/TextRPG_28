
using System.Dynamic;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks.Dataflow;

namespace TextRPG_28;

public class Player// 플레이어 스텟입력
{
    
        private List<Monster> monsters;
        BattleLogic Battlelogic;
    Player player;
    Battle battle;
    public int Level { get; }
    public string Name { get; set; }
    public string Job { get; set; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int MaxHp { get; set; } 
    public int Gold { get; set; }

    public Player(int levle, string name, string job, int atk, int def, int hp, int mp, int Maxhp, int gold)
    {
        Level = Level;
        Name = name;
        Job = job;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
        MaxHp = Maxhp;

        monsters = new List<Monster>();
    }
    public void Stats()
    {

        Console.Clear();
        Console.WriteLine("상태 보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다 .");
        Console.WriteLine($"LV {Level}");
        Console.WriteLine($"{Name}  ({Job})");
        Console.WriteLine($"공격력 : {Atk}");
        Console.WriteLine($"방어력 : {Def}");
        Console.WriteLine($"HP : {Hp}");
        Console.WriteLine($"Gold : {Gold} G");
        Console.WriteLine("");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("");
        Console.Write(">>");
    }



    public void BattleDis()
    {

        battle = new Battle();
        Console.Clear();
        Console.WriteLine("Battle!!");
        Console.WriteLine($"[내정보] Lv.{Level} {Name} ({Job}) HP {Hp}/{MaxHp}\n");
        battle.StartBattle();
        Console.WriteLine();
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv . {Level} {Name} ({Job})");
        Console.WriteLine($"Atk . {Atk}");
        Console.WriteLine($"HP {Hp}");
        Console.WriteLine();
        Console.WriteLine("1. 공격");
        int input = Selec.Input(1, 1);
        switch (input)
        {
            case 1:
                BattleLogic.Attack(monsters, player);
                break;
        }


    }


    public void InventoryItem()
    {
        Console.Clear();
    }
}
public class Monster
{
    public int Level { get; set; }  
    public string Name { get; set; }
    public int Atk { get; set; }
    public int Hp { get; set; }

    public Monster(int level, string name, int atk, int hp)
    {
        Level = level;
        Name = name;
        Atk = atk;
        Hp = hp;
    }
}