using Zenject;

public class UpgradePurchaserInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UpgradePurchaser>().FromNew().AsSingle().NonLazy();
    }
}
