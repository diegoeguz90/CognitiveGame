using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : Singleton<SceneNavigation>
{
    public void OpenScene1() { SceneManager.LoadScene(1); }

    public void OpenScene2() { SceneManager.LoadScene(2); }

    public void OpenScene3() { SceneManager.LoadScene(3); }

    public void ExitGame() { Application.Quit(); }
}
