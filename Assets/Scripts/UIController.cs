using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject resultsMenu;

    // Start is called before the first frame update
    void Start()
    {
        Button startBtn = mainMenu.GetComponentInChildren<Button>();
        startBtn.onClick.AddListener(OnStartBtnClicked);

        Button finishBtn = resultsMenu.GetComponentInChildren<Button>();
        finishBtn.onClick.AddListener(OnFinishBtnClicked);
    }

    private void OnStartBtnClicked()
    {
        GameManager.Instance.gameStates.Update();
    }

    private void OnFinishBtnClicked()
    {
        GameManager.Instance.gameStates.Update();
    }
}
