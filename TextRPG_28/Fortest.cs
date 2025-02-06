using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    internal class Fortest
    {
        public interface ICharacter
        {
            string Name { get; set; }
            int Level { get; set; }
            int Attack { get; set; }
            int Health { get; set; }
            int Defend { get; set; }
            int Gold { get; set; }

        }

        public class Warrior : ICharacter
        {
            public string Name { get; set; }
            public int Level { get; set; }
            public int Attack { get; set; }
            public int Health { get; set; }
            public int Defend { get; set; }
            public int Gold { get; set; }


        }


        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();
            {
                warrior.Attack = 10;
                warrior.Health = 100;
                warrior.Defend = 5;
                warrior.Gold = 1500;
                warrior.Level = 1;
            }
        }

    }
}
