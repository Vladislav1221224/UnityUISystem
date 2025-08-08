using System;
using System.Threading.Tasks;

using Zenject;

public class LoadingState : FsmState
{
    #region Constructors
    public LoadingState(Fsm fsm) : base(fsm) { }
    #endregion

    #region Proporties
    private SaveLoadSystem _saveLoadSystem;
    private LoadingScreenView _loadingScreenView;
    private MenuManager _menuManager;
    #endregion

    #region Methods

    [Inject]
    public void Construct(SaveLoadSystem saveLoadSystem, LoadingScreenView loadingScreenView, MenuManager menuManager)
    {
        _saveLoadSystem = saveLoadSystem;
        _loadingScreenView = loadingScreenView;
        _menuManager = menuManager;
    }
    public async override Task Enter()
    {
        _menuManager.OpenMenu("Loading");
        await LoadData();
    }
    private async Task LoadData()
    {
        var progress = new Progress<float>(p =>
        {
            _loadingScreenView.SetProgress(p);
        });

        GameData data = await _saveLoadSystem.GetData(progress);
    }
    #endregion
}
