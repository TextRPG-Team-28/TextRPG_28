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
        public int EquipAttack { get; set; }
        public int Defense { get; set; }
        public int EquipDefense { get; set; }
        public int Gold { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Mp {  get; set; }
        public int MaxMp { get; set; }
        public bool isDead { get; set; }
        public int Exp { get; set; }
        public int TotalExp { get; set; }

        public int[] ExpLevelUp = { 0, 10, 35, 65, 100 };

        public Player(string name)
        {
            Name = name;
        }

        public Player(int level, string name, string job, int attak, int defense, int maxHp, int maxMp, int gold, bool dead ,int exp)  
        {
            Level = level;
            Name = name;
            Job = job;
            Attack = attak;
            EquipAttack = 0;
            Defense = defense;
            EquipDefense = 0;
            Gold = gold;
            Hp = maxHp;
            MaxHp = maxHp;
            Mp = maxMp;
            MaxMp = maxMp;
            isDead = dead;
            Exp = exp;
        }     

        public void PlayerStats()            // 플레이어 정보 화면
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("상태 보기");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine($"Lv. {Level.ToString("00")}");
            Console.WriteLine($"{Name} ( {Job} )");
            Console.WriteLine($"경험치 : {Exp}/{ExpLevelUp[Level]}");

            string str = EquipAttack == 0 ? $"공격력 : {Attack}" : $"공격력 : {Attack + EquipAttack} (+{EquipAttack})";
            Console.WriteLine(str);
            str = EquipDefense == 0 ? $"방어력 : {Defense}" : $"방어력 : {Defense + EquipDefense} (+{EquipDefense})";
            Console.WriteLine(str);

            Console.WriteLine($"체력 : {Hp} / {MaxHp}");
            Console.WriteLine($"마나 : {Mp} / {MaxMp}");
            Console.WriteLine($"Gold : {Gold} gold");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("0. 나가기");
            Console.ResetColor();
        }

        public void EquipItem(Item item)        // 장착 했을때
        {
            if (item.IsEquip)
            {
                UnEquip(item);
            }
            else
            {
                item.IsEquip = true;

                if (item.Type == ItemType.Weapon)
                    EquipAttack += item.Value;
                else
                    EquipDefense += item.Value;
            }
        }

        public void UnEquip(Item item)      // 장착 해제 할때
        {
            item.IsEquip = false;

            if (item.Type == ItemType.Weapon)
                EquipAttack -= item.Value;
            else
                EquipDefense -= item.Value;
        }

        public void AddExp(int totalExp)        // 경험치 관리
        {
            Exp += totalExp;

            while (Exp >= ExpLevelUp[Level])
            {
                LevelUp();
            }
        }

        private void LevelUp()      // 레벨업 관리
        {
            Level++;
            Attack = (int)(Attack + 1);
            Defense += 1;
            MaxHp += 10;
            MaxMp += 10;
            Hp = MaxHp;
            Mp = MaxMp;
            Console.WriteLine($"레벨업! {Level}레벨이 되었습니다.");
            Console.WriteLine();
            Console.WriteLine($"공격력 +1");
            Console.WriteLine($"방어력 +1");
            Console.WriteLine($"체력 +10");
            Console.WriteLine($"마나 +10");
            Console.WriteLine();
            Console.WriteLine($"체력이 최대치로 회복 되었습니다.");
            Console.WriteLine($"마나가 최대치로 회복 되었습니다.");
            Console.WriteLine();
        }
    }
}
