using System.Numerics;

namespace TextRPG_28
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.StartScene();
        }
    }

    public class GameManager            // static Main에서 쓰기 위해 만든 겜매니저(튜터님 해설영상보고 좋아보여서 써봄)
    {
        Player player;

        public GameManager()            // 생성시 플레이어 이름 받아옴
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.Write(">> ");
            string name = Console.ReadLine();

            player = new Player(1, name, 10, 5, 100, 1500);
        }

        public void StartScene()            // 시작 화면
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine();

            int input = Input.GetInput(1,2);            // Input클래스에서 만들어둔 입력 메서드 호출. 1, 2일때 해당 화면으로 이동, 아니면 계속 반복

            switch (input)
            {
                case 1:
                    PlayerInfoScene();          // 플레이어 정보 화면으로 이동
                    break;
                case 2:
                    BattleScene();          // 전투 화면으로 이동
                    break;

            }
        }

        public void PlayerInfoScene()           // 플레이어 정보 화면
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();

            player.PlayerInfo();            // Player클래스에서 만들어둔 정보 화면 메서드 호출

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Input.GetInput(0, 0);           //Input클래스에서 만들어둔 입력 메서드 호출, 만약 0이 아니면 계속 반복, 0 일때 시작화면으로 이동
            StartScene();
        }

        // ------------------------------ 여기서부턴 그냥 이렇게 하겠다만 작성 ------------------------------ //

        public void BattleScene()           // 전투 화면
        {
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();

            // 대충 랜덤 몬스터 출현, Monster클래스 만들어서 할 것 같음

            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv. {player.Level}  {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.Hp}/{player.MaxHp}");
            Console.WriteLine();
            Console.WriteLine("1. 공격");

            Input.GetInput(1, 1);           // 1 입력시 플레이어 공격 화면으로 이동, 아니면 계속 반복
            PlayerAttackScene();
        }

        public void PlayerAttackScene()         // 플레이어 공격 화면
        {
            Console.WriteLine("대충 플레이어 공격");
            // 몬스터 번호 입력 후 공격 행동 후 몬스터 공격씬으로 이동, 아마 Player클래스에 메서드 만들어서 하는게 좋지 않을까 생각 중
            MonsterAttackScene();
            // 만약 몬스터 다 잡았을때 승리 결과창으로 이동
            ResultVitory();
        }

        public void MonsterAttackScene()            // 몬스터 공격 화면
        {
            Console.WriteLine("대충 몬스터 공격");
            //살아있는 몬스터 위에서부터 플레이어한테 공격 후 다시 배틀씬으로 이동, Monster클래스에 메서드 만들어서 하는게 좋지 않을까 생각 중
            BattleScene();
            //만약 플레이어 체력이 0일때 패배 결과창으로 이동
            ResultDefeat();
        }

        public void ResultVitory()          // 승리 시 결과창
        {
            Console.Clear();
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine();
            Console.WriteLine("Vitory");
            //대충 몬스터 얼마나 잡고 어쩌고 결과창
            Console.WriteLine("0. 다음");

            Input.GetInput(0, 0);           // 0 입력시 시작화면으로
            StartScene();
        }

        public void ResultDefeat()          // 패배 시 결과창
        {
            Console.Clear();
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine();
            Console.WriteLine("You die...");
            // 대충 개발렸다 결과창
            Console.WriteLine("0. 다음");

            Input.GetInput(0, 0);           // 0 입력시 시작화면으로
            StartScene();
        }
    }
}
