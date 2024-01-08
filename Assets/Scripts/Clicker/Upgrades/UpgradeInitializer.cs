using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UpgradeInitializer : MonoBehaviour
{
    [SerializeField] private Transform _spawnParent;
    [SerializeField] private UpgradeView _prefab;
    [SerializeField] private List<BaseUpgrade> _upgrades;
    private UpgradePurchaser _upgradePurchaser;

    [Inject]
    private void Construct(UpgradePurchaser purchaser)
    {
        _upgradePurchaser = purchaser;
    }

    void Awake()
    {
        foreach (var _upgrade in _upgrades)
        {
            var view = Instantiate(_prefab, _spawnParent);

            view.SetPriceText(_upgrade.CurrentUpgradeCost.ToString());

            view.PurchaseButton.onClick.AddListener(delegate { _upgradePurchaser.PurchaseUpgrade(_upgrade, view); });

        }

        //for (int i = 0; i < _upgrades.Count; i++)
        //{
        //    var view = Instantiate(_prefab, _spawnParent);

        //    view.SetPriceText(_upgrades[i].CurrentUpgradeCost.ToString());
            
        //    view.PurchaseButton.onClick.AddListener(delegate { _upgradePurchaser.PurchaseUpgrade(_upgrades[i], view); });
        //}
    }

}
