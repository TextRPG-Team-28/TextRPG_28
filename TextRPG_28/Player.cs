using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    
    public class Player         // 플레이어 관련 클래스
    {
        public int Level { get; set; }
        public int Exp { get; set; }
        public int MaxExp { get; set; }
        public string Name { get; }
        public string Job { get; }
        public float Attack { get; set; }
        public int Defense { get; set; }
        public int Gold { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; }
        public bool isDead { get; set; }
        

        public Player(string name )
        {
            Name = name;
        }
        
        
        public Player(int level,int exp,int maxexp, string name, string job, float attak, int defense, int maxHp,int gold, bool dead)  // 생성시 플레이어 초기 설정, 직업은 추가 예정이 아직 없기때문에 아직은 고정
        {
            Level = level;
            Exp = exp;
            MaxExp = maxexp;
            Name = name;
            Job = job;
            Attack = attak;
            Defense = defense;
            Gold = gold;
            Hp = maxHp;
            MaxHp = maxHp;
            isDead = dead;
        }

        public void PlayerStats(GameManeger gameManeger)            // 플레이어 정보 화면 메서드
        {
            gameManeger.Leveling();
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv. {Level.ToString("00")}");
            Console.WriteLine($"{Name} ( {Job} )");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체력 : {Hp} / {MaxHp}");
            Console.WriteLine($"경험치 :  {Exp} / {MaxExp}");
            Console.WriteLine($"Gold : {Gold} gold");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
        }
        


            

    }
}


