using System.Threading.Tasks;

using UnityEngine;

using Zenject;

public class GamePlayState : FsmState
{
    #region Constructors
    public GamePlayState(Fsm fsm) : base(fsm) { }
    #endregion

    #region Properties
    private float _sessionTime;
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
        _sessionTime = 0f;
        _isRunning = true;
    }

    public override void Update()
    {
        if (_isRunning)
        {
            _sessionTime += Time.deltaTime;
            _uiSystem.UpdateGameTime();
        }
    }

    public async override Task Exit()
    {
        _isRunning = false;
        Debug.Log($"Gameplay ended. Total time: {_sessionTime:F2} seconds");
    }
    #endregion
}