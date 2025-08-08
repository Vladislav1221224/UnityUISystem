using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallFSM();
        InstallServices();
        InstallViews();
    }
    void InstallFSM()
    {
        Container.Bind<Fsm>().AsTransient();

        Container.Bind<LoadingState>().AsTransient();
        Container.Bind<GamePlayState>().AsTransient();
    }
    void InstallServices()
    {
        Container.Bind<UISystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<MenuManager>().FromComponentInHierarchy().AsSingle();

        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<SaveLoadSystem>().AsSingle();
    }
    void InstallViews()
    {
        Container.Bind<LoadingScreenView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameUIView>().FromComponentInHierarchy().AsSingle();
    }
}
