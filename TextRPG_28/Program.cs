using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace TextRPG_28
{           
    public class Program
    {
        Player player;
        

        public void Intro()//처음시작 이름 입력
        {
            Console.Clear();
            player = new Player(1,"" ,"", 6, 7, 100, 1500);
            
            Console.WriteLine("플레이어 이름을 입력해주세요 ");
            
            player.Name =  (Console.ReadLine());
       
            Console.WriteLine("입력하신 이름은 " + player.Name + "입니다 .");
            
            Console.WriteLine("1. 저장");
            Console.WriteLine("2. 취소");

            int inname = Selec.Input(1, 2);
            switch(inname)
            {
                case 1:
                    Job();
                    break;
                case 2:
                    Intro();
                    break;
            }

    }

        public void Job()// 직업선택
        {
            Console.Clear();
            Console.WriteLine("직업을 선택해주세요 ");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 도적");
            
            
            int injob = Selec.Input(1, 2);
            switch(injob)
            {
                case 1:
                    player.Job = "전사";
                    break;
                case 2:
                    player.Job = "도적";
                    break;
            }
            Console.Clear();
            Console.WriteLine("선택하신 직업은 "+player.Job + "입니다.");
            
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
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine();
            
            int input = Selec.Input(1, 2);
            switch (input)
            {
                case 1:
                    StatsDis();
                    break;
                case 2:
                    BattleStage();
                    break;
                default:
                    Intro();
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
                    Intro();
                    break;
            }
        }

        public void BattleStage()// 배틀 스테이지
        {
            player.BattleDis();
            int input = Selec.Input(1, 1);
            switch (input)
            {
                case 1:
                    
                    break;
            }
        }
        static void Main(string[] args)
        {
            Program intro = new Program();
            intro.Intro();
        }
        }
  
    
    
}



