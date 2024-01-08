using UnityEngine;
using Zenject;

public class CoinCounterInstaller : MonoInstaller
{
    [SerializeField] private CoinCounter _coinCounter;

    public override void InstallBindings()
    {
        Container.Bind<CoinCounter>().FromInstance(_coinCounter).AsSingle().NonLazy();
    }
}
