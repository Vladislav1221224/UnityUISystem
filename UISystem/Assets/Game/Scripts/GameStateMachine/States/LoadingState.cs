using System;
using System.Threading.Tasks;

using UnityEngine;

using Zenject;

public class LoadingState : FsmState
{
    #region Constructors
    public LoadingState(Fsm fsm) : base(fsm) { }
    #endregion

    #region Proporties
    private SaveLoadSystem _saveLoadSystem;
    private UISystem _uiSystem;
    private MenuManager _menuManager;
    #endregion

    #region Methods

    [Inject]
    public void Construct(SaveLoadSystem saveLoadSystem, UISystem uiSystem, MenuManager menuManager)
    {
        _saveLoadSystem = saveLoadSystem;
        _uiSystem = uiSystem;
        _menuManager = menuManager;
    }
    public async override Task Enter()
    {
        _menuManager.OpenMenu("Loading");

        await LoadData();// �������� �������� ����� �� 1 �������

        await Task.Yield();

        _uiSystem.SetLoadingScreenProcess($"Initialization...");

        await Task.Delay(1000); // ����������� ���. �������� �� 1 ������� ���� �������� �����
    }
    private async Task LoadData()
    {
        var progress = new Progress<float>(p =>
        {
            //int �������� ������, �� float ����� ������ ���� �������� 50,00000001 �� �������� ������ float
            _uiSystem.SetLoadingScreenProcess($"LoadData ({(int)(p * 100)}%)");
            _uiSystem.UpdateLoadingScreenProgress(p);
        });
        _uiSystem.SetLoadingScreenProgress(0);
        GameData data = await _saveLoadSystem.GetData(progress);
    }
    #endregion
}
