using System.ComponentModel;

namespace TextRPG_28;

public class Battle
{
    
    class Monster// 몬스터 리스트 
    {
        public int Levle { get; }
        public string Name { get; }
        public int Atk { get; }
        public int Hp { get; }
    

        public Monster(int levle, string name, int atk,int hp)
        {  
            
            Levle = levle;
            Name = name;
            Atk = atk;
            Hp = hp;
        }

        public void Mosters()
        {

            List<Monster> monsterList;
            monsterList = new List<Monster>();
            {
                new Monster(2, "미니언", 5 , 15);
                new Monster(3, "공허충", 9 , 10);
                new Monster(5, "대포미니언", 8 , 25);
            }
            
         
            
        }
    }




}

