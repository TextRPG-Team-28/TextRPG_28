
namespace TextRPG_28;

public class Selec
{

    public static int Input(int min, int max)
    {

        while (true)
        {
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            if (int.TryParse(Console.ReadLine(), out int input) && input >= min && input <= max)
                return input;

            Console.WriteLine("잘못입력하셨습니다 다시 입력해주세요 .");

        }


    }
}