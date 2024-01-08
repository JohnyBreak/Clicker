using UnityEngine;

public abstract class BaseUpgrade : ScriptableObject
{
    public int UpgradeAmount = 1;
    public double OriginalUpgradeCost = 100;
    public double CurrentUpgradeCost = 100;
    public double CostIncreaseMultiplierPerPurchase = 0.05f;

    public string UpgradeButtonText;
    [TextArea(3, 10)]
    public string UpgradeButtonDescription;

    private void OnValidate()
    {
        CurrentUpgradeCost = OriginalUpgradeCost;
    }

    public abstract void ApplyUpgrade(Status status);
}
