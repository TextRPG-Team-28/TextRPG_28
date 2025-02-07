using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    internal class BattleStart : Character
    {
        public void Battle()
        {
            Random random = new Random();
            int[] stageMonster = new int[random.Next(1, 5)];
            
            //foreach를 써서 리스를 한 번 훑어 
            //현재 전투에 생성되는 몬스터 배열을 하나 만들고, 배열 크기 안에서 랜덤 숫자 고르면 됨. 
        }
    }
}
