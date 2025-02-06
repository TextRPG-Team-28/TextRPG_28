using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    static class Input          // 키입력 관련 클래스
    {
        public static int GetInput(int min, int max)            // min, max의 값 이내의 숫자 입력시 input을 return 반복문 탈출. 그 외에는 잘못 입력됫다는 텍스트 출력 후 반복
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                if (int.TryParse(Console.ReadLine(), out int input) && (input >= min) && (input <= max))
                {
                    Console.WriteLine(input);
                    return input;
                }                 

                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                Console.WriteLine();
            }
        }
    }
}
