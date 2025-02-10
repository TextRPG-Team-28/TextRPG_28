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
        bool isDead { get; set; }
    }

    public class Character
    {
        public class Player : ICharacter
        {
            public string Name { get; set; }
            public string Job { get; set; }
            public int Level { get; set; }
            public int Attack { get; set; }
            public int Health { get; set; }
            public int MaxHealth { get; set; }
            public int Defend { get; set; }
            public int Gold { get; set; }
            public bool isDead { get; set; }

            public Player(string name)
            {
                Name = name;
            }

            public Player(string name, string job, int level, int atk, int def, int maxhp, int gold, bool dead)
            {
                Name = name;
                Job = job;
                Level = level;
                Attack = atk;
                Defend = def;
                Gold = gold;
                Health = maxhp;
                MaxHealth = maxhp;
                isDead = dead;
            }
        }

        public class Monster : ICharacter
        {
            public string Name { get; set; }
            public int Level { get; set; }
            public int Attack { get; set; }
            public int Health { get; set; }
            public bool isDead { get; set; }

            public Monster(string name, int level, int attack, int hp, bool dead)
            {
                Name = name;
                Level = level;
                Attack = attack;
                Health = hp;
                isDead = dead;
            }
        }
    }
}
