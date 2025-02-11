using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    public class Player         // 플레이어 관련 클래스
    {
        public int Level { get; set; }
        public string Name { get; }
        public string Job { get; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Gold { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public bool isDead { get; set; }
        public int Exp { get; set; }
        public int TotalExp { get; set; } 

        private int[] ExpLevelUp = { 0, 10, 35, 65, 100 };
        public Player(string name)
        {
            Name = name;
        }
        public void AddExp(int totalExp)
        {
            Exp += totalExp;
            
            while (Exp >= ExpLevelUp[Level])
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Level++;
            Attack = (int)(Attack + 0.5); 
            Defense += 1; 
            MaxHp += 10; 
            Hp = MaxHp;
            Console.WriteLine($"레벨업! {Level}레벨이 되었습니다.");
        }

       

        public Player(int level, string name, string job, int attak, int defense, int maxHp, int gold, bool dead ,int exp)  
        {
            Level = level;
            Name = name;
            Job = job;
            Attack = attak;
            Defense = defense;
            Gold = gold;
            Hp = maxHp;
            MaxHp = maxHp;
            isDead = dead;
            Exp = exp;
        }
       

        public void PlayerStats()            // 플레이어 정보 화면 메서드
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv. {Level.ToString("00")}");
            Console.WriteLine($"{Name} ( {Job} )");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체력 : {Hp} / {MaxHp}");
            Console.WriteLine($"Gold : {Gold} gold");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
        }
      
    }
}
