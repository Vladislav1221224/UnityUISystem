using UnityEngine;

using Zenject;

public class UISystem : MonoBehaviour
{
    #region Properties

    GameStateMachine _gameStateMachine;

    #region Views
    GameUIView _gameUIView;
    LoadingScreenView _loadingScreenView;
    #endregion

    #region Cache

    float _startGameSessionTime;

    #endregion

    #endregion

    #region Methods

    #region Unity methods

    private void Start()
    {
        SetFPS();// Ставить fps відносно герцовки екрану

        _startGameSessionTime = Time.time;
        _gameStateMachine.StartGame();
    }
    private void Update()
    {
        _gameStateMachine.Update();
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

            _gameUIView.SetGameTime(Mathf.Round(sessionTime * 10f) / 10f);
        }
    }

    #endregion

    #region Loading screen

    public void ReloadGame()
    {
        _gameStateMachine.ReloadGame();
    }
    public void SetLoadingScreenProgress(float progress)
    {
        _loadingScreenView.SetProgress(progress);
    }
    public void UpdateLoadingScreenProgress(float progress)
    {
        _loadingScreenView.UpdateProgress(progress);
    }
    public void SetLoadingScreenProcess(string process)
    {
        _loadingScreenView.SetProcess($"Process: {process}");
    }

    #endregion

    #region Other
    void SetFPS()
    {
        // Нові версії Unity (refreshRateRatio.value дає float)
        float hz = (float)Screen.currentResolution.refreshRateRatio.value;

        QualitySettings.vSyncCount = 0; // щоб targetFrameRate працював
        Application.targetFrameRate = (int)hz;
    }
    #endregion
    #endregion
}