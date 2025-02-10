using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    public class Attack
    {
        public void PlayerAttack(Player player, List<Monster> monsters, int attackNum)
        {
            switch (attackNum)
            {
                case 0:
                    player.IsAttack = false;
                    break;
                case 1:
                    if (monsters[0].isDead == false)
                    {
                        monsters[0].Hp -= player.Attack;

                        if (monsters[0].Hp <= 0)
                        {
                            monsters[0].isDead = true;
                        }       
                    }
                    break;
                case 2:
                    if (monsters[1].isDead == false)
                    {
                        monsters[1].Hp -= player.Attack;

                        if (monsters[1].Hp <= 0)
                        {
                            monsters[1].isDead = true;
                        }
                    }
                    break;
                case 3:
                    if (monsters[2].isDead == false)
                    {
                        monsters[2].Hp -= player.Attack;

                        if (monsters[2].Hp <= 0)
                        {
                            monsters[2].isDead = true;
                        }
                    }
                    break;
                case 4:
                    if (monsters[3].isDead == false)
                    {
                        monsters[3].Hp -= player.Attack;

                        if (monsters[3].Hp <= 0)
                        {
                            monsters[3].isDead = true;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }

        public void MonsterAttack(Player player, List<Monster> monsters)
        {

        }
    }
}
