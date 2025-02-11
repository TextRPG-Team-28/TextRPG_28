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
        public int EquipAttack { get; set; }
        public int Defense { get; }
        public int EquipDefense { get; set; }
        public int Gold { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; }
        public bool isDead { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public Player(int level, string name, string job, int attak, int defense, int maxHp, int gold, bool dead)
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
            isDead = dead;
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

            string str = EquipAttack == 0 ? $"공격력 : {Attack}" : $"공격력 : {Attack + EquipAttack} (+{EquipAttack})";
            Console.WriteLine(str);
            str = EquipDefense == 0 ? $"방어력 : {Defense}" : $"방어력 : {Defense + EquipDefense} (+{EquipDefense})";
            Console.WriteLine(str);

            Console.WriteLine($"체력 : {Hp} / {MaxHp}");
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
    }
}
