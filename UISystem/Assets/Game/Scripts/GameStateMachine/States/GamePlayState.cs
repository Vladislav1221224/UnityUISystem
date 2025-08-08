using System.Threading.Tasks;

using UnityEngine;

using Zenject;

public class GamePlayState : FsmState
{
    #region Constructors
    public GamePlayState(Fsm fsm) : base(fsm) { }
    #endregion

    #region Properties
    private bool _isRunning;

    private UISystem _uiSystem;
    private MenuManager _menuManager;
    #endregion

    #region Methods
    [Inject]
    public void Construct(UISystem uiSystem, MenuManager menuManager)
    {
        _uiSystem = uiSystem;
        _menuManager = menuManager;
    }

    public async override Task Enter()
    {
        Debug.Log("Gameplay started!");
        _menuManager.OpenMenu("Game");
        _isRunning = true;
    }

    public override void Update()
    {
        if (_isRunning)
        {
            _uiSystem.UpdateGameTime();
        }
    }

    public async override Task Exit()
    {
        _isRunning = false;
    }
    #endregion
}