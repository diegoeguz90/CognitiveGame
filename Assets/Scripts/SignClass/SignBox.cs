using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignBox : Sign
{
    [SerializeField] TMP_Text titleTxt;
    [SerializeField] TMP_Text typeQuantityTxt;
    [SerializeField] TMP_Text totalQuantityTxt;

    public override void SetMessageInSign(string qTypeTxt, string qTotalTxt)
    {
        typeQuantityTxt.text = "Cantidad items por tipo: " + qTypeTxt;
        totalQuantityTxt.text = "Cantidad items total: " + qTotalTxt;
    }
}
