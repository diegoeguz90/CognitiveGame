using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gameplay : IState
{
    public void Enter()
    {
        UIController.Instance.HUD.SetActive(true);
        GameManager.Instance.InitGame();
        GameManager.Instance.InitTimer();

    }

    public void Update()
    {
        GameManager.Instance.gameStates.TransitionTo(new Results());
    }

    public void Exit()
    {
        UIController.Instance.HUD.SetActive(false);
    }
}
