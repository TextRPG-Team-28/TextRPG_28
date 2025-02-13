using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utility.ColorWrite("  _______        _     _____  _____   _____ \r\n |__   __|      | |   |  __ \\|  __ \\ / ____|\r\n    | | _____  _| |_  | |__) | |__) | |  __ \r\n    | |/ _ \\ \\/ / __| |  _  /|  ___/| | |_ |\r\n    | |  __/>  <| |_  | | \\ \\| |    | |__| |\r\n    |_|\\___/_/\\_\\\\__| |_|  \\_\\_|     \\_____|\r\n                                            \r\n                                            ", ConsoleColor.White);
            Utility.ColorWrite("     ______          _                  \r\n    |  ____|        | |                 \r\n    | |__ __ _ _ __ | |_ __ _ ___ _   _ \r\n    |  __/ _` | '_ \\| __/ _` / __| | | |\r\n    | | | (_| | | | | || (_| \\__ \\ |_| |\r\n    |_|  \\__,_|_| |_|\\__\\__,_|___/\\__, |\r\n                                   __/ |\r\n                                  |___/ ", ConsoleColor.Magenta);
            Console.ReadLine();

            Utility.Loading("이름 설정 화면으로 이동중");

            GameManeger gm = new GameManeger();

            gm.ItemSetting();
            gm.IntroScene();
        }
    }
}
