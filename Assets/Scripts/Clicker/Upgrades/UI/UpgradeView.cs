using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _priceText;
    [SerializeField] private Button _purchaseButton;
    public Button PurchaseButton => _purchaseButton;

    public void SetPriceText(string price)
    {
        _priceText.text = price;
    }
}
