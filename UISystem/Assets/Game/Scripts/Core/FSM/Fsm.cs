using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

public class Fsm
{
    private FsmState _stateCurrent;
    private Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>();

    private bool _isTransitioning = false;

    public void AddState(FsmState state)
    {
        var type = state.GetType();
        if (!_states.ContainsKey(type))
            _states.Add(type, state);
    }

    public async Task SetState<T>() where T : FsmState
    {
        var type = typeof(T);

        if (_stateCurrent != null && _stateCurrent.GetType() == type)
        {
            return;
        }

        if (_isTransitioning)
        {
            return;
        }

        if (_states.TryGetValue(type, out var newState))
        {
            _isTransitioning = true;

            if (_stateCurrent != null)
            {
                await _stateCurrent.Exit();
            }

            _stateCurrent = newState;

            Debug.Log($"Çאירמג ף State: {type.Name}");

            await _stateCurrent.Enter();

            _isTransitioning = false;
        }
        else
        {
            Debug.LogError($"State {type.Name} םו םאירמג FSM");
        }
    }

    public void Update()
    {
        _stateCurrent?.Update();
    }
}
