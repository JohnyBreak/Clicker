using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerClick : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private ClickHandler _clickObject;


    private Status _status;

    [Inject]
    private void Construct(Status status) 
    {
        _status = status;
    }

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
        _clickObject.Click(_status.PlayerClickAmount);
    }
}
