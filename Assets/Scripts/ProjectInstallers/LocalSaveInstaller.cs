using Zenject;
using UnityEngine;

public class LocalSaveInstaller : MonoInstaller
{
    [SerializeField] private SaveType _saveType = SaveType.Local;
    public enum SaveType
    {
        Local = 1,
        Cloud = 2,
    }

    public override void InstallBindings()
    {
        IDataProvider provider;
        IPersistentData data = new PersistentData();

        switch (_saveType)
        {
            case SaveType.Local:
                provider = new DataLocalProvider(data);
                break;
            case SaveType.Cloud:
                provider = new DataLocalProvider(data);//temp
                break;
            default:
                provider = new DataLocalProvider(data);//temp
                break;
        }

        if (provider.TryLoad() == false) data.PlayerData = new PlayerData();

        Container.Bind<IPersistentData>().FromInstance(data).AsSingle().NonLazy();
        Container.Bind<IDataProvider>().FromInstance(provider).AsSingle().NonLazy();
    }
}
