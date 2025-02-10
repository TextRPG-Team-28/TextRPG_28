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

        public class Monster : ICharacter
        {
            public string Name { get; set; } 
            public int Level { get; set; } 
            public int Attack { get; set; } 
            public int Health { get; set; }
          

            public Monster(string name, int level, int attack, int hp)
            {
                Name = name;
                Level = level;
                Attack = attack;
                Health = hp;
            }


        }


    }   

    
}
