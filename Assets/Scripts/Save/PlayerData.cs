using Newtonsoft.Json;

public class PlayerData
{
    private int _playerClickAmount;

    public int PlayerClickAmount
    {
        get => _playerClickAmount;
        set
        {
            if (value < 0) throw new System.ArgumentOutOfRangeException(nameof(value));

            _playerClickAmount = value;
        }
    }

    private double _clickScore;

    public double ClickScore
    {
        get => _clickScore;
        set
        {
            if (value < 0) throw new System.ArgumentOutOfRangeException(nameof(value));

            _clickScore = value;
        }
    }


    public PlayerData()
    {
        _playerClickAmount = 1;
        _clickScore = 0;
    }

    [JsonConstructor]
    public PlayerData(int score, int playerClickAmount)
    {
        _clickScore = score;
        _playerClickAmount = playerClickAmount;
    }
}
