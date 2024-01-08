using Zenject;

public class StatusInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Status>().FromNew().AsSingle().NonLazy();
    }
}
