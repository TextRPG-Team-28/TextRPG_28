using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    internal class Skill
    {
        public bool Skill_1()
        {
            Console.WriteLine("스킬 1인타겟 공격력 2배  마나 10");
            return true;
        }

        public bool Skill_2()
        {
            Console.WriteLine("스킬 2인랜덤타겟 공격력 1.5배  마나 20");
            return true;
        }

        public bool Skill_3()
        {
            Console.WriteLine("스킬 3 전체타겟 공격력 1.2배  마나 30");
            return true;
        }
    }
}
