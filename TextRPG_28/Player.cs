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
        public int Level { get; }
        public string Name { get; }
        public string Job { get; }
        public int Attack { get; }
        public int Defense { get; }
        public int Gold { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; }

        public int Mp { get; } // 마나 추가
        public int MaxMp { get; } // 마나마나
        public bool isDead { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public Player(int level, string name, string job, int attak, int defense, int maxHp, int gold, int mp, int maxMp, bool dead)          // 생성시 플레이어 초기 설정, 직업은 추가 예정이 아직 없기때문에 아직은 고정
        {
            Level = level;
            Name = name;
            Job = job;
            Attack = attak;
            Defense = defense;
            Gold = gold;
            Hp = maxHp;
            MaxHp = maxHp;
            Mp = mp; // 스킬구현에 필요한 마나 추가된 부분
            MaxMp = maxMp; // 위와 동일
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
            Console.WriteLine($"MP : {Mp} / {MaxMp}"); // 스킬 구현 마나 추가된 부분
            Console.WriteLine($"Gold : {Gold} gold");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
        }
    }
}
