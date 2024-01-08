using UnityEngine;

[CreateAssetMenu(fileName = "ClickAmountUpgrade", menuName = "Upgrades/ClickAmountUpgrade")]
public class ClickAmountUpgrade : BaseUpgrade
{
    public override void ApplyUpgrade(Status status)
    {
        status.IncreasePlayerClickAmount(UpgradeAmount);
    }
}
