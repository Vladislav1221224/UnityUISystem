using UnityEngine;

using Zenject;

public class UISystem : MonoBehaviour
{
    #region Properties

    #region Serialized fields
    [Header("Views")]
    GameUIView _gameUIView;
    LoadingScreenView _loadingScreenView;
    GameStateMachine _gameStateMachine;
    #endregion

    #region Cache

    float _startGameSessionTime;

    #endregion

    #endregion

    #region Methods

    #region Unity methods

    private void Awake()
    {

    }

    private void Start()
    {
        _startGameSessionTime = Time.time;
        _gameStateMachine.StartGame();
    }

    private void Update()
    {

    }

    #endregion


    [Inject]
    public void Construct(GameUIView gameUIView, LoadingScreenView loadingScreenView, GameStateMachine gameStateMachine)
    {
        _gameUIView = gameUIView;
        _loadingScreenView = loadingScreenView;
        _gameStateMachine = gameStateMachine;
    }


    #region Game UI
    public void UpdateGameTime()
    {
        if (_gameUIView != null)
        {
            float sessionTime = Time.time - _startGameSessionTime;

            _gameUIView.SetGameTime(sessionTime);
        }
    }

    #endregion


    #region Loading screen

    public void SetLoadingScreenProgress(float progress)
    {
        if (_loadingScreenView != null)
        {
            _loadingScreenView.SetProgress(progress);
        }
    }

    #endregion

    #endregion
}