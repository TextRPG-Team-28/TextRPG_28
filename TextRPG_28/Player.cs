using System;
using System.Collections.Generic;
using System.Linq;
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
        public int Hp { get; }
        public int MaxHp { get; }

        public Player(int level, string name, int attak, int defense, int maxHp, int gold)          // 생성시 플레이어 초기 설정, 직업은 추가 예정이 아직 없기때문에 아직은 고정
        {
            Level = level;
            Name = name;
            Job = "전사";
            Attack = attak;
            Defense = defense;
            Gold = gold;
            Hp = maxHp;
            MaxHp = maxHp;
        }

        public void PlayerInfo()            // 플레이어 정보 화면 메서드
        {
            Console.WriteLine($"Lv. {Level.ToString("00")}");
            Console.WriteLine($"{Name} ( {Job} )");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체력 : {Hp} / {MaxHp}");
            Console.WriteLine($"Gold : {Gold} gold");
        }
    }
}
