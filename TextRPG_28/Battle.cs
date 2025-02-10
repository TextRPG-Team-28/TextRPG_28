
using System.ComponentModel;


namespace TextRPG_28;

public class Battle
{
    private List<Monster> monsterTemplates;

    Player player;
    public Battle()
    { 
        monsterTemplates = new List<Monster>
        {
            new Monster(2, "미니언", 5, 15),
            new Monster(3, "공허충", 9, 10),
            new Monster(5, "대포미니언", 8, 25)


        };
    }

    public List<Monster> Genmonsters()
    {
        Random rand = new Random();
        int monsterCount = rand.Next(1, 5); // 1~4마리 등장
        List<Monster> monsters = new List<Monster>();

        for (int i = 0; i < monsterCount; i++)
        {
            // 랜덤 몬스터 선택 (중복 가능)
            Monster randomMonster = monsterTemplates[rand.Next(monsterTemplates.Count)];
            monsters.Add(new Monster(randomMonster.Level, randomMonster.Name, randomMonster.Atk, randomMonster.Hp));
        }

        return monsters.OrderBy(m => rand.Next()).ToList(); // 몬스터 순서 랜덤화
    }

    public void StartBattle()
    {


        List<Monster> monsters = Genmonsters(); // 몬스터 생성

        for (int i = 0; i < monsters.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Lv.{monsters[i].Level} {monsters[i].Name} HP {monsters[i].Hp}");
        }
    }
}