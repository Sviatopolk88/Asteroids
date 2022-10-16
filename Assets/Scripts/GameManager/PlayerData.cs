public class PlayerData
{
    public int Score { get; private set; }

    public void AddPoints(int points)
    {
        Score += points;
    }
}
