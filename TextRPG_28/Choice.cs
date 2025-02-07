using System;

namespace TextRPG_28
{
    internal class Choice
    {
        public static int Getintput(int min, int max)
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                if (int.TryParse(Console.ReadLine(), out var Input) && (Input >= min) && (Input <= max))
                    return Input;
                else
                {
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
        }
    }
}
