using Zenject;

public class UpgradePurchaser
{
    private Status _status;
    private CoinCounter _counter;

    [Inject]
    private void Construct(Status status, CoinCounter counter)
    {
        _status = status;
        _counter = counter;
    }

    public void PurchaseUpgrade(BaseUpgrade upgrade, UpgradeView view)
    {
        if (_counter.CoinAmount - upgrade.CurrentUpgradeCost < 0) return;

        upgrade.ApplyUpgrade(_status);
        _counter.DecreaseCoinAmount(upgrade.CurrentUpgradeCost);

    }
}
