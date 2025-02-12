namespace TextRPG_28;

public class Utility
{
    public static int Input(int min, int max)   // 키 입력 관리
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int input) && input >= min && input <= max)
                return input;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("잘못입력하셨습니다 다시 입력해주세요 .");
            Console.Write(">> ");
        }
    }

    public static void ColorWrite(string str, ConsoleColor color)   // 글자 색 관리
    {
        Console.ForegroundColor = color;
        Console.WriteLine(str);
        Console.ResetColor();
    }

    public static void Loading(string str)      // 로딩 효과
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Clear();
        Console.Write(str);
        string dot = ".";

        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(75);
            Console.Write(dot);
        }
        Console.ResetColor();
    }
}