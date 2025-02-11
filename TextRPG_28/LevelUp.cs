namespace TextRPG_28;

public class LevelUp
{
    Player Player;
    List<LevelUp> levelUps;
    public List<LevelUp> currentLevelUps = new List<LevelUp>();
    
    public LevelUp( int exp, int maxexp)
    {
        Player.Exp = exp; 
        Player.MaxExp = maxexp;
    }
}