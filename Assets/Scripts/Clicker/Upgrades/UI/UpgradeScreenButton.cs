using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpgradeScreenButton : MonoBehaviour
{
    [SerializeField] private UpgradeScreen _screen;
    private Button _button;

    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick() 
    {
        _screen.ShowScreen();
    }

    void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }
}
