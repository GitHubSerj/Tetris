
[System.Serializable] 
public class PlayerInLeaderboard
{
    public string name;
    public int score;

    public PlayerInLeaderboard (string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
