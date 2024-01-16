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

    public TMP_Text CountDownTxt;

    public TMP_Text scoreBox1Txt;
    public TMP_Text scoreBox2Txt;
    public TMP_Text scoreBox3Txt;
    public TMP_Text scoreBox4Txt;

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

        scoreBox1Txt = resultsMenu.GetComponentsInChildren<TMP_Text>()[1];
        scoreBox2Txt = resultsMenu.GetComponentsInChildren<TMP_Text>()[2];
        scoreBox3Txt = resultsMenu.GetComponentsInChildren<TMP_Text>()[3];
        scoreBox4Txt = resultsMenu.GetComponentsInChildren<TMP_Text>()[4];
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
