using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallServices();
        InstallViews();
    }

    void InstallServices()
    {
        Container.Bind<UISystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameStateMachine>().FromComponentInHierarchy().AsSingle();
        Container.Bind<SaveLoadSystem>().AsSingle();
        Container.Bind<MenuManager>().FromComponentInHierarchy().AsSingle();
    }
    void InstallViews()
    {
        Container.Bind<LoadingScreenView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameUIView>().FromComponentInHierarchy().AsSingle();
    }
}
