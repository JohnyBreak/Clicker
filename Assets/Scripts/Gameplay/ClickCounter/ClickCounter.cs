using UnityEngine;

public class ClickCounter : MonoBehaviour
{
    [SerializeField] private ClickHandler _handler;
    [SerializeField] private ClickCounterView _view;

    private ClickCounterModel _model;

    private void Awake()
    {
        _model = new();
        UpdateView();
        _handler.ClickEvent += IncreaseCounter;
    }

    private void OnDestroy()
    {
        _handler.ClickEvent -= IncreaseCounter;
    }

    private void IncreaseCounter(int amount = 1) 
    {
        _model.Amount += amount;
        UpdateView();
    }

    private void UpdateView() 
    {
        _view.UpdateCounterText(_model.Amount.ToString());
    }
}
