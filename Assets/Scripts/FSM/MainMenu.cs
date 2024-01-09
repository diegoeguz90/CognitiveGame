using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : IState
{
    public void Enter()
    {
        UIController.Instance.mainMenu.SetActive(true);
    }

    public void Update()
    {
        GameManager.Instance.gameStates.TransitionTo(new Gameplay());
    }

    public void Exit()
    {
        UIController.Instance.mainMenu.SetActive(false);
    }
}
