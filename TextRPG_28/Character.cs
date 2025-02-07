using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    public interface ICharacter
    {
        string Name { get; set; }
        int Level { get; set; }
        int Attack { get; set; }
        int Health { get; set; }

    }

    public class Character
    {
        public class Warrior : ICharacter
        {
            public string Name { get; set; }
            public int Level { get; set; }
            public int Attack { get; set; }
            public int Health { get; set; }
            public int Defend { get; set; }
            public int Gold { get; set; }

        }

        public class Monster(string name, int level, int attack, int hp) : ICharacter
        {
            public string Name { get; set; } = name;
            public int Level { get; set; } = level;
            public int Attack { get; set; } = attack;
            public int Health { get; set; } = hp;

        }


    }   

    
}
