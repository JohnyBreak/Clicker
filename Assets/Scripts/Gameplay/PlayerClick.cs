using UnityEngine;
using UnityEngine.UI;

public class PlayerClick : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private ClickHandler _clickObject;
    
    private void Awake()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _clickObject.Click();
    }
}
