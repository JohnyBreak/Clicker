using UnityEngine;
using Zenject;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private ClickHandler _handler;
    [SerializeField] private CoinCounterView _view;

    private IPersistentData _data;
    private IDataProvider _dataProvider;

    private ClickCounterModel _model;

    public double CoinAmount => _model.Amount;
    //{
    //    get { return _model.Amount; }
    //    set {
    //        if (_model.Amount + value < 0)
    //        {
    //            throw new System.ArgumentOutOfRangeException(nameof(value));
    //        }
    //        else 
    //        {
    //            UpdateCoinAmount(value);
    //        } 
    //    }
    //}

    [Inject]
    private void Construct(IPersistentData data, IDataProvider dataProvider) 
    {
        _data = data;
        _dataProvider = dataProvider;
        _model = new(data.PlayerData.ClickScore);
    }

    private void Awake()
    {
        UpdateView();
        _handler.ClickEvent += IncreaseCoinAmount;
    }

    private void OnDestroy()
    {
        _handler.ClickEvent -= IncreaseCoinAmount;
    }

    private void UpdateCoinAmount(double amount) 
    {
        _model.Amount += amount;
        _data.PlayerData.ClickScore = _model.Amount;
        _dataProvider.Save();
        UpdateView();
    }

    public void IncreaseCoinAmount(double amount)
    {
        UpdateCoinAmount(amount);
    }
    public void DecreaseCoinAmount(double amount)
    {

        UpdateCoinAmount(-amount);
    }

    private void UpdateView() 
    {
        _view.UpdateCounterText(_model.Amount.ToString());
    }
}
