using UnityEngine;
using Zenject;

public class ClickCounter : MonoBehaviour
{
    [SerializeField] private ClickHandler _handler;
    [SerializeField] private ClickCounterView _view;

    private IPersistentData _data;
    private IDataProvider _dataProvider;

    private ClickCounterModel _model;

    [Inject]
    private void Construct(IPersistentData data, IDataProvider dataProvider) 
    {
        _data = data;
        _dataProvider = dataProvider;
        _model = new(data.PlayerData.ClickAmount);
    }

    private void Awake()
    {
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
        _data.PlayerData.ClickAmount = _model.Amount;
        _dataProvider.Save();
        UpdateView();
    }

    private void UpdateView() 
    {
        _view.UpdateCounterText(_model.Amount.ToString());
    }
}
