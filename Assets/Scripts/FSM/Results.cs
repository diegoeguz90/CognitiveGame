using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Results : IState
{
    public void Enter()
    {
        UIController.Instance.resultsMenu.SetActive(true);
        GameManager.Instance.CalculateScore();
    }

    public void Update()
    {
        UIController.Instance.resultsMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {

    }
}
