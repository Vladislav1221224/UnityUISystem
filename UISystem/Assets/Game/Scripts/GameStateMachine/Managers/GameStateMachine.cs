using System;

using UnityEngine;

using Zenject;

public class GameStateMachine : MonoBehaviour
{
    Fsm _fsm;

    DiContainer _container;

    [Inject]
    public void Construct(DiContainer container)
    {
        _container = container;
    }

    private void Awake()
    {
        _fsm = new Fsm();

        // Створюємо стейти через Zenject, щоб інжекція зайшла
        var loadingState = _container.Instantiate<LoadingState>(new object[] { _fsm });
        var gameplayState = _container.Instantiate<GamePlayState>(new object[] { _fsm });

        _fsm.AddState(loadingState);
        _fsm.AddState(gameplayState);
    }

    private void Update()
    {
        _fsm.Update();
    }

    public async void StartGame()
    {
        await _fsm.SetState<LoadingState>();
        await _fsm.SetState<GamePlayState>();
    }

    public async void ReloadGame()
    {
        await _fsm.SetState<LoadingState>();
        await _fsm.SetState<GamePlayState>();
    }
}
