using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameStates
{
    public IState CurrentState { get; private set; }

    public MainMenu mainMenuState;
    public Gameplay gameplayState;
    public Results resultsState;

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        CurrentState?.Update();
    }
}
