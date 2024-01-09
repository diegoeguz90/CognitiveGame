using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    /// <summary>
    /// UI GameObjects for visualy enabled and disabled
    /// </summary>
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject resultsMenu;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        Button startBtn = mainMenu.GetComponentInChildren<Button>();
        startBtn.onClick.AddListener(OnStartBtnClicked);

        Button finishBtn = resultsMenu.GetComponentInChildren<Button>();
        finishBtn.onClick.AddListener(OnFinishBtnClicked);
    }

    /// <summary>
    /// Event that change the MainMenuState
    /// </summary>
    private void OnStartBtnClicked()
    {
        GameManager.Instance.gameStates.Update();
    }

    /// <summary>
    /// Event that change the MainMenuState
    /// </summary>
    private void OnFinishBtnClicked()
    {
        GameManager.Instance.gameStates.Update();
    }
}
