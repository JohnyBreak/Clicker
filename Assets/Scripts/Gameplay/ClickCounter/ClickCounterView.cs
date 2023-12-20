using TMPro;
using UnityEngine;

public class ClickCounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    public void UpdateCounterText(string text)
    {
        _counterText.text = text;
    }
}
