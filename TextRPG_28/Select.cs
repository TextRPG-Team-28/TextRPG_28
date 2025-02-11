namespace TextRPG_28;

public class Select
{
    public static int Input(int min, int max)
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int input) && input >= min && input <= max)
                return input;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("잘못입력하셨습니다 다시 입력해주세요 .");
            Console.ResetColor();
            Console.Write(">> ");
        }
    }
}