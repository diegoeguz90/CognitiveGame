using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigation : Singleton<SceneNavigation>
{
    public void OpenScene1() 
    {
        PlayerPrefs.SetString("name", UserSelection.Instance._username);
        SceneManager.LoadScene(1); 
    }

    public void OpenScene2()
    {
        PlayerPrefs.SetString("name", UserSelection.Instance._username);
        SceneManager.LoadScene(2); 
    }

    public void OpenScene3()
    {
        PlayerPrefs.SetString("name", UserSelection.Instance._username);
        SceneManager.LoadScene(3); 
    }
    public void ExitGame() 
    {
        PlayerPrefs.SetString("name", UserSelection.Instance._username);
        Application.Quit(); 
    }
}
