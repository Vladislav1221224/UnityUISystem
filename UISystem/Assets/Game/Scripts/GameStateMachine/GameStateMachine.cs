using System;

using UnityEngine;

using Zenject;

/// <summary>
/// Керує створенням станів гри.
/// </summary>
public class GameStateMachine
{
    private Fsm _fsm;

    [Inject]
    public void Construct(Fsm fsm, LoadingState loadingState, GamePlayState gameplayState)
    {
        _fsm = fsm;

        _fsm.AddState(loadingState);
        _fsm.AddState(gameplayState);
    }
    public void Update()
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
