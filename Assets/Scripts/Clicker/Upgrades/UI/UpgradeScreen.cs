using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _screen;

    void Awake()
    {
        _exitButton.onClick.AddListener(CloseScreen);
    }

    void OnDestroy()
    {
        _exitButton.onClick.RemoveListener(CloseScreen);
    }

    public void ShowScreen()
    {
        _screen.SetActive(true);
    }

    private void CloseScreen() 
    {
        _screen.SetActive(false);
    }
}
