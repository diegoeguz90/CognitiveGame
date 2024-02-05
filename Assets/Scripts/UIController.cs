using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    /// <summary>
    /// UI GameObjects for visualy enabled and disabled
    /// </summary>
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject resultsMenu;
    [SerializeField] public GameObject HUD;

    [SerializeField] public TMP_Text CountDownTxt;
    [SerializeField] public TMP_Text debugTxt;

    [SerializeField] public List<TMP_Text> scoreBoxesTxt;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        Button startBtn = mainMenu.GetComponentInChildren<Button>();
        startBtn.onClick.AddListener(OnStartBtnClicked);

        CountDownTxt = HUD.GetComponentsInChildren<TMP_Text>()[2];

        Button finishBtn = resultsMenu.GetComponentInChildren<Button>();
        finishBtn.onClick.AddListener(OnFinishBtnClicked);

        scoreBoxesTxt[0] = resultsMenu.GetComponentsInChildren<TMP_Text>()[1];
        scoreBoxesTxt[1] = resultsMenu.GetComponentsInChildren<TMP_Text>()[2];
        scoreBoxesTxt[2] = resultsMenu.GetComponentsInChildren<TMP_Text>()[3];
        scoreBoxesTxt[3] = resultsMenu.GetComponentsInChildren<TMP_Text>()[4];
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
