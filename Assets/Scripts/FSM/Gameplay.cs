using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gameplay : IState
{
    public void Enter()
    {
        GameManager.Instance.InitGame();
    }

    public void Update(int score)
    {
        if(score == GameManager.Instance.numberOfItems)
            GameManager.Instance.gameStates.TransitionTo(new Results());
    }

    public void Exit()
    {

    }
}
