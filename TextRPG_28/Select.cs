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
            Console.Write(">> ");
        }
    }

    public static void ColorWrite(string str, ConsoleColor color)
    {
        Console.ForegroundColor = color; //텍스트 컬러 설정
        Console.WriteLine(str);
        Console.ResetColor();
    }

    public static void Loading()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Clear();
        Console.Write("Loading");
        string str = ".";

        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(75); //시간을 지연시킴
            Console.Write(str);
        }
        Console.ResetColor();
    }
}