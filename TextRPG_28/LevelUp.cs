namespace TextRPG_28;

public class LevelUp
{
    Player player;
    List<LevelUp> levelUps;
    public List<LevelUp> currentLevelUps = new List<LevelUp>();
    public int Level {get; set; }
    public int Exp { get; set; }
    public int MaxExp { get; set; }

    public LevelUp(int level, int exp, int maxexp)
    {
        Level = level;
        Exp = exp; 
        MaxExp = maxexp;
    }
}