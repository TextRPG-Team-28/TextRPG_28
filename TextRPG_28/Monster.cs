using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    public class Monster
    {
        public int Level { get; }
        public string Name { get; }
        public int Attack { get; }
        public int Hp { get; }
        public int MaxHp { get; }

        public Monster(int level, string name, int maxHp, int attack)
        {
            Level = level;
            Name = name;
            Attack = attack;
            Hp = maxHp;
            MaxHp = maxHp;
            Attack = attack;
        }
    }
}
