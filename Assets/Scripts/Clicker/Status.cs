using Zenject;

public class Status
{
    private int _playerClickAmount = 1;
    public int PlayerClickAmount => _playerClickAmount;

    IPersistentData _data;

    [Inject]
    private void Construct(IPersistentData data)
    {
        _data = data;
        _playerClickAmount = _data.PlayerData.PlayerClickAmount;
    }

    public void IncreasePlayerClickAmount(int newAmount) 
    {
        _playerClickAmount += newAmount;
        _data.PlayerData.PlayerClickAmount = _playerClickAmount;
    }
}
