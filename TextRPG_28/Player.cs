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
        LevelUp levelUp;
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
        
        public Player(int level,int exp, string name, string job, float attak, int defense, int maxHp,int gold, bool dead)          // 생성시 플레이어 초기 설정, 직업은 추가 예정이 아직 없기때문에 아직은 고정
        {
            Level = level;
            Exp = exp;
            Name = name;
            Job = job;
            Attack = attak;
            Defense = defense;
            Gold = gold;
            Hp = maxHp;
            MaxHp = maxHp;
            isDead = dead;
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
            Console.WriteLine($"경험치 :  {Exp} / {MaxExp}");
            Console.WriteLine($"Gold : {Gold} gold");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
        }
        List<LevelUp> levelUps;
        public List<LevelUp> currentLevelUps = new List<LevelUp>();

        public void Leveling()
        {
            levelUps = new List<LevelUp>
            {
                new LevelUp(1, 0 , 10),
                new LevelUp(2, 0 , 30),
                new LevelUp(3, 0 , 65),
                new LevelUp(4, 0 , 100),
            };

            if(Exp >=  MaxExp)
            {
                Level++;
                Attack += 0.5f;
                Defense += 1;
                Exp = 0;
            }
        }
    }
}

