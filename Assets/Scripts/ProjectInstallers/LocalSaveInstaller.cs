using Zenject;

public class LocalSaveInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        IDataProvider provider;
        IPersistentData data = new PersistentData();
        provider = new DataLocalProvider(data);

        if (provider.TryLoad() == false) data.PlayerData = new PlayerData();

        Container.Bind<IPersistentData>().FromInstance(data).AsSingle().NonLazy();
        Container.Bind<IDataProvider>().FromInstance(provider).AsSingle().NonLazy();
    }
}
