using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    static class Select
    {
        public static int GetInput(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input) && (input >= min) && (input <= max))
                {
                    return input;
                }

                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                Console.Write(">> ");
            }
        }
    }
}
