using System.Dynamic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks.Dataflow;

namespace TextRPG_28;

class Player// 플레이어 스텟입력
{
        public int Levle { get; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; set; }
       
        public Player(int levle, string name,string job, int atk, int def, int hp, int gold)
        {
            Levle = levle;
            Name = name;
            Job = job;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
        public void Stats()
        {
            
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다 .");
            Console.WriteLine($"LV {Levle}" );
            Console.WriteLine($"{Name}  ({Job})" );
            Console.WriteLine($"공격력 : {Atk}" );
            Console.WriteLine($"방어력 : {Def}" );
            Console.WriteLine($"HP : {Hp}" );
            Console.WriteLine($"Gold : {Gold} G");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.Write(">>");
        }


        
        public void BattleDis()
        {
            Console.Clear();
            Console.WriteLine("Battle");
            Console.WriteLine();
            
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv . {Levle} {Name} ({Job})");
            Console.WriteLine($"HP {Hp}");   
            Console.WriteLine();
            Console.WriteLine("1. 공격");

            int input = Selec.Input(1, 1);
            switch (input)
            {
                case 1:
                
                    break;
            }
        }
}
