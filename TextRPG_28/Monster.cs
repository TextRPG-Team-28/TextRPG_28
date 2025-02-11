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
        public int Hp { get; set; }
        public int MaxHp {  get; set; }
        public bool isDead { get; set; }

        public Monster(int level, string name, int maxhp, int attack, bool dead)
        {
            Level = level;
            Name = name;
            Attack = attack;
            Hp = maxhp;
            MaxHp = maxhp;
            Attack = attack;
            isDead = dead;
        }
    }
}
