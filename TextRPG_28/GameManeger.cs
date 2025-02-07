
using System.Dynamic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace TextRPG_28
{
    public class GameManeger
    {
        Player player;

        public void Intro() //처음시작 이름 입력
        {
            Console.Clear();


            Console.WriteLine("플레이어 이름을 입력해주세요 ");
            player = new Player(0, "", "", 0, 0, 0, 0, 0);
            player.Name = (Console.ReadLine());

            Console.WriteLine("입력하신 이름은 " + player.Name + "입니다 .");

            Console.WriteLine("1. 저장");
            Console.WriteLine("2. 취소");

            int inname = Selec.Input(1, 2);
            switch (inname)
            {
                case 1:
                    Job();
                    break;
                case 2:
                    Intro();
                    break;
            }

        }

        public void Job() // 직업선택
        {
            Console.Clear();
            Console.WriteLine("직업을 선택해주세요 ");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 도적");


            int injob = Selec.Input(1, 2);
            switch (injob)
            {
                case 1:
                    player = new Player(1, player.Name, "", 10, 10, 150, 50, 1500);
                    player.Job = "전사";
                    break;
                case 2:
                    player = new Player(1, player.Name, "", 15, 5, 100, 50, 1500);
                    player.Job = "도적";
                    break;
            }

            Console.Clear();
            Console.WriteLine("선택하신 직업은 " + player.Job + "입니다.");

            Console.WriteLine("1. 저장");
            Console.WriteLine("2. 다시선택");
            int Selected = Selec.Input(1, 2);
            switch (Selected)
            {
                case 1:
                    Start();
                    break;
                case 2:
                    Job();
                    break;
            }



        }

        public void Start() // 처음시작화면
        {

            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다 .");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점 ");
            Console.WriteLine("4. 전투 시작");
            Console.WriteLine("5. 회복 아이템");
            Console.WriteLine();

            int input = Selec.Input(1, 5);
            switch (input)
            {
                case 1:
                    StatsDis();
                    break;
                case 2:
                    Inventory();
                    break;
                case 3:
                    Shop();
                    break;
                case 4:
                    BattleStage();
                    break;
                case 5:
                    Posion();
                    break;
            }

        }

        public void StatsDis() // 상태창
        {
            player.Stats();
            int input = Selec.Input(0, 0);
            switch (input)
            {
                case 0:
                    Start();
                    break;
            }
        }



        public void Inventory() //인벤토리
        {
            player.InventoryItem();
        }

        public void Shop()
        {

        }

        public void BattleStage() // 배틀 스테이지
        {
            player.BattleDis();

        }

        public void Posion()
        {

        }



        static void Main(string[] args)
        {
            GameManeger intro = new GameManeger();
            intro.Intro();
        }
    }



}



