using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Results : IState
{
    public void Enter()
    {
        UIController.Instance.resultsMenu.SetActive(true);
        UIController.Instance.endGameMenu.SetActive(true);
        GameManager.Instance.CalculateScore();
        CloudSaveController.Instance.SaveDataCloud();
    }

    public void Update()
    {
        UIController.Instance.resultsMenu.SetActive(false);
        UIController.Instance.endGameMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {

    }
}
