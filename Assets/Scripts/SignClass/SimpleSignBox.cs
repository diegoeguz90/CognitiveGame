using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleSignBox : Sign
{
    [SerializeField] TMP_Text titleTxt;
    [SerializeField] TMP_Text contentTxt;
    [SerializeField] TMP_Text quantityTxt;

    public override void SetMessageInSign(string title, string content)
    {
        titleTxt.text = title;
        contentTxt.text = content;
    }
    private void UpdateSignMessage(int quantity)
    {
        quantityTxt.text = "Items: " + quantity;
    }

    #region EventSuscription
    private void OnEnable()
    {
        SimpleStorageBox.OnStorageChanged += UpdateSignMessage;
    }

    #endregion
}
